using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopItemPage : Page {

	protected void Awake(){
		base.Awake ();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();

		foreach (Button btn in transform.FindChild("ContentScrollView").GetComponentsInChildren<Button>()) {
			Button tempBtn = btn;
			tempBtn.onClick.AddListener(()=>{
				OnItemButtonClick(tempBtn.GetComponent<IconBase>());
			});
		}
	}

	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public override void OnBtnClick(Button button){
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage (this);
		}
	}

	public void OnItemButtonClick(IconBase iconBase){
		ShopItemDetailPage page = PageManager.Instance.OpenPage ("ShopItemDetailPage") as ShopItemDetailPage;
		page.UpdateContent (iconBase);
	}

}
