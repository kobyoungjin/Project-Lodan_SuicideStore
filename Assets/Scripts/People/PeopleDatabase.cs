using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleDatabase : MonoBehaviour
{
    //TextAsset csvFile;
    List<PeopleData> peopleDataList = new List<PeopleData>();  // 인물 데이터 리스트
    PeopleParser theParser;

    private void Awake()
    {
        theParser = GetComponent<PeopleParser>();
    }

    public void SaveData(TextAsset csvFile)
    {
        if (peopleDataList != null) peopleDataList.Clear();  // dialogue 리스트에 데이터가 있으면 삭제

        PeopleData[] peopledataes = theParser.Parse(csvFile);
        for (int i = 0; i < peopledataes.Length; i++)
        {
            peopleDataList.Add(peopledataes[i]);  // dialogue리스트에 대사, 이름 저장
        }
    }

    public PeopleData[] GetPeopleData() // 대사 get함수
    {
        return peopleDataList.ToArray();  // 리스트를 dialogue[]형태로
    }
}
