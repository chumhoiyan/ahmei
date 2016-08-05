using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class CoverPage : Page {

	InputField _inputFieldName;
	InputField _inputPassword;

	void Awake(){
		base.Awake ();
		_inputFieldName = transform.FindChild ("Content/InputFieldName").GetComponent<InputField>();
		_inputPassword = transform.FindChild ("Content/InputFieldPassword").GetComponent<InputField>();
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

			Dictionary<string, string> parma = new Dictionary<string, string>();
			parma.Add("Log",_inputFieldName.text);
			parma.Add("password", _inputPassword.text);

			Request.Instance.CallAPI(RequestUrlConfig.API_USER_LOGIN, parma, OnLoginCallback);

			//PageManager.Instance.ClosePage(this);
			//PageManager.Instance.OpenPage ("MainPage");

		} else if (button.name == "ButtonRegister") {
			PageManager.Instance.OpenPage ("RegistrationPage");
		} else if (button.name == "ButtonForgetPW") {
			PageManager.Instance.OpenPage ("ForgetPWPage");
		}
	}

	private void OnLoginCallback(JSONNode json){
		PageManager.Instance.ClosePage(this);
		PageManager.Instance.OpenPage ("MainPage");
	}
}
