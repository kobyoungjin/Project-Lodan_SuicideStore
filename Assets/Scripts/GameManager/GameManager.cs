using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : InheritSingleton<GameManager>
{
    public Texture2D cursorImg;
    
    //AnimationManager animationManager;
    //SettingManager settingManager;
    DialogueDatabase dialogueDatabase;
    
    Dictionary<string, DialogueData[]> dialogueDicData = new Dictionary<string, DialogueData[]>();

    protected override void Awake()
    {
        base.Awake();

        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);  // 마우스 커서 이미지 변경
        
        DontDestroyOnLoad(this.gameObject);
        return;
    }

    private void Start()
    {
        //animationManager = GameObject.FindObjectOfType<AnimationManager>().GetComponent<AnimationManager>();
        //settingManager = GameObject.FindObjectOfType<SettingManager>().GetComponent<SettingManager>();
        dialogueDatabase = GetComponent<DialogueDatabase>();

        LoadDialogData();
    }


    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    // 재료 데이터를 저장하는 함수
    void LoadIngreData()
    { 

    }

    // DiaLogue 데이터를 저장하는 함수
    void LoadDialogData()  
    {
        TextAsset[] textFiles = Resources.LoadAll<TextAsset>("Dialogue");  // Resource/Dialogue 폴더에 있는 모든 파일들을 가져온다.

        for (int i = 0; i < textFiles.Length; i++)
        {
            dialogueDatabase.SaveData(textFiles[i]);
            dialogueDicData.Add(textFiles[i].name, dialogueDatabase.GetDialogue());
        }
    }

    // 인물 관련 데이터 저장하는 함수
    void LoadBookData()
    {
        TextAsset textFile = Resources.Load<TextAsset>("IngredientData");  //  Resource/Dialogue 폴더에 있는 파일을 가져온다.
        
        dialogueDatabase.SaveData(textFile);
        dialogueDicData.Add(textFile.name, dialogueDatabase.GetDialogue());
    }
    
    // 이야기를 가져오는 함수
    public DialogueData[] GetStory(string name)
    {
        if (name == null)  // 이름이 없으면 null값 반환
        {
            Debug.Log("이름이 없습니다.");
            return null;
        }
           
        for (int i = 0; i < dialogueDicData.Count; i++)
        {
            if (dialogueDicData.ContainsKey(name))  // 딕션너리에 이름이 있으면 key값에 맞는 value값 반환
            {
                return dialogueDicData[name];
            }
        }

        Debug.Log("name 입력을 잘못했습니다");
        return null;
    }
}

