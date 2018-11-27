using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private PhotonView photonView;
    [SerializeField] private Vector3 selfPosition;

    private void Start()
    {
        if (photonView.isMine)
        {
            gameObject.GetComponentInChildren<Camera>().enabled = true;
            gameObject.GetComponentInChildren<PhotonVoiceRecorder>().enabled = true;
            selfPosition = transform.position;
        }
    }

    void Update () {
        if (photonView.isMine)
        {
            //Write data
            selfPosition = transform.position;
        }
        else
        {
            //Read data
            transform.position = selfPosition;
        }
	}

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            selfPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
