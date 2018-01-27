using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uganda : MonoBehaviour
{
    private Camera cam;
    private float speed = 5f;
    private AudioSource _audio;
    public AudioClip queen;

    private SpriteRenderer _render;
    private Animator _anim;

    public int debug;

    void Start()
    {
        cam = Camera.main;
        _audio = GetComponent<AudioSource>();
        _render = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        speed = Random.Range(0.2f, 1.8f);
        transform.localScale = new Vector3(1.2f - 0.2f * speed, 1.2f - 0.2f * speed + Random.Range(-0.2f, 0.2f), 2);
        speed += 3.0f;
    }

    public void sayQueen()
    {
        _audio.clip = queen;
        _audio.PlayDelayed(Random.Range(0.0f, 0.4f));
    }

    float AskDamage()
    {
        return (1);
    }

    void FollowMouse()
    {
        var mvmt = transform.position;

        var targ = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, targ, speed * Time.deltaTime);

        if (targ.x < transform.position.x) _render.flipX = true;
        if (targ.x > transform.position.x) _render.flipX = false;
        _anim.SetInteger("moving", 1);
    }

    void FixedUpdate()
    {
        FollowMouse();
    }
}
