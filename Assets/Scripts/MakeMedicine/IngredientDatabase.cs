using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    List<string> ingredientData = new List<string>();
    List<IngredientData> ingredientDic = new List<IngredientData>();
    List<Answer> answerDic = new List<Answer>();
    IngredientParser theParser;
    AnswerParser answerParser;
    void Awake()
    {
        theParser = GetComponent<IngredientParser>();
        answerParser = GetComponent<AnswerParser>();
    }

    public void SaveData(TextAsset csvFile)
    {
        if(csvFile.name == "Ingredient")
        {
            IngredientData[] ingredients = theParser.Parse(csvFile);

            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredientDic.Add(ingredients[i]);
            }
        }
        else
        {
            Answer[] answers = answerParser.Parse(csvFile);

            for (int i = 0; i < answers.Length; i++)
            {
                answerDic.Add(answers[i]);
            }
        }
    }

    public List<IngredientData> GetIngredientList()
    {
        return ingredientDic;
    }

    public List<Answer> GetAnswerList()
    {
        return answerDic;
    }

    public List<string> GetIngredientTypeList()
    {
        return theParser.GetEmotionType();
    }
}
