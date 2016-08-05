using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoverPage : Page {

	void Awake(){
		base.Awake ();
		//PageManager.Instance.setIndexPage (this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);
		if (button.name == "ButtonLogin") {
			PageManager.Instance.ClosePage(this);
			PageManager.Instance.OpenPage ("MainPage");
		} else if (button.name == "ButtonRegister") {
			PageManager.Instance.OpenPage ("RegistrationPage");
		} else if (button.name == "ButtonForgetPW") {
			PageManager.Instance.OpenPage ("ForgetPWPage");
		}
	}
}
