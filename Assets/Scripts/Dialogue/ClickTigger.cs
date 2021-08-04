using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTigger : MonoBehaviour
{
    private int clickNum = 1;

    public void Trigger()  // 클릭할때마다 대사 변경
    { 
        var data = FindObjectOfType<DatabaseManager>();  
        data.ShowText(clickNum);
       
        clickNum++;
    }
}
