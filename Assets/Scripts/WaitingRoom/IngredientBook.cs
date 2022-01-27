using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientBook : MonoBehaviour
{
    Button btn1;
    Button btn2;
    int page = 1;

    List<string> type;
    List<IngredientData> ingreAllData;
    Sprite[] ingreSprites;

    private void Start()
    {
        btn1 = transform.GetChild(1).GetComponent<Button>();
        btn2 = transform.GetChild(2).GetComponent<Button>();

        type = GameManager.Instance.GetTypeList();
        ingreAllData = GameManager.Instance.GetIngreAllData();
        ingreSprites = Resources.LoadAll<Sprite>("Image/MakingRoom/Material");

        Page(page);
        ChangeData(page - 1);

        btn1.onClick.AddListener(Left);
        btn2.onClick.AddListener(Right);
    }
    
    void Left()
    {
        page -= 1;

        if (page < 1) page = 1;

        Debug.Log(page);

        //ChangeData(page);
        Page(page);
    }

    void Right()
    {
        page += 1;

        if (page > 5) page = 5;

        Debug.Log(page);

        //ChangeData(page);
        Page(page);
    }

    void ChangeData(int page)
    {
        Transform range;
                       
        for (int i = 4 * page; i < (4 * page) + 4; i++)
        {
            range = transform.GetChild(0).transform.GetChild(i).transform;

            range.GetChild(1).GetComponent<Image>().sprite = ingreSprites[i];
            range.GetChild(2).transform.GetComponentInChildren<TextMeshProUGUI>().text = ingreAllData[i].name;
            range.GetChild(3).GetComponent<TextMeshProUGUI>().text = type[i];
            range.GetChild(4).GetComponent<TextMeshProUGUI>().text = ingreAllData[i].emotion;
            range.GetChild(5).GetComponent<TextMeshProUGUI>().text = ingreAllData[i].explain;
        }
    }

    void Page(int page)
    {
        TextMeshProUGUI bookPage = GameObject.Find("IngredientBook(Image)").transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        bookPage.text = page.ToString();
    }
}
