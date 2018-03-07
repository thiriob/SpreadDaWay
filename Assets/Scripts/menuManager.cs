using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject Setter;

    public void onExitClicked() {
        Application.Quit();
    }

    public void onStartClicked() {
    }

    public void loadScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
