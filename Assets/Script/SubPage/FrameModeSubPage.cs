using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrameModeSubPage : SubPage {

	protected void Awake(){
		base.Awake ();
		_subPageContainer = transform.FindChild ("SubPageContainer");
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}

	public override void LateStart(){
		SetUpSlidingMenu(transform.FindChild ("PanelSlidingMenu"), transform.FindChild ("PanelSlidingMenu/Viewport/Content/Slider"));
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public override void OnSlidingMenuBtnClick(IconBase iconBase){
		base.OnSlidingMenuBtnClick (iconBase);
		string btnName = iconBase.name;
		FrameSubPage page = OpenSubPage(btnName, "FrameSubPage", true) as FrameSubPage;
		page.SetUp (iconBase);
	}
}
