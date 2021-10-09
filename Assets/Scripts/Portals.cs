using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    void Start() {}

    void Update() {}

    void GotoNextLevel() {
        string scene;
        switch (SceneManager.GetActiveScene().name) {
            case "Level1":
                scene = "Level2";
                break;
            case "Level2":
                scene = "Level3";
                break;
            case "Level3":
                scene = "End";
                break;
            default:
                scene = "Menu";
                break;
        }

        SceneManager.LoadScene(scene);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GotoNextLevel();
    }
}
