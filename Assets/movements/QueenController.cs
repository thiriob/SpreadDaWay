using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : MonoBehaviour {

    public SceneLoader map;

    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
    void FixedUpdate () {

        /* Left/right/up/down movements */
        var movementVector = Vector2.right * Input.GetAxis("Horizontal");
        movementVector += Vector2.up * Input.GetAxis("Vertical");
        movementVector *= speed * Time.deltaTime;
        float sizeMapDiv2x = map.Size.x / 2.0f;
        float sizeMapDiv2y = map.Size.y / 2.0f;
        if (movementVector.x > map.Center.x + sizeMapDiv2x) {
            movementVector.x = map.Center.x + sizeMapDiv2x;
        }
        if (movementVector.x < map.Center.x - sizeMapDiv2x) {
            movementVector.x = map.Center.x - sizeMapDiv2x;
        }
        if (movementVector.y > map.Center.y + sizeMapDiv2y) {
            movementVector.y = map.Center.y + sizeMapDiv2y;
        }
        if (movementVector.y < map.Center.y - sizeMapDiv2y) {
            movementVector.y = map.Center.y - sizeMapDiv2y;
        }
        transform.Translate(movementVector);

        /* Mouse related movements */
        var mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        var renderer = GetComponent<SpriteRenderer>();
        if (mousePosX < transform.position.x) {
            renderer.flipX = true;
        }
        else {
            renderer.flipX = false;
        }
	}
}
