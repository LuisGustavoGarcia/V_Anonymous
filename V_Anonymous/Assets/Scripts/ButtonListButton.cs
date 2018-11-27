using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class ButtonListButton : Photon.MonoBehaviour
{
    [SerializeField]
    private Text buttonText;

    public void SetText(string text)
    {
        buttonText.text = text;
    }

    public void OnClick()
    {
        PhotonNetwork.JoinRoom(buttonText.text);
    }
}
