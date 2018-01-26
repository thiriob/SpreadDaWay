using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public string[] Prefs = { };
    public Dictionary<string, string> Params = new Dictionary<string, string>();

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        for (int i = 0; i < Prefs.Length; i += 2)
            Params.Add(Prefs[i], Prefs[i + 1]);
        //loadscene
        //SceneManager.LoadScene();
    }
}
