using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    public Button btn;
    private GameObject mainStorage;
    private GameObject storage;
    private GameObject storageUI;

    void Start()
    {
        mainStorage = GameObject.FindGameObjectWithTag("MainStorage");
        storage = GameObject.Find("Storage");
        storageUI = storage.transform.GetChild(3).gameObject;

        btn = gameObject.GetComponent<Button>();

        btn.onClick.AddListener(ShowShelf);
    }

    private void ShowShelf()
    {
        int currentShelf = btn.gameObject.transform.GetSiblingIndex();

        if (btn.transform.parent.gameObject.CompareTag("StorageUI"))
        {
            int nextShelf = btn.gameObject.transform.GetSiblingIndex();
            Debug.Log("전" + nextShelf);
            storage.transform.GetChild(nextShelf).gameObject.SetActive(false); // 현재 선반 비활성화
            if (btn.name == "Back(ButtonMesh)")  // 버튼 이름이 back버튼이면 선반UI를 닫는다.
            {
                InitShelf();
                return;
            }

            if (btn.name == "RightButton")
                storage.transform.GetChild(nextShelf + 1).gameObject.SetActive(true); // 선반 활성화
            else
                storage.transform.GetChild(nextShelf - 1).gameObject.SetActive(true); // 선반 활성화
        }
    }

    // 선반 초기화 함수
    private void InitShelf()
    {
        for (int i = 0; i < mainStorage.transform.childCount; i++)
        {
            mainStorage.transform.GetChild(i).gameObject.SetActive(true);  // mainStorage(솥이 있는 창) 활성화 
        }

        for (int i = 0; i < storageUI.transform.childCount; i++)
        {
            storageUI.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 0; i < storage.transform.childCount; i++)
        {
            storage.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
