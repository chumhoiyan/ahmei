using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopItemDetailPage : Page {

	IconBase _iconBase;
	Image _ImageItem;

	protected void Awake(){
		base.Awake ();
		_ImageItem = transform.FindChild ("Content/ImageItem").GetComponent<Image> ();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public void UpdateContent(IconBase iconBase){
		_iconBase = iconBase;
		_ImageItem.sprite = _iconBase.GetSprite ();
	}

	public override void OnBtnClick(Button button){
		if (button.name == "DimBG") {
			PageManager.Instance.ClosePage (this);
		} else if (button.name == "ButtonAdd") {
			UserData.Instance.chosenAddClothes.Add(_iconBase);
			PageManager.Instance.OpenPage ("AddItemPage");
		}
	}

}
