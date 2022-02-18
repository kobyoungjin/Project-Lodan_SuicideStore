using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameObject gameManager = Instantiate(Resources.Load<GameObject>("Title/Prefab/GameManager(Prefab)"));
            GameObject sceneManager = Instantiate(Resources.Load<GameObject>("Title/Prefab/sceneManager(Prefab)"));

            DontDestroyOnLoad(gameManager);
            DontDestroyOnLoad(sceneManager);
        }
    }

}
