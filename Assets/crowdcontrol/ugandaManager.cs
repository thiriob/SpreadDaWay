using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugandaManager : MonoBehaviour
{
    public GameObject ugandaPrefab;
    private List<GameObject> ugandas = new List<GameObject>();

    void sayQueen()
    {
        foreach (var currentUganda in ugandas)
        {
            currentUganda.GetComponent<uganda>().sayQueen();
        }   
    }

    void SpawnUganda(Vector3 pos)
    {
        ugandas.Add(Instantiate(ugandaPrefab, pos, Quaternion.identity));
    }

	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Q))
            sayQueen();
    }
}
