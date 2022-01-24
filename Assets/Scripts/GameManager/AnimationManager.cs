using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationManager : MonoBehaviour
{
    private Image fader;
    private static AnimationManager instance;

    void Awake()
    {
        fader = transform.GetChild(0).GetComponent<Image>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            fader.rectTransform.sizeDelta = new Vector2(Screen.width + 20, Screen.height + 20);
            fader.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeScene(int index, float duration)
    {
        fader.gameObject.SetActive(true); //UI Image On
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t)); //Image(fader) 투명도 조절
            yield return null;
        }
        SceneManager.LoadScene(index); //전환
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t)); //Image(fader) 투명도 조절
            yield return null;
        }
        fader.gameObject.SetActive(false);// UI Image Off

        //SaveScene();
    }
    private IEnumerator InformNoSave()
    {
        GameObject text = GameObject.Find("Main Canvas").transform.Find("NoSaveText").gameObject;
        if (text.active == false)
        {
            text.SetActive(true);
            yield return new WaitForSeconds(2);
            text.SetActive(false);
        }
    }

    public static void GoScene(int num)
    {
        instance.StartCoroutine(instance.FadeScene(num, 1));
    }
    //다음 씬으로
    public static void LoadNextScene()
    {
        int num = SceneManager.GetActiveScene().buildIndex;
        GoScene(num + 1);
    }
    //저장된 씬으로
    public static void LoadSavedScene()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            int savedScene = PlayerPrefs.GetInt("SavedScene");
            GoScene(savedScene);
        }
        else
            instance.StartCoroutine(instance.InformNoSave());
    }
    //private void saveScene() //메인 씬 저장
    //{
    //    int savedScene = SceneManager.GetActiveScene().buildIndex;
    //    if (savedScene > 0 && savedScene <= 2)
    //        PlayerPrefs.SetInt("SavedScene", savedScene);
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //esc 누르면 타이틀 씬으로 (임시)
        {
            PlayerPrefs.DeleteKey("SavedScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoScene(0);
        }
    }
}
