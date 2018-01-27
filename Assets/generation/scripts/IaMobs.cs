using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaMobs : MonoBehaviour
{
    public enum TypeIA
    {
        Actif,
        Passif
    }

    public TypeIA Type = TypeIA.Passif;
    public float Speed = 10;
    public Transform Target;

    void Update()
    {

    }
}
