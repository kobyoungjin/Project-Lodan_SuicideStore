using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleParser : MonoBehaviour
{
    public PeopleData[] Parse(TextAsset _CSVFileData) // 파서
    {
        List<PeopleData> peopleDataList = new List<PeopleData>(); //대사 리스트 생성

        string[] data = _CSVFileData.text.Split(new char[] { '\n' });  // 엔터 단위로 끊어서 저장

        for (int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  // ,별로 끊어서 저장

            PeopleData peopleData = new PeopleData(); // 대사 리스트 생성

            if (row[0] == "name") continue;

            peopleData.name = row[0];
            peopleData.explain = row[1];
            peopleData.PerfectRecipe = row[2];

            peopleDataList.Add(peopleData);
        }
        return peopleDataList.ToArray();   // dialogue 리스트 형태 형태로 반환
    }

    internal string Parse(object _CSVFileData)
    {
        throw new NotImplementedException();
    }
}