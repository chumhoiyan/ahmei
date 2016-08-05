using UnityEngine;
using System.Collections;

public class Testedapplication : MonoBehaviour {
    public GameObject panel;
    public GameObject panel1;
    public void A()
    {
        //Application.LoadLevel("A");
        panel.gameObject.SetActive(false);
        panel1.gameObject.SetActive(true);
    }
    public void B()
    {
        //Application.LoadLevel("A");
        panel1.gameObject.SetActive(false);
    }
}
