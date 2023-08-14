using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public AnnexWeaponSO annexWeaponSO;
    private float speed;
    
    
    void Start()
    {
        float lifetime = annexWeaponSO.hitboxLifetime;
        if (lifetime > 0) Invoke("Expire",lifetime);

        speed = annexWeaponSO.hitboxSpeed;
        GetComponent<BoxCollider>().size = annexWeaponSO.hitboxScale;

    }

    void Expire(){
        Destroy(gameObject);
    }

    void OnTriggerEnter (Collider other){
        if (other.gameObject.layer == 9){
            print(other.gameObject.name);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * Vector3.forward * speed);
    }
}
