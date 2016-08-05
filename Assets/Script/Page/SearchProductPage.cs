using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SearchProductPage : Page {
	public GameObject LeftPage;
	public GameObject RightPage;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void OnBtnClick(Button button)
	{
		base.OnBtnClick (button);
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage (this);
		}
	}
}
