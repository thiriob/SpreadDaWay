using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public bool LoadScene = false;
    public string[] Prefs = { };
    public Dictionary<string, string> Params = new Dictionary<string, string>();

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (!LoadScene)
            Load();
    }

    public void Load()
    {
        for (int i = 0; i < Prefs.Length; i += 2)
            Params.Add(Prefs[i], Prefs[i + 1]);
        if (LoadScene)
            SceneManager.LoadScene("MainGame");
    }
}
