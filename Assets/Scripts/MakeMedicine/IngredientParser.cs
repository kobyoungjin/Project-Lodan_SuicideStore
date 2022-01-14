using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientParser : MonoBehaviour
{
    public IngredientData[] Parse(TextAsset csvData) // 파서
    {
        List<IngredientData> IngredientList = new List<IngredientData>(); //대사 리스트 생성

        string[] data = csvData.text.Split(new char[] { '\n' });  // 엔터 단위로 끊어서 저장

        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,별로 끊어서 저장
            IngredientData ingredientData = new IngredientData(); // 재료 리스트 생성

            ingredientData.key = row[0];  // key값 저장
            int.TryParse(row[1], out ingredientData.value);  // string변수를 int로 변환 value값
            IngredientList.Add(ingredientData);
        }
        return IngredientList.ToArray();   // ingredient 리스트 형태로 반환
    }

    internal string Parse(object storyIngredientData)
    {
        throw new NotImplementedException();
    }
}