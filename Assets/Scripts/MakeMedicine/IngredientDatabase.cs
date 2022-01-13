using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    Dictionary<string, int> ingredientDic = new Dictionary<string, int>();
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
            ingredientDic.Add(ingredients[i].key, ingredients[i].value);  // 딕션어리에 key값, value값 저장
        }
    }

    // 딕션어리에 저장된 key의 value값을 주는 함수
    public int GetIngredientData(string name)
    {
        int value = 0; 

        if (ingredientDic.ContainsKey(name))  // 딕션어리에 해당이름이 있으면
        {
            value = ingredientDic[name];  // 해당 이름의 value값 저장
        }
        else
        {
            Debug.Log(name);
            Debug.Log("잘못된 재료 이름입니다");  // 맞는 이름이 없으면 디버그 로그띄우기
        }
            

        return value;
    }
}
