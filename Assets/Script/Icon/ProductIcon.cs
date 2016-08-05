using UnityEngine;
using System.Collections;

public class ProductIcon : IconBase {

	protected void Awake(){
		base.Awake ();
		base.onClickCallback += OnClickCallback;
	}
	
	protected void Start () {
		base.Start ();
	}
	
	protected void Update () {
		base.Update ();
	}

	public void OnClickCallback(IconBase iconBase){
		PageManager.Instance.OpenPage ("ProductDetailPage");
	}
}
