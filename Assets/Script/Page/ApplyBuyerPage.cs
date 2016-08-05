using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplyBuyerPage : Page {

	public override void OnBtnClick(Button button)
	{
		base.OnBtnClick(button);
		if (button.name == "ButtonBack") {
			PageManager.Instance.ClosePage(this);
		}
	}
}
