using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float panSpeed = 20f;
    public float scrollSpeed = 20f;
    public float minY = 10f;
    public float maxY = 100f;


    public bool canMove = true;

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) canMove = !canMove;
        if (!canMove) return;


        ManageKeys();
        ManageZoom();
    }

    void ManageKeys() {
        if (Input.GetKey("w")) {
            transform.Translate(Time.deltaTime * panSpeed * Vector3.forward, Space.World);
        }
        if (Input.GetKey("a")) {
            transform.Translate(Time.deltaTime * panSpeed * Vector3.left, Space.World);
        }
        if (Input.GetKey("s")) {
            transform.Translate(Time.deltaTime * panSpeed * Vector3.back, Space.World);
        }
        if (Input.GetKey("d")) {
            transform.Translate(Time.deltaTime * panSpeed * Vector3.right, Space.World);
        }
    }

    void ManageZoom() {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= (scroll * 1000 * scrollSpeed * Time.deltaTime);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
