using System;
using System.Collections;
using Unity.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class PopupRoot : MonoBehaviour
{
    public static PopupRoot Instance;
    
    [SerializeField] private List<Popup> popupList = new List<Popup>();

    private void Awake()
    {
        PopupRoot.Instance = this;
    }

    public void AddPopup(Popup popup)
    {
        this.popupList.Add(popup);    
    }

    public void RemovePopup(Popup popup)
    {
        this.popupList.Remove(popup);
        Destroy(popup.gameObject);
    }

    public bool IsPopupExist()
    {
        return (this.popupList.Count > 0);
    }

    public void CloseAllPopup()
    {
        foreach (Popup popup in popupList)
        {
            popup.Close();
            this.popupList.Remove(popup);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
