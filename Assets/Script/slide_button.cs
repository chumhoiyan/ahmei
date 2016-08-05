using UnityEngine;
using System.Collections;

public class slide_button : MonoBehaviour
{
    public bool side_menu_come = false;
    public GameObject sideMenu1;
    public GameObject sideMenu2;
    public GameObject sideMenu3;
    public GameObject sideMenu4;
    public GameObject sideMenu5;
    public GameObject sideMenu6;

    // Use this for initialization
    void Awake()
    {
    }
    public void Call_Side_left1()
    {

        come(sideMenu1);
        goBackright(sideMenu2);
        goBackright(sideMenu3);
        goBackright(sideMenu4);
        goBackright(sideMenu5);
        goBackright(sideMenu6);

        side_menu_come = !side_menu_come;
    }
    public void Call_Side_left2()
    {

        goBackright(sideMenu1);
        come(sideMenu2);
        goBackright(sideMenu3);
        goBackright(sideMenu4);
        goBackright(sideMenu5);
        goBackright(sideMenu6);

        side_menu_come = !side_menu_come;
    }
    public void Call_Side_left3()
    {

        goBackright(sideMenu1);
        goBackright(sideMenu2);
        come(sideMenu3);
        goBackright(sideMenu4);
        goBackright(sideMenu5);
        goBackright(sideMenu6);

        side_menu_come = !side_menu_come;
    }
    public void Call_Side_left4()
    {

        goBackright(sideMenu1);
        goBackright(sideMenu2);
        goBackright(sideMenu3);
        come(sideMenu4);
        goBackright(sideMenu5);
        goBackright(sideMenu6);

        side_menu_come = !side_menu_come;
    }
    public void Call_Side_left5()
    {

        goBackright(sideMenu1);
        goBackright(sideMenu2);
        goBackright(sideMenu3);
        goBackright(sideMenu4);
        come(sideMenu5);
        goBackright(sideMenu6);

        side_menu_come = !side_menu_come;
    }
    public void Call_Side_left6()
    {

        goBackright(sideMenu1);
        goBackright(sideMenu2);
        goBackright(sideMenu3);
        goBackright(sideMenu4);
        goBackright(sideMenu5);
        come(sideMenu6);

        side_menu_come = !side_menu_come;
    }


    public static void come(GameObject g, float delay = 0, string action = "setCanClick")
    {
        //setCantClick(g);
        setTween(-1010, -23, g, delay, action);
    }
    public static void goBackright(GameObject g, float delay = 0, string action = "")
    {
        //setCantClick(g);
        setTween(-626, -23, g, delay, action);
    }
    public static void goBackleft(GameObject g, float delay = 0, string action = "")
    {
         //setCantClick1(g);
        setTween(-338, -30, g, delay, action);
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
