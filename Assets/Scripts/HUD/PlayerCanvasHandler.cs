using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasHandler : MonoBehaviour
{
    public GameObject HP;
    public GameObject INV;
    public ThirdPersonAction thirdPersonAction;

    public void ChangeHealthBar(float newHealth){
        HP.GetComponent<HPBarHandler>().ChangeHealthBar(newHealth,thirdPersonAction);
    }

    public void ToggleInventory(){
        INV.GetComponent<InventoryHandler>().ToggleInventory();
    }
}
