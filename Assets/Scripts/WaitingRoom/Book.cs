using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    Button btn;
    GameObject ingredientBook;

    private void Start()
    {
        ingredientBook = GameObject.Find("WaitingRoomCanvas");
        btn = GetComponent<Button>();

        if(btn.name == "IngredientBook(Button)")
            btn.onClick.AddListener(() => ingredientBook.transform.GetChild(3).gameObject.SetActive(true));
        else
            btn.onClick.AddListener(() => GameManager.Instance.LoadNextScene("IllustratedBook", 1.5f));
    }


}
