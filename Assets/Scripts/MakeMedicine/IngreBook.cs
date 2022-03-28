using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngreBook : MonoBehaviour
{
    Button btn;
    GameObject makeRoom;
    GameObject storageUI;

    private void Start()
    {
        btn = GetComponent<Button>();
        makeRoom = GameObject.Find("MakeRoom Canvas");
        storageUI = GameObject.Find("Storage").transform.GetChild(3).gameObject;
        btn.onClick.AddListener(Active);
    }

    // ingredient도감 여는 함수
    void Active()
    {
        makeRoom.transform.GetChild(6).gameObject.SetActive(true);
        Setinteract(false);
        for (int i = 0; i < storageUI.transform.childCount; i++)
        {
            storageUI.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

    }

    public void Setinteract(bool act)
    {
        for (int i = 0; i < 3; i++)
        {
            makeRoom.transform.GetChild(1).transform.GetChild(i).GetComponent<Button>().interactable = act;
        }
    }
}
