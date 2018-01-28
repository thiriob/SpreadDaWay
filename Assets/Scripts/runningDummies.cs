using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningDummies : MonoBehaviour
{
    private SpriteRenderer _render;
    private AudioSource _audio;
    private float _dir;

	void Start ()
	{
	    _render = GetComponent<SpriteRenderer>();
	    _audio = GetComponent<AudioSource>();
	    _dir = Random.Range(2.5f, 3.5f);
	    _audio.PlayDelayed(Random.Range(2f, 2.5f));
    }
	
	void FixedUpdate ()
	{
	    transform.position += Vector3.right * _dir * Time.deltaTime;
	}

    void OnBecameInvisible()
    {
        _dir *= -1;
        _render.flipX = !_render.flipX;
        _audio.PlayDelayed(Random.Range(0f, 1.5f));
    }
}
