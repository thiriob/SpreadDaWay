using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ugandaManager : MonoBehaviour
{
    public GameObject ugandaPrefab;

    public List<GameObject> ugandas = new List<GameObject>();
    public Text nbUganda;
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
        if (ugandas.Count > 0)
        {
            Destroy(ugandas.ElementAt(0));
            ugandas.RemoveAt(0);
        }
    }

	void Update ()
	{
	    nbUganda.text = ugandas.Count.ToString();
        if (Input.GetKeyDown(KeyCode.A))
            sayQueen();
    }
}
