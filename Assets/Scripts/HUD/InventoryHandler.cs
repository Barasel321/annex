using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{

    private bool showing;
    public InventoryObject inventory;
    public GameObject itemIcon;

    public int activeWeaponSlot;
    public WeaponMain[] weaponMain;

    public WeaponOff weaponOff;

    public ArmorHead armorHead;
    public ArmorChest armorChest;
    public ArmorLegs armorLegs;
    
    

    void Awake(){
        showing = false;
        DisplayInventory();
        activeWeaponSlot = 0;
    }

    public void ToggleInventory(){

        showing = !showing;//flip
        gameObject.SetActive(showing);
    }

    public WeaponMain GetWeaponMain(){
        return weaponMain[activeWeaponSlot];
    }

    public void SwapWeapons(int newSlot){
        activeWeaponSlot = newSlot;
    }

    public void SwapWeaponModel(AnnexWeaponSO newWeapon){
        
        if (newWeapon is WeaponMain){
            //swap weaponmain            
        }
        else if (newWeapon is WeaponOff){
            //swap weaponoff
        }
    }

    public void SwapArmorModel(AnnexArmorSo newArmor){

        if (newArmor is ArmorHead){
            //TODO
        }
        else if (newArmor is ArmorChest){
            //TODO
        }
        else if (newArmor is ArmorLegs){
            //TODO
        }
    }


    public void DisplayInventory(){

        for (int i = 0; i < inventory.Container.Count; i++){

            //do stuff https://www.youtube.com/watch?v=_IqTeruf3-s&list=PLJWSdH2kAe_Ij7d7ZFR2NIW8QCJE74CyT&index=1
            var obj = Instantiate(itemIcon,Vector3.zero,Quaternion.identity, transform.GetChild(0).GetChild(0));
            obj.GetComponent<RectTransform>().localPosition = new Vector3(11f,93f - 33f * i,0f);
            obj.GetComponent<ItemButton>().item = inventory.Container[i];
            // obj.GetComponent<Button>().onClick.AddListener(obj.GetComponent<ItemButton>().HandleButtonClick);
            //HANDLE IMAGE
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.Container[i].displayName;
            obj.SetActive(true);
        }
    }

    public void Equip(AnnexItem item){
        
        if (item is WeaponMain){
            WeaponMain newWeaponMain = (WeaponMain)item;
            weaponMain[activeWeaponSlot] = newWeaponMain;
            SwapWeaponModel(newWeaponMain);
        }
        else if (item is WeaponOff){
            WeaponOff newWeaponOff = (WeaponOff) item;
            weaponOff = newWeaponOff;
            SwapWeaponModel(newWeaponOff);
        }
        else if (item is ArmorHead){
            ArmorHead newArmorHead = (ArmorHead) item;
            armorHead = newArmorHead;
            SwapArmorModel(newArmorHead);
        }
        else if (item is ArmorChest){
            ArmorChest newArmorChest = (ArmorChest) item;
            armorChest = newArmorChest;
            SwapArmorModel(newArmorChest);
        }
        else if (item is ArmorLegs){
            ArmorLegs newArmorLegs = (ArmorLegs) item;
            armorLegs = newArmorLegs;
            SwapArmorModel(newArmorLegs);
        }
        //expand if necessary
    }
}