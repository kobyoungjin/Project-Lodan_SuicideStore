using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kettle : MonoBehaviour
{
    Button btn;
    IngredientSlot ingredientSlot;
    GameObject bar;
    List<GameObject> barList = new List<GameObject>();  // 장바구니에 들어있는 오브젝트 저장하는 변수

    private void Start()
    {
        ingredientSlot = GameObject.FindObjectOfType<IngredientSlot>().GetComponent<IngredientSlot>();
        bar = ingredientSlot.GetBarObj();

        btn = GetComponent<Button>();
        
        btn.onClick.AddListener(MakingMedicine);
    }

    private void Update()
    {
        Interact();
    }

    void MakingMedicine()
    {
        SceneNumber currentScene = SceneFlowManager.Instance.GetCurrentState();
        for (int i = 0; i < bar.transform.childCount; i++)
        {
            barList.Add(bar.transform.GetChild(i).gameObject);
        }

        List<string> types= new List<string>();
        for (int i = 0; i < barList.Count; i++)
        {
            string name = GameManager.Instance.GetFindIngreToType(barList[i].name);
            types.Add(name);
        }

        string[] answer = GameManager.Instance.FindAnswer(currentScene.ToString());

        Result(types, answer);
    }

    void Result(List<string> types, string[] answer)
    {
        string[] playerToBar = types.ToArray();

        //for (int i = 0; i < length; i++)
        //{
            
        //}
        //answer[]
    }

    void Interact()
    {
        int count = ingredientSlot.GetBarChildCount();

        if (count != 5)
            btn.interactable = false;
        else
            btn.interactable = true;
    }
}
