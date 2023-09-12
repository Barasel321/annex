using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerModelHandler : MonoBehaviour
{
    private GameObject weaponMainModel;
    
    public void SwapModel(WeaponMain weapon){
        
        //shoutouts to crash
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r");

        if (weaponMainModel) Destroy(weaponMainModel);
        weaponMainModel = Instantiate(weapon.model,socket);
        weaponMainModel.transform.localPosition = new Vector3(0.04f,0,-0.07f);
        weaponMainModel.transform.localRotation = Quaternion.Euler(0,-90,90);

    }

    public void SwapModel(WeaponOff weapon){
        
        Transform socket = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l/weapon_l");

        Destroy(socket.GetChild(0));
        weapon.model.transform.SetParent(socket);
    }

    public void SwapModel(ArmorHead armor){
        
    }

    public void SwapModel(ArmorChest weapon){
        
    }

    public void SwapModel(ArmorLegs weapon){
        
    }
}
