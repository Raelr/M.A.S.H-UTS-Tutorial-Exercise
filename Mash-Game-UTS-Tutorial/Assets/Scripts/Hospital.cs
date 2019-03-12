﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
{
    BoxCollider2D collider;

    private void Awake() {

        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "Player") {
            LevelManager.instance.Player.EmptySoldiers();
        }
    }

}
