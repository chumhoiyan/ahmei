using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegisterPage : Page {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnBtnClick(Button button)
    {
        base.OnBtnClick(button);
        if (button.name == "ButtonBack"){
            PageManager.Instance.ClosePage(this);
        }else if (button.name == "RegisterButton"){
			PageManager.Instance.OpenMainPage("MainPage");
		}else if (button.name == "ButtonCancel"){
			PageManager.Instance.OpenMainPage("CoverPage");
		}
    }

}
