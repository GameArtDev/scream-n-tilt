using UnityEngine;
using System.Collections.Generic;

public class Obstacle_Manager : MonoBehaviour {

    GameManager gameMng;

    [SerializeField]
    Obstacle_Controller obstaclePrefab;
    [SerializeField]
    List<Transform> spawnPoints = new List<Transform>();
    Stack<Obstacle_Controller> obstacles = new Stack<Obstacle_Controller>();

    public float ObstacleSpeed = 1;
    float originalSpeed;
    public float SpawnDelay;
    float originalDelay;
    float coolDown;
    public bool isAccelerating;
    public float AccelerationRatio;

	public void Init (GameManager _mng) {
        gameMng = _mng;

        originalDelay = SpawnDelay;
        originalSpeed = ObstacleSpeed;

        coolDown = SpawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(coolDown <= 0)
        {
            SpawnRandomBlockSequence();
            coolDown = SpawnDelay;
        }
        else
        {
            coolDown -= Time.deltaTime;
        }
	}

    public void PointAdd()
    {
        gameMng.Points++;
    }

    public void PointRemove()
    {
        gameMng.Points --;
        ResetAcceleration();
    }

    public void ToggleAcceleration(bool _active)
    {
        isAccelerating = _active;

        if (!isAccelerating)
            ResetAcceleration();
    }

    public void ResetAcceleration()
    {
        ObstacleSpeed = originalSpeed;
        SpawnDelay = originalDelay;
    }

    public void RetriveObstacle(Obstacle_Controller _obstacle)
    {
        obstacles.Push(_obstacle);
    }

    public void SpawnObstacle(Vector3 _position)
    {
        Obstacle_Controller newObstacle;
        if(obstacles.Count > 0)
            newObstacle = obstacles.Pop();
        else
            newObstacle = Instantiate<Obstacle_Controller>(obstaclePrefab);

        newObstacle.transform.position = _position;
        newObstacle.transform.rotation = transform.rotation;

        newObstacle.Init(this, ObstacleSpeed);
    }

    public void SpawnRandomBlockSequence()
    {
        int[] blks = new int[spawnPoints.Count];
        int safeCheck = 0;

        for (int i = 0; i < blks.Length; i++)
        {
            int value = Random.Range(0, 2);
            safeCheck += value;

            if (safeCheck >= spawnPoints.Count)
                break;
            else
                blks[i] = value;
        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (blks[i] > .5f)
                SpawnObstacle(spawnPoints[i].position);
        }

        if (isAccelerating)
        {
            SpawnDelay /= AccelerationRatio;
            ObstacleSpeed *= AccelerationRatio;
        }
    }
}
