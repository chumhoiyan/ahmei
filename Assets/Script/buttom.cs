using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttom : MonoBehaviour {
    public bool side_menu_come = false;
    public GameObject sideMenu1;
    public GameObject sideMenu2;
    public Text numberleft;
    public Text numbermiddle;
    public Text numberright;
    public Image Line;

    // Use this for initialization
    void Awake()
    {
       
    }
   
    public void Call_Side_right1()
    {
		come1(sideMenu2);
        goBackright1(sideMenu1);
        side_menu_come = !side_menu_come;
        numberright.GetComponent<Text>().color = Color.red;
        numberleft.GetComponent<Text>().color = Color.black;
        Line.GetComponent<RectTransform>().position = new Vector2(180, 365);
    }
    public void Call_Side_left1()
    {
        come1(sideMenu1);
        goBackright1(sideMenu2);
        side_menu_come = !side_menu_come;
        numberright.GetComponent<Text>().color = Color.black;
        numberleft.GetComponent<Text>().color = Color.red;
        Line.GetComponent<RectTransform>().position = new Vector2(60, 365);
    }
    public void Call_Side_right()
    {
        
        come(sideMenu2);
        goBackleft(sideMenu1);
        side_menu_come = !side_menu_come;
        numberright.GetComponent<Text>().color = Color.red;
        numberleft.GetComponent<Text>().color = Color.black;
        numbermiddle.GetComponent<Text>().color = Color.black;
        Line.GetComponent<RectTransform>().position = new Vector2(200, 355);
    }
    public void Call_Side_left()
    {
        
        come(sideMenu1);
        goBackright(sideMenu2);
        side_menu_come = !side_menu_come;
        numberleft.GetComponent<Text>().color = Color.red;
        numberright.GetComponent<Text>().color = Color.black;
        numbermiddle.GetComponent<Text>().color = Color.black;
        Line.GetComponent<RectTransform>().position = new Vector2(40, 355);
    }
    public void Call_Side_meddle()
    {
		
        goBackleft(sideMenu1);
        goBackright(sideMenu2);
        side_menu_come = !side_menu_come;
        numbermiddle.GetComponent<Text>().color = Color.red;
        numberleft.GetComponent<Text>().color = Color.black;
        numberright.GetComponent<Text>().color = Color.black;
        Line.GetComponent<RectTransform>().position = new Vector2(120, 355);
    }
    public static void come(GameObject g, float delay = 0, string action = "setCanClick")
    {
       // setCantClick(g);
		setTween(-1, -55, g, delay =0, action = "setCanClick");
    }
    public static void come1(GameObject g, float delay = 0, string action = "setCanClick")
    {
        // setCantClick(g);
        setTween(1, -22, g, delay, action);
    }
    public static void goBackright(GameObject g, float delay = 0, string action = "")
    {
       // setCantClick(g);
        setTween(400, -55, g, delay, action);

    }
	public static void goBackright1(GameObject g, float delay = 0, string action = "")
    {
        // setCantClick(g);
        setTween(395, -22, g, delay, action);

    }
    public static void goBackleft(GameObject g, float delay = 0, string action = "")
    {
       // setCantClick(g);
        setTween(-400, -55, g, delay, action);
    }
    public static void setTween(float x, float y, GameObject g, float delay = 0, string action = "")
    {
        setTween(x, y, g, g, 0, delay, action);
    }
    public static void setTween(float x, float y, GameObject g, GameObject h, float time = 0.2f, float delay = 0, string action = "")
    {
        iTween.MoveTo(g, iTween.Hash("position", new Vector3(x, y, 0),
                                       "islocal", true,
                                       "easetype", iTween.EaseType.easeInOutSine,
                                       "time", 0.2f,
                                       "delay", delay,
                                       "oncompletetarget", h,
                                       "oncomplete", action
                                       ));
    }
} 

