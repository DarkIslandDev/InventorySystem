using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public PlayerUI playerUI;

    public new Rigidbody rigidbody;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.B))
        {
            playerUI.InventoryUI();
        }
        
        rigidbody.velocity = new Vector3(horizontal, 0, vertical) * 5;
    }
}
