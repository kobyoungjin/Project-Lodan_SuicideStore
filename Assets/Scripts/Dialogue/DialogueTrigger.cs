using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private int clickNum = 1;

    public void Trigger()  // Ŭ���Ҷ����� ��� ����
    {
        var data = FindObjectOfType<DatabaseManager>();
        data.ShowText(clickNum);

        clickNum++;
    }
}