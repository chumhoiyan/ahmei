using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public RectTransform panel;
    public Image[] bttn;
    public RectTransform center;
    public float[] distance;
    public float[] distReposition;

    private bool dragging = false;
    private int bttnDistance;
    private int minButtomNum;
    private int bttnLenght= 1;

    void Start()
    {
        int bttnLenght = bttn.Length;
        distance = new float[bttnLenght];
        distReposition = new float[bttnLenght];
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }
    void Update()
    {
        for (int i =0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if (distReposition[i] > 1000)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX + (bttnLenght * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
            if (distReposition[i] < -1000)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX - (bttnLenght * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
        }

        float minDistance = Mathf.Min(distance);

        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtomNum = a;
            }
        }
        if (!dragging)
        {
        //LerpToBttn(minButtomNum * -bttnDistance);
        LerpToBttn (-bttn[minButtomNum].GetComponent<RectTransform>().anchoredPosition.x);
        }
    }
    void LerpToBttn(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 2.5f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    { 
        dragging = true;
    }
    public void EndDrag()
    {
        dragging = false;
    }
}
    

