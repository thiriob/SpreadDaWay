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
        Vector2 movementVector = new Vector2();

        movementVector += Vector2.right * Input.GetAxis("Horizontal");
        movementVector += Vector2.up * Input.GetAxis("Vertical");
        movementVector *= speed * Time.deltaTime;
        float sizeMapDiv2x = map.Size.x / 2.0f;
        float sizeMapDiv2y = map.Size.y / 2.0f;
        float queenXPos = transform.position.x + movementVector.x;
        float queenYPos = transform.position.y + movementVector.y;
        if (queenXPos > map.Center.x + sizeMapDiv2x || queenXPos < map.Center.x - sizeMapDiv2x) {
            movementVector.x = 0;
        }
        if (queenYPos > map.Center.y + sizeMapDiv2y || queenYPos < map.Center.y - sizeMapDiv2y) {
            movementVector.y = 0;
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
