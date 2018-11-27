using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private Transform spawnPoint;

    public void Update()
    {
        Transform spawner = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<Transform>();
        // Spawn the all player's visual characters
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            spawner.GetChild(i).GetChild(0).GetComponentInChildren<Transform>().gameObject.SetActive(true);
        }
    }

    public void SpawnPlayer()
    {
        spawnPoint = this.GetSpawnPoint();
        // Spawn the player
        playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity, 0);
    }

    public Transform GetSpawnPoint()
    {
        Transform spawner = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<Transform>();
        int nextSpawnIndex = PhotonNetwork.playerList.Length - 1;
        Transform spawnPoint = spawner.GetChild(nextSpawnIndex);

        return spawnPoint;
    }

}
