using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTigger : MonoBehaviour
{
    private int storageIndex;
    public GameObject[] storages;
    private int clickNum = 1;
    private bool rightBtn;
    
    GameObject mainStorage;
    GameObject storageUI;
    GameObject backGround;

    private void Start()
    {
        mainStorage = GameObject.FindGameObjectWithTag("MainStorage").gameObject;
        storageUI = GameObject.FindGameObjectWithTag("Storage").gameObject;
        backGround = GameObject.FindGameObjectWithTag("BackGround").gameObject;

        storageUI.SetActive(false);  // 저장소 버튼UI 비활성화
    }
    
    public void Trigger()  // 클릭할때마다 대사 변경
    { 
        var data = FindObjectOfType<DatabaseManager>();  
        data.ShowText(clickNum);
       
        clickNum++;
    }

    //해당 storageIndex 값에 따라 선반 활성화
    private void ShowShelf()
    {
        backGround.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        mainStorage.SetActive(false);  // mainStorage(솥이 있는 창) 비활성화 
        storageUI.SetActive(true);   // storageIndex가 0이면 선반 UI 활성화

        switch (storageIndex)
        {
            case 0:
                storages[0].SetActive(true);  //storageIndex가 1이면 1번째 선반 활성화
                break;
            case 1:
                storages[1].SetActive(true);  // storageIndex가 2이면 2번째 선반 활성화
                break;
            case 2:
                storages[2].SetActive(true);  // 그 외이면 3번째 선반 활성화
                break;
        }
    }
    
    private void NextStorage()
    {
        if (storageIndex > 2)  // storageIndex가 2이상이 되면 다시 0으로 만든다.
        {
            storageIndex %= 3;
        }
        else if (storageIndex < 0)  // storageIndex가 0보다 작아지면 인덱스를 2로 만든다.
        {
            storageIndex *= -2;
        }

        ShowShelf();
    }

    // 재료를 가져오는 선반 UI비활성화
    public void OnClickCloseShelf()
    {
        backGround.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        storages[storageIndex].SetActive(false);
        storageUI.SetActive(false);
        mainStorage.SetActive(true);
    }

    //왼쪽선반 클릭시 storageIndex = 0 값입력
    public void IsLeftShelf()  
    {
        storageIndex = 0;
        ShowShelf();
    }

    // 가운데선반 클릭시 storageIndex = 1 값입력
    public void IsMiddleShelf()  
    {
        storageIndex = 1;
        ShowShelf();
    }

    // 오른쪽선반 클릭시 storageIndex = 2 값입력
    public void IsRightShelf()  
    {
        storageIndex = 2;
        ShowShelf();
    }

    // 왼쪽인지
    public void IsLeft()
    {
        storages[storageIndex].SetActive(false); // 현재 선반 비활성화
        --storageIndex;
        NextStorage();
    }

    // 오른쪽인지
    public void IsRight()
    {
        storages[storageIndex].SetActive(false);  // 현재 선반 비활성화
        ++storageIndex;
        NextStorage();
    }

}
