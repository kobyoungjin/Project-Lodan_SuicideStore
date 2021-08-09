using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    DatabaseManager data;

    GameObject owner;   //주인장
    GameObject farmer;  //해리슨
    
    List<Dialogue> dialogue = new List<Dialogue>();
      void Start()
    {
        data = GameObject.FindObjectOfType<DatabaseManager>().GetComponent<DatabaseManager>();

        Dialogue[] dialogues = data.GetDialogue();
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogue.Add(dialogues[i]);  //dialogue 리스트에 DatabaseManager에서 가져온 대사 추가
        }

        owner = GameObject.FindGameObjectWithTag("주인장");
        farmer = GameObject.FindGameObjectWithTag("해리슨");
    }
    

    // tag로 캐릭터 UI 투명도, 색 조절
    public void ChangeColor(int i) 
    {
        if (dialogue[i].name == owner.tag)
        {
            owner.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            farmer.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);  // 해리슨 캐릭터 흑백화 
        }
        else
        {
            owner.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);   // 주인장 캐릭터 흑백화 
            farmer.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
