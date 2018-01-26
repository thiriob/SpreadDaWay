using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : MonoBehaviour {

    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
    void FixedUpdate () {

        /* Left/right/up/down movements */
        var movementVector = Vector2.right * Input.GetAxis("Horizontal");
        movementVector += Vector2.up * Input.GetAxis("Vertical");
        transform.Translate(movementVector * speed * Time.deltaTime);

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
