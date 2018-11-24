using UnityEngine.UI;
using UnityEngine;

public class UI_Controller : MonoBehaviour {

    [SerializeField]
    Text pointsText;

	public void SetPoints(float _value)
    {
        pointsText.text = _value.ToString();
    }
}
