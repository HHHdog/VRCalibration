using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MANAGER : MonoBehaviour
{
    public Transform Spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("OVRPlayer", Spawnpoint.position, Spawnpoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
