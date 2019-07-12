using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{

    public Text speedText;
    public Movement movement;
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
    public void IncreaseSpeed()
    {
        movement.Speed++;
        speedText.text = movement.Speed.ToString();

    }
    public void DecreaseSpeed()
    {
        movement.Speed--;
        speedText.text = movement.Speed.ToString();
    }
}
