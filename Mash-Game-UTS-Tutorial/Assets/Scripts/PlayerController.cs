using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 velocity;

    [SerializeField]
    float MoveSpeed;

    Rigidbody2D rigidbody;

    BoxCollider2D collider;

    private void Awake() {

        collider = GetComponent<BoxCollider2D>();

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        ProcessInput();
        
    }

    void ProcessInput() {

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MovePlayer();
    } 

    void MovePlayer() {

        transform.Translate(velocity * MoveSpeed * Time.deltaTime); 
    }
}
