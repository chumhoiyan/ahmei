using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProductMatchSubPage : SubPage {

	public GameObject pageGO;

	public int pageNumber = 10;
	public int pageCount = 1;
	List<GameObject> pageList;

	Text _TextPageNumber;

	protected void Awake(){
		base.Awake ();
		CustomScrollRect customScrollRect = transform.GetComponentInChildren<CustomScrollRect> ();
		customScrollRect.updatePageNumber += updatePage;
		_TextPageNumber = transform.FindChild("PageNumber").GetComponentInChildren<Text>();
		LoadPages ();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
		//transform.GetComponentInChildren<CustomScrollRect> ().SetUp ();
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public void updatePage(int currentPage){
		_TextPageNumber.text = (currentPage + 1) + "/" + pageNumber;
	}

	public void LoadPages(){

		Vector2 scrollViewSize = ((RectTransform)transform.FindChild ("ScrollView")).rect.size;

		for (int i = 0; i < pageNumber; i++) {
			GameObject pageClone = Instantiate(pageGO) as GameObject;
			ProductMatchItemScript script = pageClone.GetComponent<ProductMatchItemScript>();
			script.SetUp(scrollViewSize);

			pageClone.transform.SetParent(transform.FindChild ("ScrollView/Viewport/Content"),false);
		}

		_TextPageNumber.text = "1/" + pageNumber;
	}
}
