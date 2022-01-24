using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animator;
    GameObject newGameBtn;
    GameObject LoadGameBtn;
    Button btn;
    bool isClick;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.GetComponent<Animator>().enabled = false;
        btn = GetComponent<Button>();

        btn.onClick.AddListener(IsWhat);
    }

    void IsWhat()
    {
        switch(this.gameObject.name)
        {
            case "NewGame":
                SceneManager.LoadScene("DialogueScene");
                //GameManager.Instance.LoadNextScene();
                break;
            case "LoadGame":
                SceneManager.LoadScene("");
                //SceneController.LoadSavedScene();
                break;
            case "Settings":
                SceneManager.LoadScene("");
                break;
            default:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isClick = true;
        animator.SetBool("IsClick", isClick);
        animator.GetComponent<Animator>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isClick = false;
        animator.SetBool("IsClick", isClick);
        animator.GetComponent<Animator>().enabled = true;
    }
}
