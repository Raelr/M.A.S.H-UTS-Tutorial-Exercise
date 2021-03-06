﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{

    PolygonCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        LevelManager.instance.IncrementSoldierCount();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (LevelManager.instance.Player.AddSoldier()) {
            Destroy(this.gameObject);
        } else {
            Debug.Log("We're full.");
        }
    }
}
