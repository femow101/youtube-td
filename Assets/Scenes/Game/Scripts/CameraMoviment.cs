using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour {
    
    [SerializeField] float velocity;

    Vector2 mousePos;
    int screenHeight90Percent = (int)(Screen.height * 0.9f);
    int screenWidth90Percent = (int)(Screen.width * 0.9f);
    bool isMoving;

    void FixedUpdate() {
        KeyboardMovimentUpdate();
        MouseReachesBorderMoviment();
    }

    void MouseReachesBorderMoviment() {
        if (isMoving) { return; }
        
        mousePos = Input.mousePosition;

        // Check if the mouse reaches the top
        if (mousePos.y >= screenHeight90Percent) {
            Move(Vector3.up);
        }

        // // Check if the mouse reaches the bottom
        // if (mousePos.y <= Screen.height - screenHeight80Percent) {
        //     Move(Vector3.down);
        // }

        // Check if the mouse reaches the right side
        if (mousePos.x >= screenWidth90Percent) {
            Move(Vector3.right);
        }

        // Check if the mouse reaches the left side
        if (mousePos.x <= Screen.width - screenWidth90Percent) {
            Move(Vector3.left);
        }
    }

    void KeyboardMovimentUpdate() {
        isMoving = false;

        // Horizontal Moviments
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            Move(Vector3.right);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            Move(Vector3.left);
        }

        // Vertical Moviments
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            Move(Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            Move(Vector3.down);
        }
    }

    void Move(Vector3 direction) {
        transform.position += direction * velocity * Time.deltaTime;
        isMoving = true;
    }
}
