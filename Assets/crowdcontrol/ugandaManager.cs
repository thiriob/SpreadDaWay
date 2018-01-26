using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugandaManager : MonoBehaviour
{

    public GameObject ugandaPrefab;
    private List<uganda> ugandas;

	void Start () {
		
	}

    void sayQueen()
    {
        foreach (var currentUganda in ugandas)
        {
            
        }   
    }

	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.S))
	    {
	        GameObject obj = Instantiate(ugandaPrefab) as GameObject;

	        ugandas.Add(obj.GetComponent<uganda>());

	    }
	}
}
