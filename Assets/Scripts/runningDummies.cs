using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningDummies : MonoBehaviour
{
    private SpriteRenderer render;
    private AudioSource audio;
    private float dir;

	void Start ()
	{
	    render = GetComponent<SpriteRenderer>();
	    audio = GetComponent<AudioSource>();
	    dir = Random.Range(2.5f, 3.5f);
	    audio.PlayDelayed(Random.Range(2f, 2.5f));
    }
	
	void FixedUpdate ()
	{
	    transform.position += Vector3.right * dir * Time.deltaTime;
	}

    void OnBecameInvisible()
    {
        dir *= -1;
        render.flipX = !render.flipX;
        audio.PlayDelayed(Random.Range(0f, 1.5f));
    }
}
