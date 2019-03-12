using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 velocity;

    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    int maxSoldiers;

    int currentSoldiers;

    Rigidbody2D rigidbody;

    BoxCollider2D collider;

    private void Awake() {

        collider = GetComponent<BoxCollider2D>();

        rigidbody = GetComponent<Rigidbody2D>();

        currentSoldiers = 0;
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

    public bool AddSoldier() {

        bool isAllowed;

        if (currentSoldiers < maxSoldiers) {
            currentSoldiers++;
            isAllowed = true;
        } else {
            isAllowed = false;
        }

        Debug.Log(isAllowed);
        return isAllowed;
    }
}
