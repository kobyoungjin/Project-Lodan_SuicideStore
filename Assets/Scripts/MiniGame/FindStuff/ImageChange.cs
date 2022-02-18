using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Sprite AfterClickImage;//바꾼 이미지
    Button button;

    private bool open;
    GameObject button2;

    public float x;
    public float y;

    FindStuffManager findStuffManager;

    // Start is called before the first frame update
    void Start()
    {
        findStuffManager = GameObject.FindObjectOfType<FindStuffManager>().GetComponent<FindStuffManager>();


        button2 = GameObject.Find("Button");

        button = gameObject.GetComponent<Button>();
        string sth = gameObject.name+2;
        AfterClickImage = Resources.Load<Sprite>("Image/FindStuff/"+ sth);

        if(button.gameObject.CompareTag("ChangeImage"))
        {
            if(button.gameObject.name == "Lamp")
            {
                button.onClick.AddListener(ButtonMove);
            }
            button.onClick.AddListener(ChangeImage);
        }
        else
            button.onClick.AddListener(ButtonMove);
    }

    void ChangeImage()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.01f;
        gameObject.GetComponent<Image>().sprite = AfterClickImage; //이미지 바꾸기


        if (gameObject.name == "Lamp")
        {
            Destroy(GameObject.Find("ClosedDoor"));
            return;
        }

        if (gameObject.name == "Door")
        {
            button2.transform.GetChild(11).gameObject.SetActive(true);
        }

        findStuffManager.SetChancesLeft(1);
    }

    void ButtonMove()
    {
        gameObject.transform.position = new Vector2(x, y);
        if (gameObject.name == "Lamp")
        {
            return;
        }
        findStuffManager.SetChancesLeft(1);
    }
}
