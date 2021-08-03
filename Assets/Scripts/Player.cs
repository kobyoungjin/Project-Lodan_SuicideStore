using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Image image;
    DatabaseManager dataBase;


    void Awake()
    {
        image = GetComponent<Image>();

        dataBase.getDialogue();
    }

    public void ChangeColor()
    {
        image.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
}
