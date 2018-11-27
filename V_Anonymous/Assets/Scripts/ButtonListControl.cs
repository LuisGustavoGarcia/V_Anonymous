using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class ButtonListControl : Photon.MonoBehaviour
{

    public GameObject buttonTemplatePrefab;
    public GameObject listView;
    public RoomInfo[] rooms;

    void Start () {
        rooms = PhotonNetwork.GetRoomList();
    }

    public void UpdateList()
    {
        if (rooms.Length < 1)
        {
            return;
        }
        
        GameObject button = Instantiate(buttonTemplatePrefab) as GameObject;
        button.SetActive(true);
        //Set the text of the button to the room name
        Debug.Log(rooms.Length);
        button.GetComponent<ButtonListButton>().SetText(rooms[rooms.Length - 1].Name);
        //Set parent to Content Object through prefab Button, 2nd parameter is to avoid setting the button to world space
        button.transform.SetParent(listView.transform, false);
        
    }

    public void RemoveServer()
    {

    }
}
