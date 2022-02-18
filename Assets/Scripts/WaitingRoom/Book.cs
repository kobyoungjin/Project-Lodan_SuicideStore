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

        if (btn.name == "IngredientBook(Button)")  // ingredient도감 이름이면
            btn.onClick.AddListener(Active);
        else if (btn.name == "Play(Button)")  // 게임 play버튼 누르면 dialogue씬으로
            btn.onClick.AddListener(() => GameManager.Instance.LoadNextScene("DialogueScene", 1.0f));
        else  // 
            btn.onClick.AddListener(() => GameManager.Instance.LoadNextScene("IllustratedBook", 1.0f));
    }

    // ingredient도감 여는 함수
    void Active()
    {
        ingredientBook.transform.GetChild(3).gameObject.SetActive(true);
        SetInteractable(false);
    }

    // 인물 도감 버튼 활성화 변환 함수 
    public void SetInteractable(bool interact)
    {
        illustratedBook.interactable = interact;
    }
}
