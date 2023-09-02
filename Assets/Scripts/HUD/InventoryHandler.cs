using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{

    private bool showing;
    public InventoryObject inventory;
    Dictionary<ItemType,AnnexItem> EquippedSlots = new Dictionary<ItemType,AnnexItem>();

    void Awake(){
        showing = false;
    }

    public void ToggleInventory(){

        showing = !showing;//flip
        gameObject.SetActive(showing);
    }

    public void DisplayInventory(){

        for (int i = 0; i < inventory.Container.Count; i++){

            //do stuff https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
        }
    }
}