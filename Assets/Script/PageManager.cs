using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PageManager : Singleton<PageManager> {

	GameObject canvas;
	Transform pageContainer;
	public Page currentPage;
	public List<Page> pageList;
	Popup currentPopup;

	// Use this for initialization
	void Awake () {
		base.Awake ();
		canvas = GameObject.Find("MainCanvas");
		pageContainer = canvas.transform.FindChild ("PageContainer");

		pageList = new List<Page> ();
	}

	public void setIndexPage(Page page){
		currentPage = page;
		pageList.Add (page);
	}

	public void OpenMainPage(string name){
		Page[] pages = pageList.ToArray ();
		foreach (Page p in pages) {
			ClosePage(p, false);
		}
		OpenPage (name, false);
	}

	public Page OpenPage(string name, bool animationOn = true){
		Page page = new Page ();
		GameObject pageResources = Resources.Load ("Prefabs/Page/" + name, typeof(GameObject)) as GameObject;
		if (pageResources != null) {
			GameObject pageClone = Instantiate(pageResources) as GameObject;
			page = pageClone.GetComponent<Page>();
			if(page!=null){
				pageClone.transform.SetParent(pageContainer, false);

				pageList.Add(page);
				currentPage = page;
				if(animationOn){
					OnTransitionStart();
					SimpleAnimation simpleAnim = page.GetComponent<SimpleAnimation>();
					simpleAnim.pageIn(OnTransitionEnd);
				}

			}else{
				Debug.Log("Component Page not found in" + pageClone.name);
			}
		} else {
			Debug.Log("Cannot find page:" + name);
		}
		return page;
	}

	public Popup OpenPopup(string name){
		Popup popup = new Popup ();
		GameObject popupResources = Resources.Load ("Prefabs/Popup/" + name, typeof(GameObject)) as GameObject;
		if (popupResources != null) {
			GameObject popupClone = Instantiate(popupResources) as GameObject;
			popup = popupClone.GetComponent<Popup>();
			if(popup!=null){
				popupClone.transform.SetParent(canvas.transform, false);
				//currentPopup = popup;

				OnTransitionStart();
				SimpleAnimation simpleAnim = popup.GetComponent<SimpleAnimation>();
				simpleAnim.popUp(OnTransitionEnd);
			}else{
				Debug.Log("Component Page not found in" + popupClone.name);
			}
		} else {
			Debug.Log("Cannot find page:" + name);
		}
		return popup;
	}

	public void ClosePopup(Popup popup){
		OnTransitionStart();
		SimpleAnimation simpleAnim = popup.GetComponent<SimpleAnimation>();
		simpleAnim.popOut (OnTransitionEnd);
	}

	public void ClosePage(Page page, bool animationOn = true){
		if (animationOn) {
			OnTransitionStart();
			page.PreparePageClose ();
			SimpleAnimation simpleAnim = page.GetComponent<SimpleAnimation> ();
			simpleAnim.pageOut (new System.Action[]{OnTransitionEnd,page.OnPageClose});
		} else {
			page.OnPageClose();
		}
	}

	public void OnTransitionStart(){
		foreach (Page page in pageList) {
			page.GetComponent<CanvasGroup>().interactable = false;
		}
	}

	public void OnTransitionEnd(){
		foreach (Page page in pageList) {
			page.GetComponent<CanvasGroup>().interactable = true;
		}
	}
	
}
