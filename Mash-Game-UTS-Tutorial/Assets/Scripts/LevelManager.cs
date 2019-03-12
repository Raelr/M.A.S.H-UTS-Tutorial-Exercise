using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PlayerController Player { get { return player; } }

    [SerializeField]
    PlayerController player;

    bool MenuShowing;

    [SerializeField]
    TextMeshPro Menutext;

    [SerializeField]
    TextMeshPro spacetext;

    [SerializeField]
    TextMeshPro countText;

    public static LevelManager instance;

    int totalSoldiers;

    private void Awake() {

        if (instance == null) {
            instance = this;
        }

        totalSoldiers = 0;
        ResumeGame();
        UpdateCount();
    }

    private void Update() {
        
        if (Input.GetKeyDown("space") && MenuShowing) {

            ResetGame();
        } else if (Input.GetKeyDown("r")) {
            ResetGame();
        }
    }

    public void DisplayLoseText() {

        PauseGame();
        Menutext.text = "You Lose!";
        spacetext.text = "Press Space To reset";
    }

    public void DisplayWinText() {

        PauseGame();
        Menutext.text = "You Win!";
        spacetext.text = "Press Space To reset";
    }

    public void PauseGame() {

        Time.timeScale = 0f;
        MenuShowing = true;
    } 

    public void ResumeGame() {

        Time.timeScale = 1f;
        MenuShowing = false;
    }

    void UpdateCount() {

        countText.text = "Soldiers: " + totalSoldiers.ToString();
    }

    void ResetGame() {

        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);
    }

    public void IncrementSoldierCount() {

        totalSoldiers++;
        UpdateCount();
    }

    public void RemoveSoldier(int count) {

        totalSoldiers -= count;

        if (totalSoldiers <= 0) {
            DisplayWinText();
        }

        UpdateCount();
    }
}
