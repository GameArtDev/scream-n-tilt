using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float MaximumOffSet = 3;
    public float MovementSpeed = 0.1f;

    public bool isVoiceControlled;

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
        if (!isVoiceControlled)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                MoveLeft();
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                MoveRight();
        }
        else
        {
            Move(MicrophoneInput.MicLoudnessDb + 30);
        }
    }

    public void Move(float _value)
    {
        if (_value < -100)
            _value = -100;

        transform.position += Vector3.right * MovementSpeed * _value / 20;

        if (transform.position.x <= -MaximumOffSet)
            transform.position = new Vector3(-MaximumOffSet, transform.position.y, transform.position.z);
        else if (transform.position.x >= MaximumOffSet)
            transform.position = new Vector3(MaximumOffSet, transform.position.y, transform.position.z);

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
