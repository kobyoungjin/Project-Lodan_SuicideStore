using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FindStuffManager : MonoBehaviour
{
    int chancesLeft = 6;
    int findStuffCount = 0;
    TextMeshProUGUI textShown;
    Button button;

    GameObject button2;

    // Start is called before the first frame update
    void Start()
    {
        textShown = GameObject.Find("ChancesLeftCount").GetComponent<TextMeshProUGUI>();
        textShown.text = chancesLeft.ToString();

        button2 = GameObject.Find("UI").transform.GetChild(8).gameObject;

        button = button2.transform.GetChild(1).GetComponent<Button>();
        button.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    public int GetChancesLeft()
    {
        return chancesLeft;
    }

    public void SetChancesLeft(int a)
    {
        chancesLeft -= a;
        textShown.text = chancesLeft.ToString();
        ActiveRetryButton();
    }

    public void SetFindStuffCount(int b)
    {
        findStuffCount += b;
        Debug.Log(findStuffCount);
    }

    public void ActiveRetryButton()
    {
        if (chancesLeft == -1 && findStuffCount != 4)
        {
            button2.SetActive(true);
        }
    }

    public void OnRetry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

}
