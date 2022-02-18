using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiddenSceneManager : MonoBehaviour
{
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(LoadBehind);
    }

    void LoadBehind()
    {
        string name = transform.parent.transform.Find("NameText(TMP)").GetComponent<TextMeshProUGUI>().text;
        SceneFlowManager.Instance.SetBehindName(name);
        GameManager.Instance.LoadNextScene("BehindDialogueScene", 1f);
    }
}
