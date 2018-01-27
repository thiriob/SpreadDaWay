using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneLoader : MonoBehaviour
{
    private Dictionary<string, string> Params;

    public Vector2 Center = Vector2.zero;
    public Vector2 Size = Vector2.one * 5;

    public Sprite[] MapSprites = { };
    public GameObject[] MobPrefabs = { };

    public Vector3 UgandaStartPos;
    public int UgandaNumber;

    private GameObject _map;
    private GameObject _mobContainer;
    private Dictionary<string, GameObject> _mobDico = new Dictionary<string, GameObject>();
    private List<GameObject> _mobs = new List<GameObject>();
    private NameGenerator _ng;
    void InitMap()
    {
        _map = new GameObject("map");
        _map.transform.position = Vector3.forward;
        var tmp = _map.AddComponent<SpriteRenderer>();
        tmp.sortingLayerID = 0;
        tmp.sortingLayerName = "Background";
        foreach (var m in MapSprites)
            if (m.name == Params["mapName"])
            {
                tmp.sprite = m;
                return;
            }
        Debug.LogWarning("map name invalid");
    }

    void SpawnMobs()
    {
        for (int i = 0; i < MobPrefabs.Length; i++)
            _mobDico.Add(MobPrefabs[i].name, MobPrefabs[i]);
        Vector2 X = new Vector2(Center.x - Size.x / 2, Center.x + Size.x / 2);
        Vector2 Y = new Vector2(Center.y - Size.y / 2, Center.y + Size.y / 2);
        _mobContainer = new GameObject("MOBCONTAINER");

        foreach (var v in Params)
        {
            if (String.Compare(v.Key, 0, "mob", 0, 3) == 0)
            {
                for (int i = 0; i < int.Parse(v.Value); i++)
                {
                    Vector2 tmp = new Vector2(Random.Range(X.x, X.y), Random.Range(Y.x, Y.y));
                    var obj = Instantiate(_mobDico[v.Key.Remove(0, 3)], tmp, Quaternion.identity, _mobContainer.transform);
                    _mobs.Add(obj);
                    obj.name = _ng.CreateUsername();
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
        Params = GameObject.Find("setter").GetComponent<Main>().Params;
        _ng = gameObject.AddComponent<NameGenerator>();
        InitMap();
        SpawnMobs();
        SpawnUgandas();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireCube(Center, Size);
    }
}