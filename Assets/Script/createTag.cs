using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class createTag : MonoBehaviour {

    public GameObject canvas;
    public GameObject enemyCar;
    private GameObject createImage;
    public GameObject Layer;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    public void layer()
    {
        createImage = Instantiate(enemyCar) as GameObject;
        createImage.transform.SetParent(canvas.transform, false);
    }

}
