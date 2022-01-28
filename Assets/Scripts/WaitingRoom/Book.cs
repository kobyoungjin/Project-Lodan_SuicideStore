using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    Button btn;
    GameObject ingredientBook;
    Button illustratedBook;
    private void Start()
    {
        ingredientBook = GameObject.Find("WaitingRoomCanvas");
        illustratedBook = GameObject.Find("IllustratedBook(Button)").GetComponent<Button>();
        btn = GetComponent<Button>();

        if(btn.name == "IngredientBook(Button)")
            btn.onClick.AddListener(Active);
        else
            btn.onClick.AddListener(() => GameManager.Instance.LoadNextScene("IllustratedBook", 1.0f));
    }

    void Active()
    {
        ingredientBook.transform.GetChild(3).gameObject.SetActive(true);
        illustratedBook.interactable = false;
    }

    public void SetInteractable(bool interact)
    {
        illustratedBook.interactable = interact;
    }
}
