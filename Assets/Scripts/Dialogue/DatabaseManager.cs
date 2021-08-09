using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    CharacterManager manager;

    [SerializeField] TextMeshProUGUI npcText;
    [SerializeField] TextMeshProUGUI npcName;
    
    [SerializeField] string csv_FileName;  

    List<Dialogue> dialogue = new List<Dialogue>();  //대사 저장 리스트

    public static bool isFinish = false;  // 저장이 끝났는지 판별

    void Awake()
    {
        manager = GameObject.FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();

        if (instance == null)  // DatabaseManager가 인스턴스 상태가 아니면
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_FileName);
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogue.Add(dialogues[i]);  // dialogue리스트에 대사, 이름 저장
            }
            isFinish = true;
        }
    }

    public void ShowText(int i)  // 텍스트 UI에 대사 삽입
    {
        if (i > 36) //대사를 끝까지 출력하면
        {
            End();  
            return;
        }
        npcName.text = dialogue[i].name;
        
        StopAllCoroutines();
        StartCoroutine(TypeNpcText(npcText.text = dialogue[i].context));
        

        manager.ChangeColor(i);  // 캐릭터 색조절
    }

    IEnumerator TypeNpcText(string npcText)  // 한글자씩 나오게 생성
    {
        this.npcText.text = string.Empty;

        foreach (var letter in npcText)
        {
            this.npcText.text += letter;   //한글자씩 생성
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void End()  // 빈공간으로 만든다.
    {
        npcText.text = string.Empty;
    }

    public Dialogue[] GetDialogue() // 대사 get함수
    {
        return dialogue.ToArray();  // 리스트를 dialogue[]형태로
    }
}


