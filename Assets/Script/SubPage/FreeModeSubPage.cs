using UnityEngine;
using System.Collections;

public class FreeModeSubPage : SubPage {

	protected void Awake(){
		base.Awake ();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
		UpdateContent ();
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	void UpdateContent(){
		GameObject draggableClothesResources = Resources.Load ("Prefabs/DraggableClothes") as GameObject;
		foreach (IconBase iconBase in UserData.Instance.chosenAddClothes) {
			GameObject draggableClothesClone = Instantiate(draggableClothesResources) as GameObject;
			draggableClothesClone.GetComponent<DraggableClothesScript>().SetUp(iconBase);
			
			draggableClothesClone.transform.SetParent(transform, false);
			draggableClothesClone.transform.localPosition = GetRandomCanvasPos();

		}
	}

	Vector2 GetRandomCanvasPos(){
		float width = ((RectTransform)transform).rect.width;
		float height = ((RectTransform)transform).rect.height;

		float randomX = Random.Range (-1 * width / 2, width / 2);
		float randomY = Random.Range (-1 * height / 2, height / 2);

		return new Vector2(randomX, randomY);
	}
}
