using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfTigger : MonoBehaviour
{
    private GameObject mainStorage;
    private GameObject backGround;
    private GameObject storage;
    private GameObject storageUI;

    private int storageIndex;

    private void Start()
    {
        mainStorage = GameObject.FindGameObjectWithTag("MainStorage");
        backGround = GameObject.FindGameObjectWithTag("BackGround");
        storage = GameObject.Find("Storage");
        storageUI = storage.transform.GetChild(3).gameObject;
    }
    

    //해당 storageIndex 값에 따라 선반 활성화
    public void ShowShelf(Shelf shelf)
    {
        //backGround.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);  // 배경 이미지 선반을 강조하도록 약간 그림자처럼 색상변경
        mainStorage.SetActive(false);  // mainStorage(솥이 있는 창) 비활성화 
        storageUI.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            storageUI.transform.GetChild(i).gameObject.SetActive(true);
        }

        if (shelf.btn.CompareTag("1"))  // 버튼 태그가 1이면 storage1 활성화 
        {
            storage.transform.GetChild(0).gameObject.SetActive(true);
            storageUI.transform.GetChild(1).gameObject.SetActive(false);
            storageIndex = 0;
        }
        else if (shelf.btn.CompareTag("2"))  // 버튼 태그가 1이면 storage2 활성화 
        {
            storage.transform.GetChild(1).gameObject.SetActive(true);
            storageIndex = 1;
        }
        else if (shelf.btn.CompareTag("3"))  // 버튼 태그가 1이면 storage3 활성화 
        {
            storage.transform.GetChild(2).gameObject.SetActive(true);
            storageUI.transform.GetChild(2).gameObject.SetActive(false);
            storageIndex = 2;
        }
    }

    // 재료를 가져오는 선반 UI비활성화
    public void OnClickCloseShelf()
    {
        //backGround.GetComponent<Image>().color = new Color(1, 1, 1, 1);  // 원래 배경 색상으로 변경
        storageUI.SetActive(false);  // 장바구니 UI 비활성화
        mainStorage.SetActive(true);
        storage.transform.GetChild(storageIndex).gameObject.SetActive(false);  // 현재 켜진 선반 비활성화
    }

    // back, 왼쪽, 오른쪽 버튼 활성화 함수
    public void StorageUI(Shelf shelf)
    {
        if (shelf.btn.name == "Back(ButtonMesh)")  // 버튼 이름이 back버튼이면 선반UI를 닫는다. 
            OnClickCloseShelf();
        else
            IsNext(shelf);
    }

    // storageIndex 증감함수
    public void IsNext(Shelf shelf)
    {
        storage.transform.GetChild(storageIndex).gameObject.SetActive(false); // 현재 선반 비활성화
        if (shelf.btn.name == "LeftButton")  // 버튼이름이 LeftBtn버튼이면 storageIndex 감소
            storageIndex--;
        else                                 // 버튼이름이 RightBtn버튼이면 storageIndex 증가
            storageIndex++;

        NextStorage();
    }

    // 조건 검색후 다음 선반 활성화하는 함수
    private void NextStorage()
    {
        if (storageIndex > 2)  // storageIndex가 2보다 커지면 다시 0으로 만든다.
            storageIndex = 2;
        else if (storageIndex < 0)  // storageIndex가 0보다 작아지면 2로 만든다.
            storageIndex = 0;

        storage.transform.GetChild(storageIndex).gameObject.SetActive(true); // 선반 활성화


        for (int i = 0; i < 3; i++)
        {
            storageUI.transform.GetChild(i).gameObject.SetActive(true);
        }

        if(storageIndex == 0)
            storageUI.transform.GetChild(1).gameObject.SetActive(false);
        else if(storageIndex == 2)
            storageUI.transform.GetChild(2).gameObject.SetActive(false);
    }
}
