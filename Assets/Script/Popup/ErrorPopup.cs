using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ErrorPopup : Popup {

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

	public void SetUp(string errorMsg){
		GetComponentInChildren<Text> ().text = errorMsg;
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);
		if (button.name == "DimBG") {
			PageManager.Instance.ClosePopup (this);
		}
	}
}
