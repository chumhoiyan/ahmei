using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OwnerSubPage : SubPage {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void OnBtnClick(Button button)
	{
		base.OnBtnClick(button);
		if (button.name == "ButtonApplyBuyer") {
			PageManager.Instance.OpenPage("ApplyBuyerPage");
		}else if (button.name == "ButtonSetting") {
			PageManager.Instance.OpenPage("SettingPage");
		}else if (button.name == "ButtonContact") {
			PageManager.Instance.OpenPage("ContactPage");
		}else if (button.name == "ButtonAddress") {
			PageManager.Instance.OpenPage("EditAddressPage");
		}else if (button.name == "ButtonUserProduct") {
			PageManager.Instance.OpenPage("UserProductPage");
		}else if (button.name == "ButtonAddItem") {
			PageManager.Instance.OpenPage("AddItemPage");
		}

	}
}
