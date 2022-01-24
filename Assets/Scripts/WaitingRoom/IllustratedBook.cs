using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IllustratedBook : MonoBehaviour
{
    Button btn;
    GameObject waitingCanvas;
    GameObject detailBook;

    void Start()
    {
        btn = GetComponent<Button>();
        waitingCanvas = GameObject.Find("WaitingRoomCanvas");
        detailBook = waitingCanvas.transform.GetChild(5).gameObject;

        if(btn.name == "IllustratedBook(Button)")
        {
            btn.onClick.AddListener(()=> waitingCanvas.transform.GetChild(4).gameObject.SetActive(true));
            return;
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
