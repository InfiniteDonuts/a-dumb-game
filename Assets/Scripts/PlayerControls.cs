using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 startingPos;
    private bool canJump = false;
    private AssetBundle assets;
    private string[] scenePaths;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
    }

    void Update() {
        if (Input.GetAxis("Horizontal") != 0) {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Vertical") > 0 && canJump) {
            rb.velocity += new Vector2(0, 5);
            canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.gameObject.tag) {
            case "Platform":
                canJump = true;
                break;
            case "Lava":
                transform.position = startingPos;
                break;
            default:
                break;
        }
    }

    void OnCollisionExit2D(Collision2D _) {
        canJump = false;
    }
}
