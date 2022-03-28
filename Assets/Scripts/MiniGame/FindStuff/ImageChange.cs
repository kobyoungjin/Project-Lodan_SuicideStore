using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Sprite AfterClickImage;//바꾼 이미지
    Button button;

    private bool isActive = true;
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
        string sth = gameObject.name + 2;
        AfterClickImage = Resources.Load<Sprite>("MiniGame/FindStuff/"+ sth);
        
        if (button.gameObject.CompareTag("ChangeImage"))
        {
            if(button.gameObject.name == "Lamp")
            {
                button.onClick.AddListener(ButtonMove);
            }
            button.onClick.AddListener(()=> ChangeImage(gameObject));
        }
        else
            button.onClick.AddListener(ButtonMove);
    }

    void ChangeImage(GameObject obj)
    {
        if (!isActive)
            return;

        int num = findStuffManager.GetChancesLeft();
        if (num == 0)
        {
            findStuffManager.ActiveRetryButton();
            return;
        }

        obj.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.01f;
        obj.GetComponent<Image>().sprite = AfterClickImage; //이미지 바꾸기
        
        if (obj.name == "Lamp")
        {
            button2.transform.GetChild(12).gameObject.SetActive(false);
            return;
        }

        if (obj.name == "Door")
        {
            button2.transform.GetChild(11).gameObject.SetActive(true);
        }

        findStuffManager.SetChancesLeft(1);

        isActive = false;
    }

    void ButtonMove()
    {
        if (!isActive)
            return;

        int num = findStuffManager.GetChancesLeft();
        if (num == 0)
        {
            findStuffManager.ActiveRetryButton();
            return;
        }

        gameObject.transform.position = new Vector2(x, y);
        if (gameObject.name == "Lamp")
        {
            return;
        }
        findStuffManager.SetChancesLeft(1);

        isActive = false;
    }
}
