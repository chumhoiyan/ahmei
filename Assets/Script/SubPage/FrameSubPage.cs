using UnityEngine;
using System.Collections;

public class FrameSubPage : SubPage {

	IconBase _iconBase;

	public void SetUp(IconBase iconBase){
		int frameId = iconBase.id;
		GameObject frameClone = Instantiate (Resources.Load ("Prefabs/Frame/" + frameId, typeof(GameObject))) as GameObject;
		frameClone.transform.SetParent (transform, false);
		frameClone.transform.localPosition = Vector3.zero;
	}

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
}
