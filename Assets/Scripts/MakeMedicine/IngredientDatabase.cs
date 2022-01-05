using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    private static IngredientDatabase instance;

    [SerializeField] string storyIngredientData;  // 여기서 모든 데이터 관리해야할듯?
    Dictionary<string, int> ingredientDic = new Dictionary<string, int>();

    public static bool isFinish = false;  // 저장이 끝났는지 판별

    void Awake()
    {
        if (instance == null)  // IngredientDatabase 인스턴스 상태가 아니면
        {
            instance = this;
            IngredientParsor theParser = GetComponent<IngredientParsor>();
            IngredientData[] ingredients = theParser.Parse(storyIngredientData);
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredientDic.Add(ingredients[i].key, ingredients[i].value);  // 딕션어리에 key값, value값 저장
            }
            isFinish = true;
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
            Debug.Log("잘못된 재료 이름입니다");  // 맞는 이름이 없으면 디버그 로그띄우기

        return value;
    }
}
