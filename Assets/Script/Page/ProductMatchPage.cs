﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProductMatchPage : Page {

	protected void Awake(){
		base.Awake ();
		_subPageContainer = transform.FindChild ("SubPageContainer");
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}
	
	public override void LateStart(){
		SetUpSlidingMenu(transform.FindChild ("PanelSlidingMenu"), transform.FindChild ("PanelSlidingMenu/Slider"));
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public override void OnSlidingMenuBtnClick(IconBase iconBase){
		base.OnSlidingMenuBtnClick (iconBase);
		string btnName = iconBase.name;
		if(btnName == "ButtonLatest"){
			OpenSubPage(btnName, "ProductMatchSubPage", true);
		}else if(btnName == "ButtonHit"){
			OpenSubPage(btnName, "ProductMatchSubPage", true);
		}else if(btnName == "ButtonAll"){
			OpenSubPage(btnName, "ProductMatchSubPage", true);
		}
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage (this);
		}
	}

}
