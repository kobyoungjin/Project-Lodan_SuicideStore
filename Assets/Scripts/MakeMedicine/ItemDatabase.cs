using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    GameObject clickObject;
    private int slotCnt = 0;
    public Image[] itemSlotsUI;
    public Transform slotHolder;
    Image image;

    private void Awake()
    {
        instance = this;
        itemSlotsUI = slotHolder.GetComponentsInChildren<Image>();
    }

    List<Item> itemDB = new List<Item>();

    // 버튼 클릭시 클릭한 오브젝트 clickObject 정보저장
    public void ClickBtn()
    {
        clickObject = EventSystem.current.currentSelectedGameObject;
        ShowItemListUI();
    }

    //장바구니에 저장한 재료를 보여주는 함수
    private void ShowItemListUI()
    {
        if (slotCnt >= itemSlotsUI.Length) // 슬롯이 itemSlotsUI의 길이를 넘으면 return
        {
            slotCnt = itemSlotsUI.Length;
            return;
        }
        
        itemSlotsUI[slotCnt].GetComponent<Image>().sprite 
                            = clickObject.GetComponent<Image>().sprite;  // 클릭한 재료 장바구니에 UI 출력 
        itemSlotsUI[slotCnt] = clickObject.GetComponent<Image>();   //클릭한 재료 정보 입력
        slotCnt++;
    }

    // x버튼 클릭시 해당 재료UI삭제 후 한칸씩 민다.
    public void DeleteItemList()
    {
        if (!(slotCnt < 0))
        {
           

            for (int i = slotCnt; i < itemSlotsUI.Length; i++)
            {
                itemSlotsUI[slotCnt] = itemSlotsUI[slotCnt + 1];
            }
        }
    }

    // ClickBtn에서 clickObject 저장한걸 리스트에 저장
    void AddListItem()
    {
        Item item = new Item();
        item.itemName = clickObject.name;
        item.itemImage = clickObject.GetComponent<Image>();

        itemDB.Add(item);
    }

    
}
