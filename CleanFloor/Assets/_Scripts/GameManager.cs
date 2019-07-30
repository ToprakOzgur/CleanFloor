using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Game game;

    public static int MaxRobotHealth = 45;
    private void Awake()
    {
        game = new Game();
    }
    private void Start()
    {

    }
}
