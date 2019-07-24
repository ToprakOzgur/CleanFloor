using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{

    public Text angleText;
    public Text zDistanceText;
    public Text yDistanceText;

    public Movement movement;

    public CameraFollow camfollow;

    public Rotator rotator;
    // Start is called before the first frame update


    void Start()
    {
        angleText.text = Camera.main.transform.eulerAngles.x.ToString();
        zDistanceText.text = Camera.main.transform.position.z.ToString();
        yDistanceText.text = Camera.main.transform.position.y.ToString();
    }
    public void RestartScreen()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("restart");
    }

    public void drag()
    {
        Debug.Log("Darg");
    }
    public void IncreaseSpeed()
    {
        movement.Speed++;
        angleText.text = movement.Speed.ToString();

    }
    public void DecreaseSpeed()
    {
        movement.Speed--;
        angleText.text = movement.Speed.ToString();
    }

    public void IncreaseRotSpeed()
    {
        rotator.rotationSpeed++;
        zDistanceText.text = rotator.rotationSpeed.ToString();

    }
    public void DecreaseRootSpeed()
    {
        rotator.rotationSpeed--;
        zDistanceText.text = rotator.rotationSpeed.ToString();
    }
    public void DecreaseAngle()
    {
        float x = Camera.main.transform.eulerAngles.x;
        Debug.Log(x);
        Camera.main.transform.eulerAngles = new Vector3(x - 1, 0, 0);
        camfollow.ChangePos();
        angleText.text = Camera.main.transform.eulerAngles.x.ToString();
    }

    public void inreaseAngle()
    {
        float x = Camera.main.transform.eulerAngles.x;
        Debug.Log(x);
        Camera.main.transform.eulerAngles = new Vector3(x + 1, 0, 0);
        camfollow.ChangePos();
        angleText.text = Camera.main.transform.eulerAngles.x.ToString();
    }

    public void DecreaseUzaklik()
    {
        Vector3 old = Camera.main.transform.position;

        Camera.main.transform.position = new Vector3(old.x, old.y, old.z - 1);
        camfollow.ChangePos();
        zDistanceText.text = Camera.main.transform.position.z.ToString();
    }

    public void increaseUzaklik()
    {
        Vector3 old = Camera.main.transform.position;

        Camera.main.transform.position = new Vector3(old.x, old.y, old.z + 1);
        camfollow.ChangePos();
        zDistanceText.text = Camera.main.transform.position.z.ToString();
    }

    public void DecreaseYukseklik()
    {
        Vector3 old = Camera.main.transform.position;

        Camera.main.transform.position = new Vector3(old.x, old.y - 1, old.z);
        camfollow.ChangePos();
        yDistanceText.text = Camera.main.transform.position.y.ToString();
    }
    public void increaseYukseklik()
    {
        Vector3 old = Camera.main.transform.position;

        Camera.main.transform.position = new Vector3(old.x, old.y + 1, old.z);
        camfollow.ChangePos();
        yDistanceText.text = Camera.main.transform.position.y.ToString();

    }

}
