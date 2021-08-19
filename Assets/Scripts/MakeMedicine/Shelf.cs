using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shelf : MonoBehaviour
{
    public Button btn;
    private ShelfTigger trigger;

    private void Start()
    {
        btn = GetComponent<Button>();

        trigger = transform.GetComponentInParent<ShelfTigger>();

        btn.onClick.AddListener(ShowObject);
    }

    private void ShowObject()
    {
        if (btn.transform.parent.gameObject.CompareTag("MainStorage"))
            trigger.ShowShelf(this);
        else if (btn.transform.parent.gameObject.CompareTag("Storage"))
            trigger.StorageUI(this);
    }
}
