using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerModelHandler : MonoBehaviour
{
    private GameObject weaponMainModel;
    private GameObject weaponOffModel;
    private GameObject armorHeadModel;

    private GameObject armorChestModel_body;
    private GameObject armorChestModel_upper_body;
    private GameObject armorChestModel_arm_l;
    private GameObject armorChestModel_arm_r;
    private GameObject armorChestModel_elbow_l;
    private GameObject armorChestModel_elbow_r;


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
        Transform socket_body = transform.Find("player_robot_scaled/rot/body");
        Transform socket_upper_body = transform.Find("player_robot_scaled/rot/body/upper_body");

        Transform socket_arm_l = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l");
        Transform socket_arm_r = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r");
        
        Transform socket_elbow_l = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l");
        Transform socket_elbow_r = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r");

        if (armorChestModel_body) {
            Destroy(armorChestModel_arm_l);
            Destroy(armorChestModel_arm_r);
            Destroy(armorChestModel_body);
            Destroy(armorChestModel_upper_body);
            Destroy(armorChestModel_elbow_l);
            Destroy(armorChestModel_elbow_r);
        }

        armorChestModel_body = Instantiate(armor.model.transform.GetChild(1).gameObject,socket_body);
        armorChestModel_upper_body = Instantiate(armor.model.transform.GetChild(0).GetChild(2).gameObject,socket_upper_body);
        
        armorChestModel_arm_l = Instantiate(armor.model.transform.GetChild(0).GetChild(0).GetChild(1).gameObject,socket_arm_l);
        armorChestModel_arm_r = Instantiate(armor.model.transform.GetChild(0).GetChild(1).GetChild(1).gameObject,socket_arm_r);

        armorChestModel_elbow_l = Instantiate(armor.model.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject,socket_elbow_l);
        armorChestModel_elbow_r = Instantiate(armor.model.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject,socket_elbow_r);
    }

    public void SwapModel(ArmorLegs armor){
        Transform socket_l = transform.Find("player_robot_scaled/rot/leg_l");
        Transform socket_r = transform.Find("player_robot_scaled/rot/leg_r");

        if (armorLegsModel_l) {
            Destroy(armorLegsModel_l);
            Destroy(armorLegsModel_r);
        }

        armorLegsModel_l = Instantiate(armor.model.transform.GetChild(0).gameObject,socket_l);
        armorLegsModel_r = Instantiate(armor.model.transform.GetChild(1).gameObject,socket_r);

    }
}
