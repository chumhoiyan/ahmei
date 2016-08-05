using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class IconBase :  IconData,
IPointerClickHandler,IPointerUpHandler , IPointerDownHandler
{
	public delegate void OnClickCallback(IconBase iconBase);
	public event OnClickCallback onClickCallback;

	public delegate void OnDragCallback(IconBase iconBase);
	public event OnDragCallback onDragCallback;
	public Sprite GetSprite(){
		if (GetComponent<Image> ()) {
			return GetComponent<Image>().sprite;
		}
		return null;
	}

	protected void Awake(){
		base.Awake ();
	}
	
	protected void Start () {
		base.Start ();
	}

	protected void Update () {
		base.Update ();
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
	}

	public virtual void OnPointerClick(PointerEventData ped)
	{
		if (onClickCallback != null) {
			onClickCallback (this);
		}
	}


	public virtual void OnPointerUp(PointerEventData ped)
	{}
}
