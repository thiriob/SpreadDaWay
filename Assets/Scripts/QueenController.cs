using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QueenController : MonoBehaviour
{

    public float Life;

    public SceneLoader Map;
    float _sizeMapDiv2X;
    float _sizeMapDiv2Y;
    public float Speed = 2.0f;
    public Vector2 MovementVector;

    private Animator _anim;

    void Start()
    {
        _sizeMapDiv2X = Map.Size.x / 2.0f;
        _sizeMapDiv2Y = Map.Size.y / 2.0f;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Life <= 0)
        {
            print("perdu");
            SceneManager.LoadScene("MainMenu");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("mob"))
        {
            Life--;
        }
    }

    void FixedUpdate()
    {

        /* Left/right/up/down movements */
        MovementVector = Vector2.zero;

        MovementVector += Vector2.right * Input.GetAxisRaw("Horizontal");
        MovementVector += Vector2.up * Input.GetAxisRaw("Vertical");
        if (MovementVector.x == 0 || MovementVector.y == 0)
            MovementVector *= 1.41f;
        MovementVector *= Speed * Time.deltaTime;
        float queenXPos = transform.position.x + MovementVector.x;
        float queenYPos = transform.position.y + MovementVector.y;
        if (queenXPos > Map.Center.x + _sizeMapDiv2X || queenXPos < Map.Center.x - _sizeMapDiv2X)
        {
            MovementVector.x = 0;
        }
        if (queenYPos > Map.Center.y + _sizeMapDiv2Y || queenYPos < Map.Center.y - _sizeMapDiv2Y)
        {
            MovementVector.y = 0;
        }
        transform.Translate(MovementVector);

        /* Mouse related movements */
        var mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        var renderer = GetComponent<SpriteRenderer>();
        if (MovementVector.x > 0) renderer.flipX = true;
        if (MovementVector.x < 0) renderer.flipX = false;
        _anim.SetInteger("moving", (int)((MovementVector.x + MovementVector.y) * 1000));
    }
}
