using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float MaximumOffSet = 3;
    public float MovementSpeed = 0.1f;

    [SerializeField]
    UI_CustomButton leftButton;
    [SerializeField]
    UI_CustomButton rightButton;

    private void Start()
    {
        leftButton.OnBtnDown = MoveLeft;
        rightButton.OnBtnDown = MoveRight;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            MoveLeft();
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            MoveRight();
    }

    public void MoveLeft()
    {
        if(transform.position.x >= -MaximumOffSet)
            transform.position += Vector3.left * MovementSpeed;
    }

    public void MoveRight()
    {
        if (transform.position.x <= MaximumOffSet)
            transform.position += Vector3.right * MovementSpeed;
    }
}
