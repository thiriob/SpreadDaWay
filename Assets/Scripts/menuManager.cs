using UnityEngine;

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
