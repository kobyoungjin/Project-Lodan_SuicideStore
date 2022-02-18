using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    private GameObject bar;
    private GameObject backgroundBar;
    private GameObject ingrePrefab;
    Kettle kettle;
    public int score;

    GameObject storage;
    List<GameObject> leftStorage = new List<GameObject>();
    List<GameObject> middleStorage = new List<GameObject>();
    List<GameObject> rightStorage = new List<GameObject>();

    private void Start()
    {
        bar = GameObject.Find("ItemBar(Panel)");
        backgroundBar = GameObject.Find("BackGroundItemBar(Panel)");
        ingrePrefab = Resources.Load<GameObject>("MakingRoom/Prefab/Ingredient(Prefab)");  // 프리탭 이미지
        kettle = GameObject.FindObjectOfType<Kettle>().GetComponent<Kettle>();

        storage = GameObject.Find("Storage");

        for (int i = 0; i < storage.transform.GetChild(0).childCount; i++)
        {
            leftStorage.Add(storage.transform.GetChild(0).GetChild(i).gameObject);
        }

        for (int i = 0; i < storage.transform.GetChild(1).childCount; i++)
        {
            middleStorage.Add(storage.transform.GetChild(1).GetChild(i).gameObject);
        }

        for (int i = 0; i < storage.transform.GetChild(2).childCount; i++)
        {
            rightStorage.Add(storage.transform.GetChild(2).GetChild(i).gameObject);
        }
    }

    //장바구니에 재료 추가하는 함수
    public void AddingSlotBar(Ingredient image)
    {
        if (bar.transform.childCount < 5)  // 장바구니에 재료가 5개 이하일때만
        {
            image.ingredientImage.alphaHitTestMinimumThreshold = 0.01f;

            GameObject instance = Instantiate(ingrePrefab);
            instance.name = image.name;
            Image prefabImage = instance.transform.GetChild(0).GetComponent<Image>();
            prefabImage.sprite = image.ingredientImage.sprite;  // 클릭한 재료 이미지 변환

            instance.transform.SetParent(bar.transform);  // 장바구니 UI에 보이게
           
            return;
        }
    }

    // 장바구니에 재료 삭제하는 함수
    public void DeleteSlotBar(string name)
    {
        for (int i = 0; i < leftStorage.Count; i++)
        {
            if (leftStorage[i].name == name)
            {
                storage.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
                return;
            }
        }
        for (int i = 0; i < middleStorage.Count; i++)
        {
            if (middleStorage[i].name == name)
            {
                storage.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                return;
            }
        }
        for (int i = 0; i < rightStorage.Count; i++)
        {
            if (rightStorage[i].name == name)
            {
                storage.transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
                return;
            }
        }

        Debug.Log("GetItemIndex 오류");
        return;
    }

    // 장바구니에 들어있는 개수를 파악하는 함수
    public int GetBarChildCount()
    {
        return bar.transform.childCount;
    }
    
    public GameObject GetBarObj()
    {
        return bar;
    }
}
