using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackButton : MonoBehaviour
{
    GameObject parent;
    Button btn;

    void Start()
    {
        parent = transform.parent.gameObject;
        btn = GetComponent<Button>();

        btn.onClick.AddListener(ResetData);
    }

    public void ResetData()
    {
        if(parent.name == "IllustratedBook(Canvas)")
        {
            GameManager.Instance.LoadNextScene("WaitingRoom", 1f);
        }

        if(parent.name == "DetailBook")
        {
            parent.transform.GetChild(1).GetComponent<Image>().sprite = null;
            parent.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "##";
            parent.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "##";

            IllustratedBook illustratedBook = GameObject.FindObjectOfType<IllustratedBook>().GetComponent<IllustratedBook>(); ;
            illustratedBook.SetArrowInteract(true);
            illustratedBook.SetBackInteract(true);
        }

        if(parent.name == "IngredientBook(Image)")
        {
            Book book = GameObject.FindObjectOfType<Book>().GetComponent<Book>();
            book.SetInteractable(true);
        }
           

        parent.SetActive(false);
    }
}
