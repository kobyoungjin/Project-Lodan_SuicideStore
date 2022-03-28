using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        else if(parent.name == "DetailBook")
        {
            parent.transform.GetChild(1).GetComponent<Image>().sprite = null;
            parent.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "##";
            parent.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "##";

            IllustratedBook illustratedBook = GameObject.FindObjectOfType<IllustratedBook>().GetComponent<IllustratedBook>(); ;
            illustratedBook.SetArrowInteract(true);
            illustratedBook.SetBackInteract(true);
        }
        else if(parent.name == "IngredientBook(Image)")
        {
            if (SceneManager.GetActiveScene().name == "MedicineScene")
            {
                Debug.Log(SceneManager.GetActiveScene().name);

                IngreBook ingreBook = GameObject.FindObjectOfType<IngreBook>().GetComponent<IngreBook>();
                GameObject storageUI = GameObject.Find("Storage").transform.GetChild(3).gameObject;

                for (int i = 0; i < storageUI.transform.childCount; i++)
                {
                    storageUI.transform.GetChild(i).GetComponent<Button>().interactable = true;
                }
                ingreBook.Setinteract(true);
            }
            else
            {
                Book book = GameObject.FindObjectOfType<Book>().GetComponent<Book>();
                book.SetInteractable(true);
            }
        }

        parent.SetActive(false);
    }
}
