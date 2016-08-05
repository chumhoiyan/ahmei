using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShoppingCartSubPage : SubPage {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void OnBtnClick(Button button)
	{
		base.OnBtnClick(button);
		if (button.name == "ButtonAccount"){
			PageManager.Instance.OpenPage("SccessPage");
		}else if (button.name == "ButtonContact"){
			PageManager.Instance.OpenPage("ContactPage");
		}

	}
}
