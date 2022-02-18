using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    private IngredientSlot slotBar;
    private Button btn;
    public Image ingredientImage;
    IngreExplainBar explainBar;

    void Start()
    {
        slotBar = FindObjectOfType<IngredientSlot>().transform.GetComponentInParent<IngredientSlot>();
        explainBar = FindObjectOfType<IngreExplainBar>().transform.GetComponentInParent<IngreExplainBar>();
        ingredientImage = GetComponent<Image>();
        btn = GetComponent<Button>();
      
        if (btn == null)  // 버튼이 없으면 오브젝트의 자식에서 버튼 컴퍼넌트를 찾는다.
            btn = gameObject.transform.GetComponentInChildren<Button>();

        if(btn.gameObject.CompareTag("delete"))  // 버튼tag가 delete면 장바구니에 저장된 오브젝트를 삭제하는 함수를 불러온다.
            btn.onClick.AddListener(DeleteIngredient);
        else  // 장바구니에 재료를 더하는 함수를 불러온다.
            btn.onClick.AddListener(AddIngredient);
    }

    // 장바구니에 재료를 추가하는 함수
    public void AddIngredient()
    {
        if (slotBar.GetBarChildCount() == 5)
            return;

        slotBar.AddingSlotBar(this);
        gameObject.SetActive(false);
    }

    // 장바구니에 재료를 삭제하는 함수
    public void DeleteIngredient()
    {
        if (slotBar.GetBarChildCount() < 0)
            return;

        GameObject deleteItem = this.transform.parent.gameObject;
        slotBar.DeleteSlotBar(deleteItem.name);
        Destroy(deleteItem);
    }
}