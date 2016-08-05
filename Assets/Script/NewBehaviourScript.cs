using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public float i;
    // Use this for initialization
    void Start () {
        Debug.Log(i);
    }
	public void button_1()
    {
        i =2;
    }
    public void button_2()
    {
        i =3;
    }
    public void button_3()
    {
        i =4;
    }
    // Update is called once per frame
    public void game ()
    {

        if (i == 2)
        {
            Application.LoadLevel("1");
        }
        else if (i == 3)
        {
            Application.LoadLevel("2");
        }
        else if (i == 4)
        {
            Application.LoadLevel("3");
        }

    }
}
