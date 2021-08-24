using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientParsor : MonoBehaviour
{
    public IngredientData[] Parse(string storyIngredientData) // �ļ�
    {
        List<IngredientData> IngredientList = new List<IngredientData>(); //��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>("IngredientData/" + storyIngredientData);

        string[] data = csvData.text.Split(new char[] { '\n' });  // ���� ������ ��� ����

        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,���� ��� ����
            IngredientData ingredientData = new IngredientData(); // ��� ����Ʈ ����

            ingredientData.key = row[0];  // key�� ����
            int.TryParse(row[1], out ingredientData.value);  // string������ int�� ��ȯ value��
            IngredientList.Add(ingredientData);
        }
        return IngredientList.ToArray();   // ingredient ����Ʈ ���·� ��ȯ
    }

    internal string Parse(object storyIngredientData)
    {
        throw new NotImplementedException();
    }
}