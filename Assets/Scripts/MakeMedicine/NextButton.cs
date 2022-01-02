using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    GameObject harisonScene;
    GameObject makeMedicineScene;
    GameObject nextBtn;
    Button btn;
    DetermineBtn determine;
    Ingredient ingredient;

    void Start()
    {
        harisonScene = GameObject.Find("Harison Canvas").transform.GetChild(0).gameObject;
        makeMedicineScene = GameObject.Find("MakeRoom Canvas").transform.GetChild(0).gameObject;
       
        determine = GameObject.FindObjectOfType<DetermineBtn>().GetComponent<DetermineBtn>();
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener(NextScene);
    }

    // 물약띄운후 대화씬으로 넘어가게하는 버튼함수
    public void NextScene()
    {
        if(gameObject.name == "RetryButton")  // 만약에 확인버튼대신 Retry버튼이면 리트라이 오브젝트 비활성화
        {
            determine.GetRetry(false);
            return;
        }
        nextBtn = GameObject.Find("FinishedPotion").transform.GetChild(2).gameObject;
        ingredient = GameObject.FindObjectOfType<Ingredient>().GetComponent<Ingredient>();

        harisonScene.gameObject.SetActive(true);
        makeMedicineScene.gameObject.SetActive(false);
        determine.SetActivePotion(false);
        ingredient.AllDelete();
    }
}
