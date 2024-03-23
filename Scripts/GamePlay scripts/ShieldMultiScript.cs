﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ShieldMultiScript : MonoBehaviour
{
   
    public float deathTime;
    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        GetComponent<PhotonView>().TransferOwnership(view.Owner);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<PhotonView>().TransferOwnership(view.Owner);
        GetComponent<PhotonView>().RPC(nameof(Destroy), RpcTarget.AllBuffered);
    }

    [PunRPC]
    void Destroy()
    {
        Destroy(gameObject, deathTime);
    }
    [PunRPC]
    void DestroyIn(float deadrr)
    {
        Destroy(gameObject, deadrr);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.tag == "World")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
    }
    public void ActivateShield()
    {
    }
}