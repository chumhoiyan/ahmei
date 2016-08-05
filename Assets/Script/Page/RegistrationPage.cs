using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegistrationPage: Page {

	protected void Awake(){
		base.Awake ();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

    public override void OnBtnClick(Button button)
    {
        base.OnBtnClick(button);
        if (button.name == "ButtonBack")
        {
            PageManager.Instance.ClosePage(this);
        }
        else if (button.name == "ButtonRegister")
        {
            PageManager.Instance.OpenPage("RegisterPage");
        }
    }
}
