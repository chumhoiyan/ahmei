using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopCategoryPage : Page {

	protected void Awake(){
		base.Awake ();
		_subPageContainer = transform.FindChild ("SubPageContainer");
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}

	public override void LateStart(){
		SetUpSlidingMenu(transform.FindChild ("PanelSlidingMenu"), transform.FindChild ("PanelSlidingMenu/Slider"));
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public override void OnBtnClick(Button button){
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage (this);
		}
	}

	public override void OnSlidingMenuBtnClick(IconBase iconBase){
		base.OnSlidingMenuBtnClick (iconBase);
		string btnName = iconBase.name;
		if(btnName == "ButtonTop"){
			OpenSubPage(btnName, "ShopCategorySubPage", true);
		}else if(btnName == "ButtonDress"){
			OpenSubPage(btnName, "ShopCategorySubPage", true);
		}else if(btnName == "ButtonPant"){
			OpenSubPage(btnName, "ShopCategorySubPage", true);
		}
	}

}
