using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    Resolution[] resolution;
    [SerializeField] Transform menuPanel;
    [SerializeField]GameObject buttonPrefab;
	// Use this for initialization
	void Start ()
    {
        resolution = Screen.resolutions;
        for (int i = 0; i < resolution.Length; i++)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = ResToString(resolution[i]);
            button.GetComponent<Button>().onClick.AddListener(() => { SetResolution(i); });
            int index = i;
            button.transform.parent = menuPanel;
        }
	}
    void SetResolution(int index)
    {
        Screen.SetResolution(resolution[index].width,resolution[index].height,false);
    }
    string ResToString(Resolution res)
    {
        return res.width +" x " + res.height;
    }
	// Update is called once per frame
	
}
