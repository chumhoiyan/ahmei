using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableClothesScript : IconBase ,IDragHandler {

	IconBase _iconBase;
	Image _image;

	protected void Awake(){
		base.Awake ();
		_image = GetComponent<Image> ();
	}
	
	protected void Start () {
		base.Start ();
	}
	
	protected void Update () {
		base.Update ();
	}

	public void SetUp(IconBase iconBase){
		_iconBase = iconBase;
		_image.sprite = iconBase.GetSprite ();
		_image.SetNativeSize ();
	}

	public virtual void OnDrag(PointerEventData ped){
		transform.position = Input.mousePosition;
	}

	public override void OnPointerDown(PointerEventData ped){
		
		Debug.Log ("OnPointerDown");
		Vector2 pos = Vector2.zero;
		SetPivot(transform as RectTransform, new Vector2(0.5f,0.5f));

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform, (Vector2)Input.mousePosition, null,out pos)){
			pos.x = (pos.x + ((RectTransform)transform).sizeDelta.x/2) / ((RectTransform)transform).sizeDelta.x;
			pos.y = (pos.y + ((RectTransform)transform).sizeDelta.y/2) / ((RectTransform)transform).sizeDelta.y;     

			SetPivot(transform as RectTransform, pos);
		}
		transform.SetAsLastSibling ();
	}
	
	public override void OnPointerUp(PointerEventData ped)
	{
	}

	public void SetPivot(this RectTransform rectTransform, Vector2 pivot)
	{
		if (rectTransform == null) return;
		
		Vector2 size = rectTransform.rect.size;
		Vector2 deltaPivot = rectTransform.pivot - pivot;
		Vector3 deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
		rectTransform.pivot = pivot;
		rectTransform.localPosition -= deltaPosition;
	}
}
