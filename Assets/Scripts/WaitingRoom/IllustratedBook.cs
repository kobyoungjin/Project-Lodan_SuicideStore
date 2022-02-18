using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IllustratedBook : MonoBehaviour
{
    Button btn;
    GameObject detailBook;
    Transform canvas;

    void Start()
    {
        btn = GetComponent<Button>();
        detailBook = GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(3).gameObject;
        canvas = GameObject.Find("IllustratedBook(Canvas)").transform;

        if (btn.name == "Left(Button)")  // 왼쪽 화살표
        {
            btn.onClick.AddListener(Left);
        }
        else if(btn.name == "Right(Button)")  // 오른쪽 화살표
        {
            btn.onClick.AddListener(Right);
        }
        else  // 아니면 클릭한 액자의 데이터 찾기
            btn.onClick.AddListener(FindData);
    }
    
    void Left()
    {
        canvas.GetChild(2).gameObject.SetActive(false);
        canvas.GetChild(1).gameObject.SetActive(true);
    }

    void Right()
    {
        canvas.GetChild(2).gameObject.SetActive(true);
        canvas.GetChild(1).gameObject.SetActive(false);
    }

    // 클릭한 데이터를 찾는 함수
    void FindData()
    {
        string parentName = transform.parent.name;
        Debug.Log(parentName);
        List<Sprite> characterImageList = GameManager.Instance.GetCharacterData();

        detailBook.SetActive(true);
        SetBackInteract(false);
        SetArrowInteract(false);

        for (int i = 0; i < characterImageList.Count; i++)
        {
            if(characterImageList[i].name == parentName)  // 캐릭터 이미지 리스트에서 parentName이 있으면
            {
                Image image = detailBook.transform.Find("Character(Image)").GetComponent<Image>();
                image.sprite = characterImageList[i];

                TextMeshProUGUI name = detailBook.transform.Find("NameText(TMP)").GetComponent<TextMeshProUGUI>();
                name.text = characterImageList[i].name;

                //TextMeshProUGUI explain = detailBook.transform.Find("ExplainText(TMP)").GetComponent<TextMeshProUGUI>();
                //explain.text = characterImageList[i].name;
                return;
            }
        }
        Debug.Log("해당 스프라이트가 없습니다");
    }

    // Back(Button)의 bool 변환 함수
    public void SetBackInteract(bool isActive)
    {
        Button back = canvas.GetChild(4).GetComponent<Button>();
        back.interactable = isActive;
    }

    // 화살표 bool 변환 함수
    public void SetArrowInteract(bool isActive)
    {
        Button arrow = transform.parent.transform.parent.GetChild(6).GetComponent<Button>();
        arrow.interactable = isActive;
    }
}
