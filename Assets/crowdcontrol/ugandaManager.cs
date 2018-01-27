using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ugandaManager : MonoBehaviour
{
    public GameObject ugandaPrefab;

    public List<GameObject> ugandas = new List<GameObject>();
    private GameObject ucontain;

    void Start()
    {
        ucontain = new GameObject("UGANDACONTAINER");
    }

    void sayQueen()
    {
        foreach (var currentUganda in ugandas)
        {
            currentUganda.GetComponent<uganda>().sayQueen();
        }
    }

    void SpawnUganda(Vector3 pos)
    {
        ugandas.Add(Instantiate(ugandaPrefab, pos, Quaternion.identity, ucontain.transform));
    }

    void PopUganda()
    {
        print("there is still " + ugandas.Count + " ugandas left.");
        if (ugandas.Count > 0)
        {
            print("destroying uganda");
            Destroy(ugandas.ElementAt(0));
            ugandas.RemoveAt(0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            sayQueen();
    }
}
