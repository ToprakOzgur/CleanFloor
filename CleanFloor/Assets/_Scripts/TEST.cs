using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{

    public Text speedText;
    public Text rotSpeedText;
    public Movement movement;

    public Rotator rotator;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void RestartScreen()
    {

        SceneManager.LoadScene("Game");
        Debug.Log("restart");
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

    public void IncreaseRotSpeed()
    {
        rotator.rotationSpeed++;
        rotSpeedText.text = rotator.rotationSpeed.ToString();

    }
    public void DecreaseRootSpeed()
    {
        rotator.rotationSpeed--;
        rotSpeedText.text = rotator.rotationSpeed.ToString();
    }
}
