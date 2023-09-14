using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerModelHandler : MonoBehaviour
{
    private GameObject weaponMainModel;
    private GameObject weaponOffModel;
    private GameObject armorHeadModel;
    private GameObject armorChestModel;
    private GameObject armorLegsModel_r;
    private GameObject armorLegsModel_l;
    
    
    public void SwapModel(WeaponMain weapon){
        
        //shoutouts to crash
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r");

        if (weaponMainModel) Destroy(weaponMainModel);
        weaponMainModel = Instantiate(weapon.model,socket);

        //adjustment cus weapon_r stupid
        weaponMainModel.transform.localPosition = new Vector3(0.04f,0,-0.07f);
        weaponMainModel.transform.localRotation = Quaternion.Euler(0,-90,90);

    }

    public void SwapModel(WeaponOff weapon){
        
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l/weapon_l");

        if (weaponOffModel) Destroy(weaponOffModel);
        if (!weapon) return;
        weaponOffModel = Instantiate(weapon.model,socket);

        //adjustment cus weapon_r stupid
        weaponOffModel.transform.localRotation = Quaternion.Euler(-90,-90,90);
    }

    public void SwapModel(ArmorHead armor){
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/head");

        if (armorHeadModel) Destroy(armorHeadModel);
        armorHeadModel = Instantiate(armor.model.transform.GetChild(0).gameObject,socket);
    }

    public void SwapModel(ArmorChest armor){
        Transform socket;
        
    }

    public void SwapModel(ArmorLegs armor){
        Transform socket_l = transform.Find("player_robot_scaled/rot/leg_l");
        Transform socket_r = transform.Find("player_robot_scaled/rot/leg_r");

        if (armorLegsModel_l) Destroy(armorLegsModel_l);
        if (armorLegsModel_r) Destroy(armorLegsModel_r);

        armorLegsModel_l = Instantiate(armor.model.transform.GetChild(0).gameObject,socket_l);
        armorLegsModel_r = Instantiate(armor.model.transform.GetChild(1).gameObject,socket_r);

    }
}
