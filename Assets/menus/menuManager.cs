using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject Setter;

    public void onExitClicked() {
        Application.Quit();
    }

    public void onStartClicked() {
        Setter.SendMessage("Load");
        //SceneManager.LoadScene("movements");
    }
}
