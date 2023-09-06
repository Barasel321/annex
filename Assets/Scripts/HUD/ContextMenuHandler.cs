using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContextMenuHandler : MonoBehaviour
{
    [Serializable]
    public struct ContextMenuOption{
        public string displayName;
        public UnityEvent action;
    }

    public ContextMenuOption[] menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
