using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneLoader : MonoBehaviour
{
    private Dictionary<string, string> _params;

    public Vector2 Center = Vector2.zero;
    public Vector2 Size = Vector2.one * 5;

    public Vector3 UgandaStartPos;
    public int UgandaNumber;

    private GameObject _map;
    private GameObject _mobContainer;
    private List<GameObject> _mobs = new List<GameObject>();
    private NameGenerator _ng;

    void SpawnMobs()
    {
        var sprites = Resources.LoadAll("MobsSprite", typeof(Sprite));
        Vector2 X = new Vector2(Center.x - Size.x / 2, Center.x + Size.x / 2 + 1);
        Vector2 Y = new Vector2(Center.y - Size.y / 2, Center.y + Size.y / 2 + 1);
        _mobContainer = new GameObject("MOBCONTAINER");
        foreach (var v in _params)
        {
            if (String.Compare(v.Key, 0, "mob", 0, 3) == 0)
            {
                for (int i = 0; i < int.Parse(v.Value); i++)
                {
                    Vector2 tmp = new Vector2(Random.Range(X.x, X.y), Random.Range(Y.x, Y.y));
                    var obj = Instantiate(Resources.Load("Prefabs/" + v.Key.Remove(0, 3), typeof(GameObject)) as GameObject, tmp, Quaternion.identity, _mobContainer.transform);
                    _mobs.Add(obj);
                    obj.name = _ng.CreateUsername();
                    obj.GetComponent<SpriteRenderer>().sprite = (Sprite)sprites[Random.Range(0, sprites.Length)];
                    var ia = obj.GetComponent<IaMobs>();
                    ia.DirectionInterval = Random.Range(2, 7);
                    ia.Venere = Random.Range(0, 20);
                    ia.Life = Random.Range(200, 1000);
                    ia.Speed = new Vector2(Random.Range(0.5f, 1.5f), Random.Range(2f, 6));
                    ia.SpeedInterval = new Vector2(Random.Range(0.5f, 1.5f), Random.Range(3, 6));
                }
            }
        }
    }

    void SpawnUgandas()
    {
        GameObject manager = GameObject.Find("ugandaManager");
        for (int i = 0; i < UgandaNumber; i++)
            manager.SendMessage("SpawnUganda", UgandaStartPos);
    }

    void Start()
    {
        var obj = new GameObject("NAMECONTAINER");
        obj.transform.SetParent(GameObject.Find("Canvas").transform);
        obj.transform.position = Vector3.zero;
        obj.transform.localScale = Vector3.one * 0.1f;
        _params = GameObject.Find("settings").GetComponent<Main>().Params;
        _ng = gameObject.AddComponent<NameGenerator>();
        Instantiate(Resources.Load("Maps/" + _params["mapName"], typeof(GameObject)) as GameObject);
        SpawnMobs();
        SpawnUgandas();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireCube(Center, Size);
    }
}