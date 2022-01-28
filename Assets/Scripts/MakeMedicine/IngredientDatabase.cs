using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    List<string> ingredientData = new List<string>();
    List<IngredientData> ingredientDic = new List<IngredientData>();
    IngredientParser theParser;

    void Awake()
    {
        theParser = GetComponent<IngredientParser>();
    }

    public void SaveData(TextAsset csvFile)
    {
        IngredientData[] ingredients = theParser.Parse(csvFile);

        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredientDic.Add(ingredients[i]);
        }
    }

    public List<IngredientData> GetIngredientList()
    {
        return ingredientDic;
    }

    public List<string> GetIngredientTypeList()
    {
        return theParser.GetEmotionType();
    }
}
