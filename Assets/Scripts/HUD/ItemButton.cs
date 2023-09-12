using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public AnnexItem item;
    private Button myButton;
    public ThirdPersonAction action;

    void Start()
    {
        myButton = GetComponent<Button>();
        if (myButton != null)
        {
            myButton.onClick.AddListener(HandleButtonClick);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject.");
        }
    }


    public void HandleButtonClick()
    {
        action.Equip(item);        
    }
}
