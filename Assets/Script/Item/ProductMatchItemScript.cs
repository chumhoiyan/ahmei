using UnityEngine;
using System.Collections;

public class ProductMatchItemScript : MonoBehaviour {

	public void SetUp(Vector2 containerSize){
		((RectTransform)transform).sizeDelta = containerSize;
	}
}
