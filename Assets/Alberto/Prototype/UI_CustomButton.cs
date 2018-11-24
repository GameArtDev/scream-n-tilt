using UnityEngine;
using UnityEngine.EventSystems;

public class UI_CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void CustomButtonDelegate();
    public CustomButtonDelegate OnBtnDown;

    bool isPointerDown;
    bool isPointerIn;

    private void Update()
    {
        isPointerDown = Input.GetMouseButton(0);

        if (isPointerDown && isPointerIn)
            OnInputDown();
    }

    void OnInputDown()
    {
        if (OnBtnDown != null)
            OnBtnDown();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerIn = false;
    }
}

