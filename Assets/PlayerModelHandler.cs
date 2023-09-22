using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerModelHandler : MonoBehaviour
{
    private GameObject weaponMainModel;
    private GameObject weaponOffModel;
    
    private GameObject armorHeadModel;
    private GameObject armorHeadModel_eyes;


    private GameObject armorChestModel_body;
    private GameObject armorChestModel_upper_body;
    private GameObject armorChestModel_arm_l;
    private GameObject armorChestModel_arm_r;
    private GameObject armorChestModel_elbow_l;
    private GameObject armorChestModel_elbow_r;


    private GameObject armorLegsModel_leg_l;
    private GameObject armorLegsModel_leg_r;
    private GameObject armorLegsModel_knee_l;
    private GameObject armorLegsModel_knee_r;
    
    
    public void SwapModel(WeaponMain weapon){
        
        //shoutouts to crash
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r");

        if (weaponMainModel) Destroy(weaponMainModel);
        weaponMainModel = Instantiate(weapon.model,socket);

        //adjustment cus weapon_r stupid
        weaponMainModel.transform.localPosition = new Vector3(0.04f,0,-0.07f);
        weaponMainModel.transform.localRotation = Quaternion.Euler(-90,-90,90);

    }

    public void SwapModel(WeaponOff weapon){
        
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l/weapon_l");

        if (weaponOffModel) Destroy(weaponOffModel);
        if (!weapon) return;
        weaponOffModel = Instantiate(weapon.model,socket);

        //adjustment cus weapon_r stupid
        weaponOffModel.transform.localRotation = Quaternion.Euler(-90,-90,90);
    }
    public GameObject Find(AnnexItem item, params int[] indexes){
        Transform c = item.model.transform;

        foreach(int i in indexes){
            c = c.GetChild(i);
        }

        return c.gameObject;
    }

    
    public void SwapModel(ArmorHead armor){
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/head");
        Transform socket_eyes = transform.Find("player_robot_scaled/rot/body/upper_body/head/eyes");

        if (armorHeadModel) {
            Destroy(armorHeadModel);
            Destroy(armorHeadModel_eyes);
        }

        armorHeadModel = Instantiate(Find(armor,1),socket);
        armorHeadModel_eyes = Instantiate(Find(armor,0,0),socket_eyes);
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

        armorChestModel_body = Instantiate(Find(armor,1),socket_body);
        armorChestModel_upper_body = Instantiate(Find(armor,0,2),socket_upper_body);
        
        armorChestModel_arm_l = Instantiate(Find(armor,0,0,1),socket_arm_l);
        armorChestModel_arm_r = Instantiate(Find(armor,0,1,1),socket_arm_r);

        armorChestModel_elbow_l = Instantiate(Find(armor,0,0,0,0),socket_elbow_l);
        armorChestModel_elbow_r = Instantiate(Find(armor,0,1,0,0),socket_elbow_r);
    }

    public void SwapModel(ArmorLegs armor){
        Transform socket_leg_l = transform.Find("player_robot_scaled/rot/leg_l");
        Transform socket_leg_r = transform.Find("player_robot_scaled/rot/leg_r");

        Transform socket_knee_l = transform.Find("player_robot_scaled/rot/leg_l/knee_l");
        Transform socket_knee_r = transform.Find("player_robot_scaled/rot/leg_r/knee_r");


        if (armorLegsModel_leg_l) {
            Destroy(armorLegsModel_knee_l);
            Destroy(armorLegsModel_knee_r);
            Destroy(armorLegsModel_leg_l);
            Destroy(armorLegsModel_leg_r);
        }

        armorLegsModel_leg_l = Instantiate(Find(armor,0,1),socket_leg_l);
        armorLegsModel_leg_r = Instantiate(Find(armor,1,1),socket_leg_r);

        armorLegsModel_knee_l = Instantiate(Find(armor,0,0,0),socket_knee_l);
        armorLegsModel_knee_r = Instantiate(Find(armor,1,0,0),socket_knee_r);

    }
}
