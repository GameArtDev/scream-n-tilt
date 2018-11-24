using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    UI_Controller uiCtrl;
    [SerializeField]
    Obstacle_Manager obsMng;

    float points;
    public float Points
    {
        get { return points; }
        set
        {
            points = value;
            uiCtrl.SetPoints(points);
        }
    }

    private void Start()
    {
        obsMng.Init(this);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleObstacleAcceleration()
    {
        if(obsMng.isAccelerating)
            obsMng.ToggleAcceleration(false);
        else
            obsMng.ToggleAcceleration(true);
    }
}
