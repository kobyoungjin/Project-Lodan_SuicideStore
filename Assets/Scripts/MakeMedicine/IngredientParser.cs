using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientParser : MonoBehaviour
{
    List<string> type = new List<string>();

    public IngredientData[] Parse(TextAsset csvData) // 파서
    {
        List<IngredientData> IngredientList = new List<IngredientData>(); //대사 리스트 생성

        string[] data = csvData.text.Split(new char[] { '\n' });  // 엔터 단위로 끊어서 저장

        for (int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,별로 끊어서 저장
            IngredientData ingredientData = new IngredientData(); // 재료 리스트 생성

            if (row[0] == "분류")
                continue;

            type.Add(row[0]);  // type값 저장
            ingredientData.emotion = row[1];  // 감정 저장
            ingredientData.name = row[2];  // 재료이름 저장
            ingredientData.explain = row[3];  // 재료설명 저장

            IngredientList.Add(ingredientData);
        }
        return IngredientList.ToArray();   // ingredient 리스트 형태로 반환
    }

    public List<string> GetEmotionType()
    {
        return type;
    }

    internal string Parse(object storyIngredientData)
    {
        throw new NotImplementedException();
    }
}