using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IllustratedBook : MonoBehaviour
{
    Button btn;
    GameObject detailBook;
    Transform canvas;
    GameObject people1;
    GameObject people2;
    List<Sprite> characterImageList;
    List<string> addFrameCharacter;

    void Start()
    {
        btn = GetComponent<Button>();
        characterImageList = GameManager.Instance.GetCharacterData();
        addFrameCharacter = GameManager.Instance.GetAddFrameCharacter();
        detailBook = GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(3).gameObject;
        canvas = GameObject.Find("IllustratedBook(Canvas)").transform;
        people1 = canvas.GetChild(1).gameObject;
        people2 = canvas.GetChild(2).gameObject;

        for (int i = 0; i < addFrameCharacter.Count; i++)
        {
            AddIllustrateCharacter(addFrameCharacter[i]);
        }

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
        people2.SetActive(false);
        people1.SetActive(true);
    }

    void Right()
    {
        people2.SetActive(true);
        people1.SetActive(false);
    }

    // 클릭한 데이터를 찾는 함수
    void FindData()
    {
        detailBook.SetActive(true);
        SetBackInteract(false);
        SetArrowInteract(false);

        Image image = detailBook.transform.Find("Character(Image)").GetComponent<Image>();
        TextMeshProUGUI name = detailBook.transform.Find("NameText(TMP)").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI explain = detailBook.transform.Find("ExplainText(TMP)").GetComponent<TextMeshProUGUI>();

        // 현재 오브젝트 이미지 스프라이트 이름이 empty이미지면 공란으로 불러오기
        if (GetComponent<Image>().sprite.name == gameObject.name + "empty")
        {
            for (int i = 0; i < characterImageList.Count; i++)
            {
                if (characterImageList[i].name == this.gameObject.name)  // 캐릭터 이미지 리스트에서 parentName이 있으면
                {
                    image.sprite = characterImageList[i];
                    name.text = "";
                    explain.text = "";
                    image.color = new Color(0, 0, 0, 255);
                    detailBook.transform.GetChild(4).gameObject.SetActive(false);

                    return;
                }
            }
            Debug.Log("해당 스프라이트가 없습니다");
            return;
        }
        else
        {
            for (int i = 0; i < characterImageList.Count; i++)
            {
                if (characterImageList[i].name == this.gameObject.name)  // 캐릭터 이미지 리스트에서 parentName이 있으면
                {
                    image.sprite = characterImageList[i];
                    name.text = characterImageList[i].name;
                    explain.text = GameManager.Instance.FindPeopleText(characterImageList[i].name, "explain");

                    image.color = new Color(255, 255, 255, 255);

                    detailBook.transform.GetChild(4).gameObject.SetActive(true);
                    return;
                }
            }
            Debug.Log("해당 스프라이트가 없습니다");
            return;
        }
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
        Button arrow = transform.parent.GetChild(6).GetComponent<Button>();
        arrow.interactable = isActive;
    }

    // 이야기가 끝났을때 액자에 인물을 추가하는 함수
    public void AddIllustrateCharacter(string characterName)
    {
        List<Sprite> characterImageList = GameManager.Instance.GetFrameCharacterData();
        Transform canvas = GameObject.Find("IllustratedBook(Canvas)").transform;
        GameObject people1 = canvas.GetChild(1).gameObject;
        GameObject people2 = canvas.GetChild(2).gameObject;

        if (characterName == null || characterName == "") return;

        Sprite illustImage = null;
        
        for (int i = 0; i < characterImageList.Count; i++)
        {
            if (characterImageList[i].name == characterName)
            {
                illustImage = characterImageList[i];
                break;
            }
        }

        for (int i = 0; i < people1.transform.childCount; i++)
        {
            if (people1.transform.GetChild(i).gameObject.name == characterName)
            {
                people1.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = illustImage;
                return;
            }
        }

        for (int i = 0; i < people2.transform.childCount; i++)
        {
            if (people2.transform.GetChild(i).gameObject.name == characterName)
            {
                people2.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = illustImage;
                return;
            }
        }

        Debug.Log("AddIllustrateCharacter함수의 characterName을 찾을수 없음");
        return;
    }
}
