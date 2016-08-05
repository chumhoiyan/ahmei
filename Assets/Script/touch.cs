using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class touch : MonoBehaviour, IDragHandler, IPointerUpHandler , IPointerDownHandler
{
    public Image bgImg;
    public Image joystickImg;

    public Vector3 InputDirection { set; get; }

    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
       // InputDirection = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Debug.Log("OnDrag");
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

           float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x : pos.x ;
           float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y : pos.y ;

            InputDirection = new Vector2(x, y);
            //InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            joystickImg.rectTransform.anchoredPosition = new Vector2(InputDirection.x * (bgImg.rectTransform.sizeDelta.x /1.5f), InputDirection.y * (bgImg.rectTransform.sizeDelta.y / 1.9f));
            Debug.Log(InputDirection);
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        Debug.Log("OnPointerDown");
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        Debug.Log("OnPointerUp");
        //InputDirection = Vector3.zero;
        //joystickImg.rectTransform.anchoredPosition = Vector3.zero;

    }
}
