using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Active : MonoBehaviourPunCallbacks
{
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            camara.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
