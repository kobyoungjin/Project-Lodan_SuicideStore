using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    GameObject owner;   //주인장
    GameObject customer;  //해리슨
    
    List<DialogueData> dialogue = new List<DialogueData>();
    List<Sprite> imageData = new List<Sprite>();
    ShowDialogue showDialogue;

    void Awake()
    {
        customer = GameObject.FindGameObjectWithTag("Customer");

        Color color = customer.GetComponent<Image>().color;
        color.a = 0.0f;
    }

    private void Start()
    {
        showDialogue = GameObject.FindObjectOfType<ShowDialogue>().GetComponent<ShowDialogue>();
        dialogue = showDialogue.GetCurrentDialogue();
        owner = GameObject.FindGameObjectWithTag("주인장");
    }

    // tag로 캐릭터 UI 투명도, 색 조절
    public void ChangeColor(int i) 
    {
        if (dialogue[i].name == owner.tag)
        {
            owner.GetComponent<Image>().color = new Color(1, 1, 1, 1);  
            customer.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1);  // 손님 캐릭터 흑백화 
        }
        else
        {
            owner.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1);   // 주인장 캐릭터 흑백화 
            customer.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }

    public void ChooseCharacter(string stateName)
    {
        imageData = GameManager.Instance.GetCharacterData();
        Image customerImage = customer.GetComponent<Image>();
        for (int i = 0; i < imageData.Count; i++)
        {
            if(imageData[i].name == stateName)
            {
                customerImage.sprite = imageData[i];
                Color color = customerImage.color;
                color.a = 1.0f;
                customerImage.SetNativeSize();
                return;
            }
        }

        customerImage.sprite = null;
        Debug.Log("캐릭터 이미지가 없습니다.");
        return;
    }
}
