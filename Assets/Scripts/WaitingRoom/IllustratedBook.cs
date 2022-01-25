using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IllustratedBook : MonoBehaviour
{
    Button btn;
    GameObject detailBook;

    void Start()
    {
        btn = GetComponent<Button>();
        detailBook = GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(3).gameObject;
        
        if (btn.name == "Left(Button)")
        {
            GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(btn.name == "Right(Button)")
        {
            GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.Find("IllustratedBook(Canvas)").transform.GetChild(1).gameObject.SetActive(false);
        }
        else
            btn.onClick.AddListener(FindData);
    }
    

    void FindData()
    {
        string parentName = transform.parent.name;
        Debug.Log(parentName);
        List<Sprite> characterImageList = GameManager.Instance.GetCharacterData();

        detailBook.SetActive(true);

        for (int i = 0; i < characterImageList.Count; i++)
        {
            if(characterImageList[i].name == parentName)
            {
                Image image = detailBook.transform.Find("Character(Image)").GetComponent<Image>();
                image.sprite = characterImageList[i];

                TextMeshProUGUI name = detailBook.transform.Find("Name(TMP)").GetComponent<TextMeshProUGUI>();
                name.text = parentName;
                return;
            }
        }
        Debug.Log("¿À·ù");
    }
}
