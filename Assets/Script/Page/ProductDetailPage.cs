using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProductDetailPage : Page {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage(this);
		}else if (button.name == "ButtonContact") {
			PageManager.Instance.OpenPage("ContactPage");
		}
	}
}
