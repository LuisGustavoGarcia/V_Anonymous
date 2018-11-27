using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoomManager : Photon.PunBehaviour {

    [SerializeField] private PlayerManager playerManager;

    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = true;
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        //var temp = PhotonVoiceNetwork.Client;
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("Room");
    }

    public override void OnJoinedRoom()
    {
        LoadScene();
        Debug.Log("We have connected to the room.");
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Room")
        {
            playerManager.SpawnPlayer();
        }
    }

}
