using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopSubPage : SubPage {

	Transform _TContentPanel;

	void Awake(){
		base.Awake ();

		_TContentPanel = transform.FindChild("Viewport/Content/ContentPanel");

		foreach (Button btn in _TContentPanel.GetComponentsInChildren<Button>()) {
			btn.onClick.AddListener(()=>{
				OnBtnClick(btn);
			});
		}

	}
	
	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public override void OnBtnClick(Button button){
		if (button.name == "ButtonContact") {
			PageManager.Instance.OpenPage ("ContactPage");
		} else {
			PageManager.Instance.OpenPage ("ShopCategoryPage");
		}
	}
}
