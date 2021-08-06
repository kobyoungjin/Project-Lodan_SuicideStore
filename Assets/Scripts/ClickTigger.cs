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
    private bool isBack;
    
    GameObject mainStorage;
    GameObject storageUI;

    private void Start()
    {
        mainStorage = GameObject.FindGameObjectWithTag("MainStorage").gameObject;
        storageUI = GameObject.FindGameObjectWithTag("Storage").gameObject;

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
    
    // 재료를 가져오는 선반 UI비활성화
    public void OnClickCloseShelf() 
    {
        storages[storageIndex].SetActive(false);        
        storageUI.SetActive(false);
        mainStorage.SetActive(true);
    }

    private void NextStorage()
    {
       if(storageIndex > 3)

        if (rightBtn)
        {
            storages[storageIndex - 1].SetActive(false);
            storages[storageIndex].SetActive(true);
        }
        else
        { 
            storages[storageIndex + 1].SetActive(false);
            storages[storageIndex].SetActive(true);
        }
    }

    public void IsLeftShelf()  // 왼쪽선반 클릭시 storageIndex = 0 값입력
    {
        storageIndex = 0;
        ShowShelf();
    }
    public void IsMiddleShelf()  // 가운데선반 클릭시 storageIndex = 1 값입력
    {
        storageIndex = 1;
        ShowShelf();
    }
    public void IsRightShelf()  // 오른쪽선반 클릭시 storageIndex = 2 값입력
    {
        storageIndex = 2;
        ShowShelf();
    }
    public void IsLeft()
    {
        storageIndex--;
        NextStorage();
    }
    public void IsRight()
    {
        storageIndex++;
        NextStorage();
    }

}
