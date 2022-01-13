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
    public string key;
    public int value;
}

[System.Serializable]
public struct DialogueData
{
    public string name;
    public string context;
}

