using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackButton : MonoBehaviour
{
    GameObject parent;
    Button btn;

    void Start()
    {
        parent = transform.parent.gameObject;

        btn = GetComponent<Button>();

        btn.onClick.AddListener(ResetData);
    }

    public void ResetData()
    {
        if(parent.name == "DetailBook")
        {
            parent.transform.GetChild(0).GetComponent<Image>().sprite = null;
            parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = null;
        }

        parent.SetActive(false);
    }
}
