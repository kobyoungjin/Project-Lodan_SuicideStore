using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    private IngredientSlot slotBar;
    public Image ingredientImage;
    private Button btn;

    void Start()
    {
        slotBar = FindObjectOfType<IngredientSlot>().transform.GetComponentInParent<IngredientSlot>();

        ingredientImage = GetComponent<Image>();
        ingredientImage.alphaHitTestMinimumThreshold = 0.1f;
        btn = GetComponent<Button>();
      
        if (btn == null)
            btn = GetComponentInChildren<Button>();

        if(btn.gameObject.CompareTag("delete"))
            btn.onClick.AddListener(DeleteIngredient);
        else
            btn.onClick.AddListener(AddIngredient);
    }

    public void AddIngredient()
    {
        slotBar.AddingSlotBar(this);
    }

    public void DeleteIngredient()
    {
        slotBar.RemovingSlotBar(this);
        Destroy(gameObject);
    }
}