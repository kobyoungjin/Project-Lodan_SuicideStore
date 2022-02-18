using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientBook : MonoBehaviour
{
    Button btn1;
    Button btn2;
    int page = 1;

    List<string> type;
    List<IngredientData> ingreAllData;
    Sprite[] ingreSprites;

    private void Start()
    {
        btn1 = transform.GetChild(1).GetComponent<Button>();
        btn2 = transform.GetChild(2).GetComponent<Button>();

        type = GameManager.Instance.GetTypeList();
        ingreAllData = GameManager.Instance.GetIngreAllData();
        ingreSprites = Resources.LoadAll<Sprite>("MakingRoom/Material");

        Page(page);
        ChangeData(page);
            

        btn1.onClick.AddListener(Left);
        btn2.onClick.AddListener(Right);
    }
    
    // ingredientBook 화살표 왼쪽
    void Left()
    {
        page -= 1;

        if (page < 1) page = 1;
        
        Page(page);
        ChangeData(page);
    }

    // ingredientBook 화살표 오른쪽
    void Right()
    {
        page += 1;

        if (page > 5) page = 5;
        
        
        Page(page);
        ChangeData(page);
    }

    // 화살표 클릭시 다음 데이터로 변환
    void ChangeData(int page)
    {
        Transform range;
        int start = 4 * (page - 1);    
        for (int i = start; i < start + 4; i++)
        {
            range = transform.GetChild(0).transform.GetChild(i - start).transform;

            Sprite sprite = FindIngreSprite(ingreAllData[i].name);  
            range.GetChild(1).GetComponent<Image>().sprite = sprite;  // 이미지 변경
            range.GetChild(2).transform.GetComponentInChildren<TextMeshProUGUI>().text = ingreAllData[i].name;  // 이름 변경
            range.GetChild(3).GetComponent<TextMeshProUGUI>().text = type[i];  // 감정 대분류 변경
            range.GetChild(4).GetComponent<TextMeshProUGUI>().text = ingreAllData[i].emotion;  // 세부 감정 변경
            range.GetChild(5).GetComponent<TextMeshProUGUI>().text = ingreAllData[i].explain;  // ingredient 설명 변경
        }
    }

    // 페이지 찾는 함수
    void Page(int page)
    {
        TextMeshProUGUI bookPage = GameObject.Find("IngredientBook(Image)").transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        if (btn1.gameObject.activeSelf == false) btn1.gameObject.SetActive(true);  // 오른쪽 화살표가 꺼져있으면 켜기
        if (btn2.gameObject.activeSelf == false) btn2.gameObject.SetActive(true);  // 왼쪽 화살표가 꺼져있으면 켜기

        if (page == 1) btn1.gameObject.SetActive(false);
        if (page == 5) btn2.gameObject.SetActive(false);

        bookPage.text = page.ToString();
    }

    // ingredient 스프라이트 찾는 함수
    Sprite FindIngreSprite(string name)
    {
        for (int i = 0; i < ingreSprites.Length; i++)
        {
            if(ingreSprites[i].name == name)
            {
                return ingreSprites[i];
            }
        }

        Debug.Log("Sprite null값을 반환합니다.");
        return null;
    }
}
