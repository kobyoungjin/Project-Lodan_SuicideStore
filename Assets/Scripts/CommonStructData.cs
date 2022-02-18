using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PeopleData
{
    public string name;
    public string explain;
    public string recipe;
}

[System.Serializable]
public struct IngredientData
{
    public string emotion;
    public string name;
    public string explain;
}

[System.Serializable]
public struct DialogueData
{
    public string name;
    public string context;
}

[System.Serializable]
public struct Answer
{
    public string name;
    public string[] emotion;
}

