using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingPage : Page {

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
		}else if (button.name == "ButtonLogout") {
			PageManager.Instance.OpenMainPage("CoverPage");
		}else if (button.name == "ButtonChangePassword") {
			PageManager.Instance.OpenPage("ChangePasswordPage");
		}else if (button.name == "ButtonEditInfomation") {
			PageManager.Instance.OpenPage("EditInformationPage");
		}else if (button.name == "ButtonFeedBack") {
			PageManager.Instance.OpenPage("FeedbackPage");
		}
	}
}
