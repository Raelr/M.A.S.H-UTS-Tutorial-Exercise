using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour {
    Vector2 velocity;

    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    int maxSoldiers;

    int currentSoldiers;

    Rigidbody2D rigidbody;

    PolygonCollider2D collider;

    AudioSource audio;

    [SerializeField]
    TextMeshPro text;

    [SerializeField]
    Color invalidColor;

    [SerializeField]
    Color defaultColor;

    float smoothedVelocity;

    [SerializeField]
    float smoothTime;

    private void Awake() {

        collider = GetComponent<PolygonCollider2D>();

        rigidbody = GetComponent<Rigidbody2D>();

        audio = GetComponent<AudioSource>();

        currentSoldiers = 0;

        UpdateSoldierCount();
    }

    private void Update() {

        ProcessInput();

    }

    void ProcessInput() {

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MovePlayer();
    }

    void MovePlayer() {

        Vector2 finalVelocity = new Vector2(Mathf.Clamp(velocity.x, LevelManager.instance.MinBounds.x, LevelManager.instance.MaxBounds.x), Mathf.Clamp(velocity.y, LevelManager.instance.MinBounds.y, LevelManager.instance.MaxBounds.y));

        transform.Translate(velocity * MoveSpeed * Time.deltaTime);
    }

    void UpdateSoldierCount() {

        text.color = currentSoldiers >= maxSoldiers ? invalidColor : defaultColor;
        text.text = currentSoldiers >= maxSoldiers ? "Helicopter  Full!" : "Soldiers Rescued: " + currentSoldiers.ToString();
    }

    public bool AddSoldier() {

        bool isAllowed;

        if (currentSoldiers < maxSoldiers) {
            currentSoldiers++;

            audio.Play();

            isAllowed = true;
        } else {
            isAllowed = false;
        }

        UpdateSoldierCount();

        return isAllowed;
    }

    public void EmptySoldiers() {

        Debug.Log("Emptying Players");
        LevelManager.instance.RemoveSoldier(currentSoldiers);
        currentSoldiers = 0;
        UpdateSoldierCount();
    }
}
