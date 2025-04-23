using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;

    public void restart()
    {
        SceneManager.LoadScene("Test_scene");
    }
    public void exit()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(player.gameObject);
            menu.SetActive(true);
        }
    }
}
