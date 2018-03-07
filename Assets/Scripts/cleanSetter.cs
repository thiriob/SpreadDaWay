using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanSetter : MonoBehaviour {

	void Start ()
	{
	    var obj = GameObject.Find("settings");
		if (obj)
            Destroy(obj);
	}
}
