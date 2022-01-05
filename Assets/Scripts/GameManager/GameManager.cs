using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : InheritSingleton<GameManager>
{
    [SerializeField] Texture2D cursorImg;

    AnimationManager animationManager;
    SettingManager settingManager;

    protected override void Awake()
    {
        base.Awake();

        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);  // 마우스 커서 이미지 변경
        DontDestroyOnLoad(this.gameObject);

        return;
    }

    private void Start()
    {
        animationManager = GameObject.FindObjectOfType<AnimationManager>().GetComponent<AnimationManager>();
        settingManager = GameObject.FindObjectOfType<SettingManager>().GetComponent<SettingManager>();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    void LoadIngreData()
    {

    }

    void LoadDialogData()
    {

    }

    void LoadPeopleData()
    {

    }

}

