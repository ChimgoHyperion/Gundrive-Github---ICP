﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public Slider ammoBar;

    public void DropItem()
    {
        foreach  ( Transform child in transform )
        {
           // child.GetComponent<SpawnDroppedItem>().SpawnDroppedPowerUp();
            Destroy(child.gameObject);
            ammoBar.value = 0;
            ammoBar.maxValue = 100;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("GunContainer").GetComponent<Inventory>();
        ammoBar = GameObject.FindGameObjectWithTag("AmmoBar").GetComponent<Slider>();
        ammoBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
       

    }
}
