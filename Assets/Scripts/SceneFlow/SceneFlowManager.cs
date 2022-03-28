using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneNumber
{
    케이트 = 0,
    해리슨 = 1,
    애런_엘리 = 2,
    프레드 = 3,
    브리아나 = 4,
    리암 = 5,
    마야 = 6,
    이든 = 7,
    벤 = 8,
    마일즈 = 9,
    갈런 = 10,
    노렌 = 11,
}

public enum Playing
{
    Dialogue,
    MiniGame,
}

public class SceneFlowManager : InheritSingleton<SceneFlowManager>
{
    SceneNumber currentFlow = SceneNumber.마야;
    int saveNumer = 1;
    string setBehindName;

    protected override void Awake()
    {
        base.Awake();

        var objs = FindObjectsOfType<SceneFlowManager>();
        if (objs.Length == 1)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);

        return;
    }

    public SceneNumber GetCurrentState()
    {
        return currentFlow;
    }

    public void SetNextStory()
    {
        Debug.Log(currentFlow);
        
        currentFlow += 1;

        Debug.Log(currentFlow);
        saveNumer = 1;
    }

    public void SetSaveDialogueNum(int num)
    {
        saveNumer = num;
    }

    public int GetSaveDialogueNum()
    {
        return saveNumer;
    }

    public void SetBehindName(string name)
    {
        setBehindName = name + "Behind";
    }
    public string GetBehindName()
    {
        return setBehindName;
    }
}
