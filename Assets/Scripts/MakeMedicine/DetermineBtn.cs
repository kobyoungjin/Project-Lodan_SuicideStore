using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetermineBtn : MonoBehaviour
{
    GameObject potion;
    GameObject potionName;
    GameObject instance;
    GameObject Retry;
    IngredientSlot ingredientSlot;
    Button btn;

    private void Start()
    {
        potion = GameObject.Find("MakeRoom").transform.Find("FinishedPotion").gameObject;
        potionName = potion.transform.GetChild(1).gameObject;
        Retry = GameObject.Find("MakeRoom").transform.Find("Retry").gameObject;
        ingredientSlot = GameObject.FindObjectOfType<IngredientSlot>().GetComponent<IngredientSlot>();
        btn = GetComponent<Button>();

        btn.onClick.AddListener(Satisfied);
    }

    // 약물 만족도 함수
    public void Satisfied()
    {
        int SatisfiedScore = ingredientSlot.GetScore();

        if (SatisfiedScore == 0)  // 만족 score가 0이면 장바구니에 재료가 없다고 판정함
        {
            GetRetry(true);  // 리트라이 함수 불러옴
        }
        else if(SatisfiedScore == 100)  // 만족 score가 100이면 완벽한 물약 생성.  
        {
            potion.transform.gameObject.SetActive(true);  // 완성 포션 활성화

            GameObject perfectPotion = Resources.Load<GameObject>("SlotPrefabs/완벽한 독약");  // 프리탭 이미지
            instance = Instantiate(perfectPotion);
            potion.transform.GetChild(0).GetComponent<Image>().sprite = instance.GetComponent<Image>().sprite;

            potionName.GetComponentInChildren<TextMeshProUGUI>().text = instance.GetComponent<Image>().sprite.name;
        }
        else if(SatisfiedScore > 60 || SatisfiedScore < 100)  // 만족score가 60~100사이면 미미한 물약 생성
        {
            potion.transform.gameObject.SetActive(true);

            GameObject nomalPotion = Resources.Load<GameObject>("SlotPrefabs/미미한 독약");  // 프리탭 이미지
            instance = Instantiate(nomalPotion);
            potion.transform.GetChild(0).GetComponent<Image>().sprite = instance.GetComponent<Image>().sprite;

            potionName.GetComponentInChildren<TextMeshProUGUI>().text = instance.GetComponent<Image>().sprite.name;
            
        }
        else  // 그이외는 쓸모없는 물약 생성
        {

        }
    }

    // 완성한 오브젝트 이미지 뜨우는 함수
    public void SetActivePotion(bool isAct)  
    {
       potion.transform.gameObject.SetActive(isAct);
    }
    // 리트라이 오브젝트 띄우는 함수
    public void GetRetry(bool isAct)
    {
        Retry.gameObject.SetActive(isAct);
    }
}
