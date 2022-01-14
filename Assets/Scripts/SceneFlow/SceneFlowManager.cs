using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneNumber
{
   Harison,
   Brianna,
   c,
   d,
   e,
   f
}

public class SceneFlowManager : MonoBehaviour
{
    SceneNumber mainFlow;

    private void Start()
    {
        mainFlow = SceneNumber.Brianna;
    }

    private void Update()
    {
        
    }

    public void ShowDialogue()
    {
        
    }

    public SceneNumber GetCurrentState()
    {
        return mainFlow;
    }

    public void SetNextStory()
    {
        mainFlow += 1;
    }
}
