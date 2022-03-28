using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindStuff : MonoBehaviour
{
    GameObject sign;
    Button button;
    FindStuffManager findStuffManager;

    // Start is called before the first frame update
    void Start()
    {
        findStuffManager = GameObject.FindObjectOfType<FindStuffManager>().GetComponent<FindStuffManager>();

        sign = GameObject.Find("UI" + gameObject.name );
        button = GetComponent<Button>();
        button.onClick.AddListener(DestroyAndColorChange);
    }

    void DestroyAndColorChange()
    {
        gameObject.SetActive(false);
        sign.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        findStuffManager.SetFindStuffCount(1);
    }
}
