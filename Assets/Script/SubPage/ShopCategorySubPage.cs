using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopCategorySubPage : SubPage {

	protected void Awake(){
		base.Awake ();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
		foreach (Button btn in transform.GetComponentsInChildren<Button>()) {
			btn.onClick.AddListener(()=>{
				OnCategoryBtnClick(btn);
			});
		}
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);

	}

	public void OnCategoryBtnClick(Button button){
		//hard code
		PageManager.Instance.OpenPage ("ShopItemPage");
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}
}
