using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController: MonoBehaviour
{
    [SerializeField] Transform Crosshair;
   

    void Update()
    {
        CrosshairMoving();
    }

    void CrosshairMoving()
    {
        Crosshair.localPosition = new Vector2(Input.mousePosition.x - (Screen.width / 2),
                                              Input.mousePosition.y - (Screen.height / 2));

        float cursorPosX = Crosshair.localPosition.x;
        float cursorPosY = Crosshair.localPosition.y;

        cursorPosX = Mathf.Clamp(cursorPosX, (-Screen.width / 2 + 50), (Screen.width / 2 - 50));
        cursorPosY = Mathf.Clamp(cursorPosY, (-Screen.height / 2 + 50), (Screen.height / 2 - 50));

        Crosshair.localPosition = new Vector2(cursorPosX, cursorPosY);
    }
}
