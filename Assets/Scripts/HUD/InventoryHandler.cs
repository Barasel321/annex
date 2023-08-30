using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{

    private bool showing;

    //ENTIRE INVENTORY SYSTEM
    public class AnnexItem{
        public string itemName;
        public string itemType;
    }

    void Awake(){
        showing = false;
    }

    public void ToggleInventory(){

        showing = !showing;//flip
        gameObject.SetActive(showing);
    }
}