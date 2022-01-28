using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    private IngredientSlot slotBar;
    private Button btn;
    private IngredientDatabase data;
    public Image ingredientImage;

    void Start()
    {
        slotBar = FindObjectOfType<IngredientSlot>().transform.GetComponentInParent<IngredientSlot>();
        data = GameObject.FindObjectOfType<IngredientDatabase>().GetComponent<IngredientDatabase>();

        ingredientImage = GetComponent<Image>();
        btn = GetComponent<Button>();
      
        if (btn == null)  // 버튼이 없으면 오브젝트의 자식에서 버튼 컴퍼넌트를 찾는다.
            btn = gameObject.transform.parent.transform.GetChild(1).GetComponent<Button>();

        if(btn.gameObject.CompareTag("delete"))  // 버튼tag가 delete면 장바구니에 저장된 오브젝트를 삭제하는 함수를 불러온다.
            btn.onClick.AddListener(DeleteIngredient);
        else  // 장바구니에 재료를 더하는 함수를 불러온다.
            btn.onClick.AddListener(AddIngredient);
    }

    // 장바구니에 재료를 추가하는 함수
    public void AddIngredient()
    {
        slotBar.AddingSlotBar(this);
    }

    // 장바구니에 재료를 삭제하는 함수
    public void DeleteIngredient()
    {
        //int value = data.GetIngredientData(gameObject.GetComponent<Image>().sprite.name);
        //slotBar.score -= value;

        Destroy(this.transform.parent.gameObject);
    }
}