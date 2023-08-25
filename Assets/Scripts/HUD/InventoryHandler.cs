using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{

    private bool showing;

    //ENTIRE INVENTORY SYSTEM

    void Awake(){
        showing = false;
    }

    public void ToggleInventory(){

        showing = !showing;//flip
        gameObject.SetActive(showing);
    }
}