using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
        // Start is called before the first frame update

        [SerializeField] public AnnexWeaponSO annexWeaponSO;

        public HitBox hitbox;
        private HitBox clone;

        public void onFire(Transform attacker, bool isPlayerHitBox){
                clone = Instantiate(hitbox);

                clone.annexWeaponSO = annexWeaponSO;
                clone.isPlayerHitBox = isPlayerHitBox;
                clone.owner = attacker;
                
                clone.GetComponent<BoxCollider>().size = annexWeaponSO.hitboxScale;
                clone.transform.rotation = attacker.rotation;
                clone.transform.position = attacker.position
                        - attacker.right *       annexWeaponSO.hitboxPosition.x
                        + attacker.up *          annexWeaponSO.hitboxPosition.y  
                        + attacker.forward *     annexWeaponSO.hitboxPosition.z;


        }
}
