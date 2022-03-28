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
    PeopleDatabase peopleDatabase;
    AddFrameIllrust script;

    List<PeopleData> peopleData = new List<PeopleData>();
    List<Sprite> characterImageList = new List<Sprite>();
    List<Sprite> backGroundImage = new List<Sprite>();
    Dictionary<string, DialogueData[]> dialogueDicData = new Dictionary<string, DialogueData[]>();
    Dictionary<string, List<IngredientData>> ingredientDicData = new Dictionary<string, List<IngredientData>>();
    Dictionary<string, string> ingreToTypeDicData = new Dictionary<string, string>();
    Dictionary<string, string[]> answerDicData = new Dictionary<string, string[]>();


    protected override void Awake()
    {
        base.Awake();

        cursorImg = Resources.Load<Texture2D>("Image/Title/MainCursor");
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);  // 마우스 커서 이미지 변경

        var objs = FindObjectsOfType<GameManager>();
        if (objs.Length == 1)  // GameManager타입의 개수가 1개일때만 
            DontDestroyOnLoad(this.gameObject);
        else  // 아니면 삭제
            Destroy(this.gameObject);

        return;
    }

    private void Start()
    {
        animationManager = GameObject.FindObjectOfType<AnimationManager>().GetComponent<AnimationManager>();
        //settingManager = GameObject.FindObjectOfType<SettingManager>().GetComponent<SettingManager>();
        dialogueDatabase = GetComponent<DialogueDatabase>();
        ingredientDatabase = GetComponent<IngredientDatabase>();
        peopleDatabase = GetComponent<PeopleDatabase>();
        
        LoadCharacterImageData();
        LoadBackGroundImage();
        LoadDialogueData();
        LoadIngreToTypeData();
        LoadMakingAnswer();
        LoadPeopleBookData();
        //LoadIngreData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // esc 누르면 타이틀 씬으로 (임시)
        {
            GameManager.Instance.LoadNextScene("Title", 1.0f);
        }
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

    // Ingreient 데이터 저장하는 함수 (대단원 -> 이름)
    void LoadIngreToTypeData()
    {
        TextAsset textFile = Resources.Load<TextAsset>("MakingRoom/IngredientData/Ingredient");  // Ingredient 분류표를 가져온다.
        ingredientDatabase.SaveData(textFile);

        List<string> typeData = ingredientDatabase.GetIngredientTypeList();
        List<IngredientData> ingredientData = ingredientDatabase.GetIngredientList();

        for (int i = 0; i < ingredientData.Count; i++)
        {
            ingreToTypeDicData.Add(ingredientData[i].name, typeData[i]);
        }
    }
    
    // 재료이름으로 대단원 찾기
    public string GetFindIngreToType(string name)
    {
        if (name == null)  // 이름이 없으면 null값 반환
        {
            Debug.Log("이름이 없습니다.");
            return null;
        }

        for (int i = 0; i < ingreToTypeDicData.Count; i++)
        {
            if (ingreToTypeDicData.ContainsKey(name))  // 딕션너리에 이름이 있으면 key값에 맞는 value값 반환
            {
                return ingreToTypeDicData[name];
            }
        }

        Debug.Log("string을 가져오지 못했습니다." + name);
        return null;
    }

    // Ingredient의 대분류 타입 리스트를 반환하는 함수
    public List<string> GetTypeList()
    {
        List<string> typeData = ingredientDatabase.GetIngredientTypeList();

        return typeData;
    }

    // Ingredient 데이터를 반환하는 함수
    public List<IngredientData> GetIngreAllData()
    {
        List<IngredientData> ingredientData = ingredientDatabase.GetIngredientList();

        return ingredientData;
    }

    // MakingRoom 조합식 답 
    void LoadMakingAnswer()
    {
        TextAsset textFile = Resources.Load<TextAsset>("MakingRoom/IngredientData/Answer");  // Ingredient 정답표을 불러온다.
        Debug.Log(textFile.name);
        ingredientDatabase.SaveData(textFile);
        
        List<Answer> answerData = ingredientDatabase.GetAnswerList();

        for (int i = 0; i < answerData.Count; i++)
        {
            answerDicData.Add(answerData[i].name, answerData[i].emotion);
        }
    }

    // 스토리에 따른 조합식 답 찾는 함수
    public string[] FindAnswer(string name)
    {
        Debug.Log(name);
        if (name == null)  // 이름이 없으면 null값 반환
        {
            Debug.Log("이름이 없습니다.");
            return null;
        }

        for (int i = 0; i < answerDicData.Count; i++)
        {
            if (answerDicData.ContainsKey(name))  // 딕션너리에 이름이 있으면 key값에 맞는 value값 반환
            {
                return answerDicData[name];
            }
        }

        Debug.Log("string[]을 가져오지 못했습니다." + name);
        return null;
    }

    // DiaLogue 데이터를 저장하는 함수
    void LoadDialogueData()
    {
        TextAsset[] textFiles = Resources.LoadAll<TextAsset>("Dialogue/Chapter1/Text");  // Resource/Dialogue 폴더에 있는 모든 파일들을 가져온다.
        TextAsset[] behind = Resources.LoadAll<TextAsset>("Dialogue/Behind/Text");
        for (int i = 0; i < textFiles.Length; i++)
        {
            dialogueDatabase.SaveData(textFiles[i]);
            dialogueDicData.Add(textFiles[i].name, dialogueDatabase.GetDialogue());
        }

        for (int i = 0; i < textFiles.Length; i++)
        {
            dialogueDatabase.SaveData(behind[i]);
            dialogueDicData.Add(behind[i].name, dialogueDatabase.GetDialogue());
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
    void LoadPeopleBookData()
    {
        TextAsset textFile = Resources.Load<TextAsset>("WaitingRoom/PeopleBookData/People");  //  Resource/Dialogue 폴더에 있는 파일을 가져온다.

        peopleDatabase.SaveData(textFile);
        peopleData = peopleDatabase.GetPeopleData();
    }

    // 타입에 따라 설명과 완벽한 레시피를 반환하는 함수
    public string FindPeopleText(string storyName, string type)
    {
        if(type == "explain")
        {
            for (int i = 0; i < peopleData.Count; i++)
            {
                if (peopleData[i].name == storyName)
                    return peopleData[i].explain;
            }
        }
        else if(type == "PerfectRecipe")
        {
            for (int i = 0; i < peopleData.Count; i++)
            {
                if (peopleData[i].name == storyName)
                    return peopleData[i].PerfectRecipe;
            }
        }

        Debug.Log("FindPeopletext 오류");
        return null;
    }

    // 인물 스프라이트 데이터 가져오는함수
    void LoadCharacterImageData()
    {
        Sprite[] sprite = Resources.LoadAll<Sprite>("Dialogue/Chapter1/Character");

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

    // 배경 이미지 가져오는 함수
    void LoadBackGroundImage()
    {
        Sprite[] sprite = Resources.LoadAll<Sprite>("Dialogue/Behind/BackGround");

        for (int i = 0; i < sprite.Length; i++)
        {
            backGroundImage.Add(sprite[i]);
        }
    }

    // 배경 이미지 반환하는 함수
    public List<Sprite> GetBackGroundImageData()
    {
        return backGroundImage;
    }
}
