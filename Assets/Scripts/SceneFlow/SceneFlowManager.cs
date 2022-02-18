using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneNumber
{
    Kate = 0,
    Harison = 1,
    Aaron_Ellie = 2,
    Fred = 3,
    Brianna = 4,
    Liam = 5,
    Miya = 6,
    Eden = 7,
    Ben = 8,
    Miles = 9,
    Galen = 10,
    Noren = 11,
}

public enum Playing
{
    Dialogue,
    MiniGame,
    Making
}

public class SceneFlowManager : InheritSingleton<SceneFlowManager>
{
    SceneNumber currentFlow = SceneNumber.Harison;
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
        setBehindName = name;
    }
    public string GetBehindName()
    {
        return setBehindName;
    }
}
