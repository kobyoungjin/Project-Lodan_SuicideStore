using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    private GameObject bar;
    private GameObject ingrePrefab;
    public List<Ingredient> ingredients;

    private void Start()
    {
        bar = GameObject.Find("ItemBar(Panel)");
        ingrePrefab = Resources.Load<GameObject>("SlotPrefabs/Ingredient (Image)");
    }  

    public void AddingSlotBar(Ingredient image)
    {
        if (bar.transform.childCount < 5)
        {
            GameObject instance = Instantiate(ingrePrefab);
            Image prefabImage = instance.GetComponent<Image>();
            prefabImage.sprite = image.ingredientImage.sprite;
            
            instance.transform.SetParent(bar.transform);
        }
    }

    public void RemovingSlotBar(Ingredient image)
    {
        ingredients.Remove(image);
    }
}
