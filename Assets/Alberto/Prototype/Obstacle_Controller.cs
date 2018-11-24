using UnityEngine;
using System.Collections.Generic;

public class Obstacle_Controller : MonoBehaviour {

    Obstacle_Manager parentSpawner;

    float speed;
    bool isInitialized;

    public void Init(Obstacle_Manager _parentSpawner, float _speed)
    {
        parentSpawner = _parentSpawner;

        speed = _speed;

        isInitialized = true;
    }

    private void Update()
    {
        if (isInitialized)
        {
            transform.position += transform.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player_Controller player = other.GetComponent<Player_Controller>();
        Obstacle_Manager spawner = other.GetComponent<Obstacle_Manager>();
        if (player == null && spawner == null)
            return;
        else if (player)
            parentSpawner.PointRemove();
        else if (spawner)
            parentSpawner.PointAdd();


        parentSpawner.RetriveObstacle(this);
        gameObject.SetActive(false);
        isInitialized = false;
    }
}
