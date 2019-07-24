using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Game game;
    private void Awake()
    {
        game = new Game();
    }
    private void Start()
    {

    }
}
