using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class IngreExplainBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject explainObj;
    Transform cursorPoint;
    bool isActive = false;
    bool item = true;
    GameObject bar;
    TextMeshProUGUI explainText;

    private void Start()
    {
        explainObj = GameObject.Find("MakeRoom Canvas").transform.Find("IngreText").gameObject;
        bar = GameObject.Find("ItemBar(Panel)");
        cursorPoint = explainObj.transform;
        explainText = explainObj.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        MouseMoving();
    }

    private void MouseMoving()
    {
        cursorPoint.localPosition = new Vector2(Input.mousePosition.x - (Screen.width / 2) + 8,
                                                Input.mousePosition.y - (Screen.height / 2) + 1);
    }

    public void ShowExplain(PointerEventData eventData)
    {
        if(eventData.pointerEnter.gameObject.name == "kettle(Button)")
        {
            explainText.text = "클릭하여 물약만들기";
            return;
        }
        explainText.text = gameObject.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerEnter.gameObject.name == "kettle(Button)" && bar.transform.childCount != 5)
        {
            return;
        }

        explainObj.SetActive(true);
        ShowExplain(eventData);

        StartCoroutine("Timer", 3.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        explainObj.SetActive(false);
        explainText.text = "";
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        explainObj.SetActive(false);
        explainText.text = null;
    }
}
