using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NbPeople : MonoBehaviour
{
    private Text nbpeople;
    private float timer = 1f;

	void Start ()
	{
	    nbpeople = GameObject.Find("NbPeople").GetComponent<Text>();
	}
	
	void Update ()
	{
	    if (timer >= 0f)
	        timer -= Time.deltaTime;
	    nbpeople.text = transform.childCount.ToString();
        if (transform.childCount <= 0 && timer <= 0f)
            SceneManager.LoadScene("Win");
    }
}
