using UnityEngine;
using System.Collections;

public class LayerPosition : MonoBehaviour {
    public GameObject Layer;
    public Random y;
    void Update()
    {
    }
    // Use this for initialization
    public void layercome()
    {
        Layer.GetComponent<RectTransform>().position = new Vector2(119, 212);
    }
}
