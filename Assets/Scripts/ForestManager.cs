using UnityEngine.SceneManagement;
using UnityEngine;

public class ForestManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Cave");
        }
    }
}
