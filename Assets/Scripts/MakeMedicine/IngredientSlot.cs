using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    private GameObject bar;
    private GameObject backgroundBar;
    private GameObject ingrePrefab;
    private IngredientDatabase data;
    public int score;

    private void Start()
    {
        bar = GameObject.Find("ItemBar(Panel)");
        backgroundBar = GameObject.Find("BackGroundItemBar(Panel)");
        ingrePrefab = Resources.Load<GameObject>("SlotPrefabs/Ingredient(Prefab)");  // 프리탭 이미지
        data = GameObject.FindObjectOfType<IngredientDatabase>().GetComponent<IngredientDatabase>();
    }  

    //장바구니에 재료 추가하는 함수
    public void AddingSlotBar(Ingredient image)
    {
        if (bar.transform.childCount < 5)  // 장바구니에 재료가 5개 이하일때만
        {
            image.ingredientImage.alphaHitTestMinimumThreshold = 0.01f;

            GameObject instance = Instantiate(ingrePrefab);
            Image prefabImage = instance.transform.GetChild(0).GetComponent<Image>();
            prefabImage.sprite = image.ingredientImage.sprite;  // 클릭한 재료 이미지 변환


            instance.transform.SetParent(bar.transform);  // 장바구니 UI에 보이게

            //int value = data.GetIngredientData(image.ingredientImage.gameObject.name.ToString());  // 장바구니에 추가되면 해당 점수가 더해진다.
            //score += value;
        }
    }
    

    // 최종 점수 반환 함수
    public int GetScore()
    {
        return score;
    }
}
