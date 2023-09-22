using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Annex/New Inventory Object")]
public class InventoryObject : ScriptableObject
{

    public int limit = -1; //-1 no limit
    public List<AnnexItem> Container = new List<AnnexItem>();

    public void AddItem(AnnexItem item){
        
        for (int i = 0; i < Container.Count; i++){
            
            if(Container[i] == item){
                break;
            }
        }
        Container.Add(item);
    }

    public void RemoveItem(AnnexItem item){
        Container.Remove(item);
    }

    public void HardClear(){
        Container = new List<AnnexItem>();
    }

    
}
