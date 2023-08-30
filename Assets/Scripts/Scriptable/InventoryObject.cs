using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : ScriptableObject
{
    public List<AnnexItem> Container = new List<AnnexItem>();

    public void AddItem(AnnexItem item){
        
        for (int i = 0; i < Container.Count; i++){
            
            if(Container[i] == item){
                break;
            }
        }
        Container.Add(item);
    }
}
