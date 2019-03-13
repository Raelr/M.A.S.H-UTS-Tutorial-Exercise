using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector2 velocity;

    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    int maxSoldiers;

    int currentSoldiers;

    Rigidbody2D rigidbody;

    PolygonCollider2D collider;

    private void Awake() {

        collider = GetComponent<PolygonCollider2D>();

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

        return isAllowed;
    }

    public void EmptySoldiers() {

        Debug.Log("Emptying Players");
        LevelManager.instance.RemoveSoldier(currentSoldiers);
        currentSoldiers = 0;
    }
}
