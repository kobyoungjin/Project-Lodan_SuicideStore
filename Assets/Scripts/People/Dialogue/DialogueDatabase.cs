using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDatabase : MonoBehaviour
{
    //TextAsset csvFile;
    List<DialogueData> dialogue = new List<DialogueData>();  //대사 저장 리스트
    DialogueParser theParser;

    private void Awake()
    {
        theParser = GetComponent<DialogueParser>();
    }

    public void SaveData(TextAsset csvFile)
    {
        if (dialogue != null) dialogue.Clear();  // dialogue 리스트에 데이터가 있으면 삭제

        DialogueData[] dialogues = theParser.Parse(csvFile);
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogue.Add(dialogues[i]);  // dialogue리스트에 대사, 이름 저장
        }
    }

    public DialogueData[] GetDialogue() // 대사 get함수
    {
        return dialogue.ToArray();  // 리스트를 dialogue[]형태로
    }
}


