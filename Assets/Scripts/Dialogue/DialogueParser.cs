using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{ 
    public Dialogue[] Parse(string _CSVFileName) // 파서
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>("Dialogue/"+_CSVFileName);

        string[] data = csvData.text.Split(new char[] {'\n'});  // 엔터 단위로 끊어서 저장
        
        for(int i=0; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,별로 끊어서 저장

            Dialogue dialogue = new Dialogue(); // 대사 리스트 생성

            dialogue.name = row[0]; 
            dialogue.context = row[1];

            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();   // dialogue 리스트 형태 형태로 반환
    }

    internal string Parse(object Farmer)
    {
        throw new NotImplementedException();
    }
}
