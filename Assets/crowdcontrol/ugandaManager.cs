using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugandaManager : MonoBehaviour
{

    public GameObject ugandaPrefab;
    private List<GameObject> ugandas;

	void Start () {
		ugandas = new List<GameObject>();
	}

    void sayQueen()
    {
        foreach (var currentUganda in ugandas)
        {
            currentUganda.GetComponent<uganda>().sayQueen();
        }   
    }

	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.S))
	    {
	        GameObject obj = Instantiate(ugandaPrefab) as GameObject;

	        ugandas.Add(obj);
	    }
	    if (Input.GetKeyDown(KeyCode.Q))
            sayQueen();
    }
}
