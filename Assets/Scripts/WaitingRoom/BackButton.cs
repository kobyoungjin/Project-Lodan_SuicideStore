using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackButton : MonoBehaviour
{
    GameObject parent;
    Button btn;
    Book book;

    void Start()
    {
        parent = transform.parent.gameObject;
        book = GameObject.FindObjectOfType<Book>().GetComponent<Book>();
        btn = GetComponent<Button>();

        btn.onClick.AddListener(ResetData);
    }

    public void ResetData()
    {
        if(parent.name == "DetailBook")
        {
            parent.transform.GetChild(0).GetComponent<Image>().sprite = null;
            parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = null;
        }

        if(parent.name == "IngredientBook(Image)")
            book.SetInteractable(true);

        parent.SetActive(false);
    }
}
