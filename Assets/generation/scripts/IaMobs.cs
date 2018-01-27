using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IaMobs : MonoBehaviour
{
    public Vector2 Speed = new Vector2(1, 4);
    public float Interval = 2;
    public float Tolerance = 0.1f;

    public float Life = 100;

    private Vector2 _tmpTarg = Vector2.zero;
    private Vector2 _x;
    private Vector2 _y;
    private float _speed = 0;

    void ChangeDirection()
    {
        _speed = Random.Range(Speed.x, Speed.y);
        _tmpTarg = new Vector2(Random.Range(_x.x, _x.y), Random.Range(_y.x, _y.y));
    }

    void Start()
    {
        SceneLoader loader = GameObject.Find("loader").GetComponent<SceneLoader>();
        _x = new Vector2(loader.Center.x - (loader.Size.x / 2), loader.Center.x + (loader.Size.x / 2));
        _y = new Vector2(loader.Center.y - loader.Size.y / 2, loader.Center.y + loader.Size.y / 2);
        InvokeRepeating("ChangeDirection", 0, Interval);
    }

    void Update()
    {
        if (Math.Abs(transform.position.x - _tmpTarg.x) > Tolerance || Math.Abs(transform.position.y - _tmpTarg.y) > Tolerance)
            transform.position = Vector2.MoveTowards(transform.position, _tmpTarg, _speed * Time.deltaTime);
        else
            ChangeDirection();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("uganda"))
            if (Life-- <= 0)
            {
                GameObject.Find("ugandaManager").GetComponent<ugandaManager>().SendMessage("SpawnUganda", transform.position);
                Destroy(this.gameObject);
            }
       // ChangeDirection();
    }
}
