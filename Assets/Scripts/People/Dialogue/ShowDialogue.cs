using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI npcText;
    [SerializeField] TextMeshProUGUI npcName;
    private CharacterManager manager;
    private DialogueDatabase database;
    private Button btn;

    private int clickNum = SceneFlowManager.Instance.GetSaveDialogueNum();  // 몇번째 대사인지 구별변수 
    int medicineSceneNum;
    private bool isRead = true;  // 대사가 이미 나타나고 있는지 판별하는 변수(true면 한글자씩 나오게)

    SceneNumber currentState;
    List<DialogueData> dialogue = new List<DialogueData>();

    private void Start()
    {
        manager = GameObject.FindObjectOfType<CharacterManager>().GetComponent<CharacterManager>();
        database = GameObject.FindObjectOfType<DialogueDatabase>().GetComponent<DialogueDatabase>();
        btn = GetComponent<Button>();

        Transform dialogueBar = GameObject.Find("Dialogue_Bar").transform;
        npcText = dialogueBar.GetChild(0).GetComponent<TextMeshProUGUI>();
        npcName = dialogueBar.GetChild(1).GetComponent<TextMeshProUGUI>();

        npcText.text = null;
        npcName.text = null;

        string currentStateName = null;
        if (SceneManager.GetActiveScene().name == "BehindDialogueScene")
        {
            currentStateName = SceneFlowManager.Instance.GetBehindName();
        }
        else
        {
            currentState = SceneFlowManager.Instance.GetCurrentState();
            currentStateName = currentState.ToString();
        }

        Debug.Log(currentStateName);
        SettingStory(currentStateName);

        //ShowFirstDialogue();
        btn.onClick.AddListener(() => ShowText(clickNum)); // 클릭시 대화가 나온다.
    }

    // 클릭없이 바로 첫대사 출력하는 함수
    public void ShowFirstDialogue()
    {
        npcName.text = dialogue[0].name;

        StopAllCoroutines();
        StartCoroutine(TypeNpcText(npcText.text = dialogue[1].context));
        isRead = true;

        GameObject.FindGameObjectWithTag("주인장").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        GameObject.FindGameObjectWithTag("Customer").GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    
    // 대사를 보여주는 함수
    public void ShowText(int i)  
    {
        if (i >= dialogue.Count) //대사를 끝까지 출력하면
        {
            EndAndNextScene();
            return;
        }
        //else if (i == medicineSceneNum)  // 이름칸에 빈칸이 있으면
        //{
        //    Debug.Log(medicineSceneNum);
        //    clickNum = i + 1;
        //    SceneFlowManager.Instance.SetSaveDialogueNum(clickNum);
        //    //GameManager.Instance.LoadNextScene("MedicineScene", 1.0f);
        //    return;
        //}

        npcName.text = dialogue[i].name;

        StopAllCoroutines();
        if (isRead == true)  // 처음 클릭이면 대사 한글자씩 나오게 출력
        {
            StartCoroutine(TypeNpcText(npcText.text = dialogue[i].context)); // 텍스트 UI에 대사 삽입
        }
        else  // 처음클릭이 아니라면 전체 대사 출력
        {
            npcText.text = dialogue[i].context;
            isRead = true;  // 다시 한글자씩 나올수 있도록 bool값 바꿔주기
            clickNum++;
        }
        
        manager.ChangeColor(i);  // 캐릭터 색조절
    }

    // 한글자씩 나오게 생성하는 코루틴 함수
    IEnumerator TypeNpcText(string npcText) 
    {
        isRead = false;  // 처음 클릭해서 함수들어오면 다시 클릭했을때 전체 대사 나오게 bool값 바꿔주기 
        this.npcText.text = string.Empty;

        foreach (var letter in npcText)
        {
            this.npcText.text += letter;   // 한글자씩 생성
            yield return new WaitForSeconds(0.1f);
        }
       
        if (this.npcText.text.Length == npcText.Length)  // 현재 대사 길이와 대사 전체 길이가 같으면 
        {
            clickNum++;
            isRead = true;  // 한 대사가 끝나면 다음대사도 한글자씩 나오게 bool값 설정
        }
    }

    // 대사를 다하면 빈공간으로 만드는 함수.
    private void EndAndNextScene()  
    {
        npcText.text = string.Empty;
        GameManager.Instance.LoadNextScene("MedicineScene", 1.0f);
        clickNum = 0;
    }

    public List<DialogueData> GetCurrentDialogue()
    {
        return dialogue;
    }

    public void SetMedicineNum(int num)
    {
        medicineSceneNum = num;
    }

    public void skip()
    {
        clickNum = dialogue.Count-1;
        ShowText(clickNum);
    }

    // 스토리에 필요한캐릭터와 대사 가져오는 함수
    void SettingStory(string StateName)
    {
        dialogue.Clear();

        if (SceneManager.GetActiveScene().name == "BehindDialogueScene")
        {
            List<Sprite> backGroundImage = GameManager.Instance.GetBackGroundImageData();
            Image backGround = GameObject.Find("BackGround(Image)").GetComponent<Image>();
            for (int i = 0; i < backGroundImage.Count; i++)
            {
                if (backGroundImage[i].name == StateName)
                    backGround.sprite = backGroundImage[i];
            }
        }

        manager.ChooseCharacter(StateName);
        DialogueData[] dialogues = GameManager.Instance.GetStory(StateName);
        Debug.Log(dialogues.Length);
        for (int i = 0; i < dialogues.Length; i++)
        {
            if (dialogues[i].name == "")
            {
                medicineSceneNum = i;
                continue;
            }
            dialogue.Add(dialogues[i]);  //dialogue 리스트에 DatabaseManager에서 가져온 대사 추가
        }
    }
    
}
