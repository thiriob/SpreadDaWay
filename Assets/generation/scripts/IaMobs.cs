using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IaMobs : MonoBehaviour
{

    public enum TypeIA
    {
        Actif,
        Passif
    }

    public TypeIA Type = TypeIA.Passif;
    public float Speed = 5;
    //public Transform Target;
    public float Interval = 2;
    public float Tolerance = 0.1f;

    private Vector2 _tmpTarg = Vector2.zero;
    private Vector2 X;
    private Vector2 Y;

    void ChangeDirection()
    {
        _tmpTarg = new Vector2(Random.Range(X.x, X.y), Random.Range(Y.x, Y.y));
    }

    void Start()
    {
        SceneLoader loader = GameObject.Find("loader").GetComponent<SceneLoader>();
        X = new Vector2(loader.Center.x - loader.Size.x / 2, loader.Center.x + loader.Size.x / 2);
        Y = new Vector2(loader.Center.y - loader.Size.y / 2, loader.Center.y + loader.Size.y / 2);
        //    InvokeRepeating("ChangeDirection", 0, Interval);
        ChangeDirection();
    }

    void Update()
    {
        if (Math.Abs(transform.position.x - _tmpTarg.x) > Tolerance || Math.Abs(transform.position.y - _tmpTarg.y) > Tolerance)
            transform.position = Vector2.MoveTowards(transform.position, _tmpTarg, Speed * Time.deltaTime);
        else
            ChangeDirection();
    }

}
