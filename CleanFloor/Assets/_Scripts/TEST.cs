using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void RestartScreen()
    {

        SceneManager.LoadScene("Game");
    }

    public void drag()
    {
        Debug.Log("Darg");
    }
}
