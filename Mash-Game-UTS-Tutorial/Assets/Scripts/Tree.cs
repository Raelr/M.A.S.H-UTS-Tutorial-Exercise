﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    BoxCollider2D collider;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "Player") {
            LevelManager.instance.DisplayLoseText();
        }
    }
}
