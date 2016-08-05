using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContactPage : Page {

	protected void Awake(){
		base.Awake ();
		_subPageContainer = transform.FindChild ("Panel/SubPageContainer");
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}
	
	public override void LateStart(){
		Transform panel = transform.FindChild ("Panel/PanelSlidingMenu");
		SetUpSlidingMenu(panel, panel.FindChild ("Slider"));
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage(this);
		}
	}

	public override void OnSlidingMenuBtnClick(IconBase iconBase){
		base.OnSlidingMenuBtnClick (iconBase);
		string btnName = iconBase.name;
		if(btnName == "ButtonNews"){
			OpenSubPage(btnName, "ContactNewsSubPage", true);
		}else if(btnName == "ButtonNotice"){
			OpenSubPage(btnName, "ContactNoticeSubPage", true);
		}
	}
}
