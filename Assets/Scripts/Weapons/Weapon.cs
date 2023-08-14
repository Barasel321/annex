using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
        // Start is called before the first frame update

        [SerializeField] AnnexWeaponSO annexWeaponSO;

        public HitBox hitbox;
        private HitBox clone;

        public void onFire(Transform attacker){
                clone = Instantiate(hitbox);

                clone.annexWeaponSO = annexWeaponSO;
                
                clone.GetComponent<BoxCollider>().size = annexWeaponSO.hitboxScale;
                clone.transform.position = attacker.position + attacker.forward + attacker.up;
                clone.transform.rotation = attacker.rotation;

        }
}
