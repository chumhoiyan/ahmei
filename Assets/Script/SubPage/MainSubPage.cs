using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainSubPage : SubPage {

	protected void Awake(){
	}
	
	// Use this for initialization
	protected void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick(button);
		if (button.name == "ButtonHotProduct"){
			PageManager.Instance.OpenPage("HotProductPage");
		}else if (button.name == "ButtonContact"){
			PageManager.Instance.OpenPage("ContactPage");
		}
	}
}
