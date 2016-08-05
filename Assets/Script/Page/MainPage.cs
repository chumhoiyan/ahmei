using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainPage : Page {

	Text _textTitle;
	List<Toggle> _listBottomToggle;
	Toggle currentToggle;

	void Awake(){
		base.Awake ();
		//_textTitle = transform.FindChild("BG/TopPanel/TextTitle").GetComponent<Text>();
		_subPageContainer = transform.FindChild("BG/SubPageContainer");

		Transform buttomPanel = transform.FindChild("BG/BottomPanel");
		_listBottomToggle = new List<Toggle> ();
		foreach (Toggle tg in buttomPanel.GetComponentsInChildren<Toggle>()) {
			_listBottomToggle.Add(tg);
			if(tg.name == "ToggleMain"){
				tg.isOn = true;
			}
		}
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void OnBtnClick(Button button){
	}

	public void OnToggleClick(Toggle toggle){

		if (!toggle.isOn) {
			return;
		} else {
			if(currentToggle != null){
				currentToggle.isOn = false;
				currentToggle.interactable = true;
			}
			currentToggle = toggle;
			currentToggle.interactable = false;
			currentToggle.isOn = true;
		}

		string toggleName = toggle.name;

		if (toggleName == "ToggleMain") {
			OpenSubPage(toggleName, "MainSubPage");
		}else if (toggleName == "ToggleShop") {
			OpenSubPage(toggleName, "ShopSubPage");
		}else if (toggleName == "ToggleRecommend") {
			OpenSubPage(toggleName, "RecommendSubPage");
		}else if (toggleName == "ToggleCart") {
			OpenSubPage(toggleName, "ShoppingCartSubPage");
		}else if (toggleName == "ToggleProfile") {
			OpenSubPage(toggleName, "OwnerSubPage");
		}

	}

}

