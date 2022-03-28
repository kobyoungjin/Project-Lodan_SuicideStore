using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerParser : MonoBehaviour
{
    public Answer[] Parse(TextAsset csvData) // 파서
    {
        List<Answer> answerList = new List<Answer>(); //대사 리스트 생성

        string[] data = csvData.text.Split(new char[] { '\n' });  // 엔터 단위로 끊어서 저장

        for (int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,별로 끊어서 저장
            Answer answer = new Answer(); // 재료 리스트 생성

            if (row[0] == "스토리")
                continue;

            List<string> temp = new List<string>();
            answer.name = row[0];
            for (int j = 0; j < 5; j++)
            {
                temp.Add(row[j + 1]);
            }
            answer.emotion = temp.ToArray();

            answerList.Add(answer);
        }
        return answerList.ToArray();   // array 형태로 반환
    }
}
