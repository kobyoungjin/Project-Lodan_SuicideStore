using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : InheritSingleton<GameManager>
{
    private Texture2D cursorImg;

    AnimationManager animationManager;
    //SettingManager settingManager;

    DialogueDatabase dialogueDatabase;
    IngredientDatabase ingredientDatabase;

    List<Sprite> characterImageList = new List<Sprite>();
    Dictionary<string, DialogueData[]> dialogueDicData = new Dictionary<string, DialogueData[]>();
    Dictionary<string, List<IngredientData>> ingredientDicData = new Dictionary<string, List<IngredientData>>();

    protected override void Awake()
    {
        base.Awake();

        cursorImg = Resources.Load<Texture2D>("Image/Title/MainCursor");
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);  // 마우스 커서 이미지 변경

        DontDestroyOnLoad(this.gameObject);
        return;
    }

    private void Start()
    {
        animationManager = GameObject.FindObjectOfType<AnimationManager>().GetComponent<AnimationManager>();
        //settingManager = GameObject.FindObjectOfType<SettingManager>().GetComponent<SettingManager>();
        dialogueDatabase = GetComponent<DialogueDatabase>();
        ingredientDatabase = GetComponent<IngredientDatabase>();

        LoadCharacterImageData();
        LoadDialogueData();
        LoadIngreData();
    }

    // 다음 어떤씬으로 fade in 애니메이션을 몇초간 적용할지 부르는 함수
    public void LoadNextScene(string nextScene, float duration)
    {
        animationManager.SetFadeScene(nextScene, duration);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    // Ingredient 데이터를 저장하는 함수
    void LoadIngreData()
    {
        TextAsset textFile = Resources.Load<TextAsset>("MakingRoom/IngredientData/Ingredient");  // Ingredient 분류표를 가져온다.
        ingredientDatabase.SaveData(textFile);

        List<string> typeData = ingredientDatabase.GetIngredientTypeList();
        List<IngredientData> ingredientData = ingredientDatabase.GetIngredientList();

        for (int i = 0; i < ingredientData.Count; i++)
        {
            if (ingredientDicData.ContainsKey(typeData[i]))     // 딕션어리에 이미 키값이 존재한다면
            {
                ingredientDicData[typeData[i]].Add(ingredientData[i]);  // 그 키값에 이어서 추가
                continue;
            }

            ingredientDicData[typeData[i]] = new List<IngredientData> { ingredientData[i] };  // 키값이 존재 x 딕션어리에 새로운 key값, value값 저장
        }
    }

    // Ingredient의 (대단원)타입을 찾는 함수
    public List<IngredientData> GetFindTypeList(string type)
    {
        Debug.Log(type);
        if (type == null)  // 이름이 없으면 null값 반환
        {
            Debug.Log("이름이 없습니다.");
            return null;
        }

        for (int i = 0; i < ingredientDicData.Count; i++)
        {
            if (ingredientDicData.ContainsKey(type))  // 딕션너리에 이름이 있으면 key값에 맞는 value값 반환
            {
                return ingredientDicData[type];
            }
        }

        Debug.Log("리스트를 가져오지 못했습니다.");
        return null;
    }

    // DiaLogue 데이터를 저장하는 함수
    void LoadDialogueData()
    {
        TextAsset[] textFiles = Resources.LoadAll<TextAsset>("Dialogue/Text");  // Resource/Dialogue 폴더에 있는 모든 파일들을 가져온다.

        for (int i = 0; i < textFiles.Length; i++)
        {
            dialogueDatabase.SaveData(textFiles[i]);
            dialogueDicData.Add(textFiles[i].name, dialogueDatabase.GetDialogue());
        }
    }

    // DiaLogue데이터를 가져오는 함수
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

    // 인물 관련 데이터 저장하는 함수
    void LoadBookData()
    {
        TextAsset textFile = Resources.Load<TextAsset>("MakingRoom/IngredientData");  //  Resource/Dialogue 폴더에 있는 파일을 가져온다.

        dialogueDatabase.SaveData(textFile);
        dialogueDicData.Add(textFile.name, dialogueDatabase.GetDialogue());
    }

    // 인물 스프라이트 데이터 가져오는함수
    void LoadCharacterImageData()
    {
        Sprite[] sprite = Resources.LoadAll<Sprite>("Dialogue/Character");

        for (int i = 0; i < sprite.Length; i++)
        {
            characterImageList.Add(sprite[i]);
        }
    }

    // 인물 스프라이트 리스트 Getter함수
    public List<Sprite> GetCharacterData()
    {
        return characterImageList;
    }

    public List<string> GetTypeList()
    {
        List<string> typeData = ingredientDatabase.GetIngredientTypeList();

        return typeData;
    }

    public List<IngredientData> GetIngreAllData()
    {
        List<IngredientData> ingredientData = ingredientDatabase.GetIngredientList();

        return ingredientData;
    }
}




