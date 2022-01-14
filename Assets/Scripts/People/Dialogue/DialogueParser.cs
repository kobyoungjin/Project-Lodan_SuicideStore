using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public DialogueData[] Parse(TextAsset _CSVFileData) // 파서
    {
        List<DialogueData> dialogueList = new List<DialogueData>(); //대사 리스트 생성

        string[] data = _CSVFileData.text.Split(new char[] {'\n'});  // 엔터 단위로 끊어서 저장
        
        for(int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,별로 끊어서 저장

            DialogueData dialogue = new DialogueData(); // 대사 리스트 생성
            
            if (row[0] == "name") continue;

            dialogue.name = row[0]; 
            dialogue.context = row[1];

            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();   // dialogue 리스트 형태 형태로 반환
    }

    internal string Parse(object _CSVFileData)
    {
        throw new NotImplementedException();
    }
}
