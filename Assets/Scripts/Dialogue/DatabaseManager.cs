using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    [SerializeField] string csv_FileName;  

    List<Dialogue> dialogue = new List<Dialogue>();  //대사 저장 리스트

    public static bool isFinish = false;  // 저장이 끝났는지 판별

    void Awake()
    {
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

    public Dialogue[] GetDialogue() // 대사 get함수
    {
        return dialogue.ToArray();  // 리스트를 dialogue[]형태로
    }
}


