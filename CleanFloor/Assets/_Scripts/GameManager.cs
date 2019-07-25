using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Game game;
    private void Awake()
    {
        game = new Game();
    }
    private void Start()
    {

    }
}
