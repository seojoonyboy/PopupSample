using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
    void Start()
    {
        Popup.Params p = new Popup.Params();
        Popup.Load("ConfirmPopup", p, (popup, result) =>
        {
            Debug.Log("Confirm Popup Closed!");
        });
    }
}
