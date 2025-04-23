using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Trap : MonoBehaviour
{
    public GameObject[] trap;
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < trap.Length; i++)
        {
            if (trap[i].tag == "Player")
            {
                SceneManager.LoadScene("Test_scene");
            }
        }
    }
}
