using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientBook : MonoBehaviour
{
    Button btn;
    GameObject ingredientBook;

    private void Start()
    {
        ingredientBook = GameObject.Find("WaitingRoomCanvas");
        btn = ingredientBook.transform.GetChild(1).GetComponent<Button>();

        btn.onClick.AddListener(() => ingredientBook.transform.GetChild(3).gameObject.SetActive(true));
    }


}
