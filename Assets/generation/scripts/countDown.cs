using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour
{
    float time = 2f;
    private Image img;
    private GameObject umanager;

	void Start ()
	{
	    img = GetComponent<Image>();
	    img.fillAmount = 1.1f;
	    umanager = GameObject.Find("ugandaManager");
	}
	
	void Update ()
	{
	    img.fillAmount -= Time.deltaTime / time;
	    if (img.fillAmount <= 0f)
	    {
	        img.fillAmount = 1.1f;
            umanager.SendMessage("PopUganda");
	    }
	}
}
