using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishedDrug : MonoBehaviour
{
    Button btn;
    Kettle kettle;
    GameObject makeRoomCanvas;
    GameObject finished;

    private void Start()
    {
        makeRoomCanvas = GameObject.Find("MakeRoom Canvas");
        finished = GameObject.Find("FinishedDrug");
        kettle = GameObject.FindObjectOfType<Kettle>().GetComponent<Kettle>();
        btn = finished.transform.GetChild(1).GetComponent<Button>();

        btn.onClick.AddListener(NextScene);
    }
    
    void NextScene()
    {
        SceneFlowManager.Instance.SetNextStory();
        
        GameManager.Instance.LoadNextScene("WaitingRoom", 1.0f);
    }

    // 물약 이름 생성함수
    public void SetDrugNameing(string name, int num)
    {
        finished.transform.GetChild(0).gameObject.SetActive(true);
        finished.transform.GetChild(1).gameObject.SetActive(true);

        GameObject BackGround = makeRoomCanvas.transform.GetChild(7).transform.GetChild(0).gameObject;

        if (num == 0)
        {
            BackGround.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("MakingRoom/Drug/완성된 물약");
            string drugName = GameManager.Instance.FindPeopleText(name, "PerfectRecipe");
            BackGround.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = drugName;
        }
        else
        {
            BackGround.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("MakingRoom/Drug/미완성된 물약");
            BackGround.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "미미한 물약";
        }
    }
}
