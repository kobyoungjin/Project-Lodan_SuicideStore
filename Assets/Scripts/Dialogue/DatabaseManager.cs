using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    [SerializeField] Text npcText;
    [SerializeField] Text npcName;
    
    [SerializeField] string csv_FileName;

    List<Dialogue> dialogue = new List<Dialogue>();

    public static bool isFinish = false;  // 저장이 끝났는지 판별

    void Awake()
    {
        if (instance == null)
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
        npcName.text = dialogue[i].name;

        StopAllCoroutines();
        StartCoroutine(TypeNpcText(npcText.text = dialogue[i].context));

        changeColor(i);
    }

    IEnumerator TypeNpcText(string npcText)  // 한글자씩 나오게 생성
    {
        this.npcText.text = string.Empty;

        foreach (var letter in npcText)
        {
            this.npcText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public Dialogue[] getDialogue()
    {
        return dialogue.ToArray();
    }

    public void changeColor(int i) // tag로 대화 UI 투명도 색 조절
    {
        GameObject owner = GameObject.FindGameObjectWithTag("주인장");
        owner.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (!(dialogue[i].name == owner.tag))
        {
            owner.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        GameObject farmer = GameObject.FindGameObjectWithTag("해리슨");
        farmer.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (!(dialogue[i].name == farmer.tag))
        {
            farmer.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
    }

}
