using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(PowerUpManager))]
public class ObstacleManager : MonoBehaviour
{
    public int obstacleCount = 4;
    public Obstacle[] obstacles = new Obstacle[0];

    Queue<Vector3> shuffledPossiblePositions;
    Queue<Obstacle> shuffledObstacles;
    private PowerUpManager powerUpManager;


    private void Awake()
    {
        powerUpManager = GetComponent<PowerUpManager>();
    }
    public void CreateObstacles(RoomType roomType)
    {
        //gets possible object positions from room prefab
        var possiblePositions = GetPossibleObstaclePositions();

        //random shuffle all possiblepositions Random changes with seed( seed also changes with levelnumber)
        shuffledPossiblePositions = new Queue<Vector3>(RandomNumberGenerator.ShuffleArray(possiblePositions));

        //shuffle obstacles array
        var roomSpecificObstacles = new List<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            if (obstacle.roomType.Any(x => x == roomType || x == RoomType.Common))
            {
                roomSpecificObstacles.Add(obstacle);
            }
        }
        shuffledObstacles = new Queue<Obstacle>(RandomNumberGenerator.ShuffleArray(roomSpecificObstacles.ToArray()));

        for (int i = 0; i < obstacleCount; i++)
        {
            var obs = GetRandomObstacle();
            var pos = GetRandomPosition();
            obs.gameObject.transform.position = pos;
            obs.gameObject.SetActive(true);
        }


        powerUpManager.StartSpawnPowerUpLoop(shuffledPossiblePositions);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPos = shuffledPossiblePositions.Dequeue();

        shuffledPossiblePositions.Enqueue(randomPos);

        return randomPos;
    }


    private Obstacle GetRandomObstacle()
    {
        Obstacle randomObs = shuffledObstacles.Dequeue();

        shuffledObstacles.Enqueue(randomObs);

        return randomObs;
    }
    public Vector3[] GetPossibleObstaclePositions()
    {
        var possiblegameObjects = GameObject.FindGameObjectsWithTag("ObstaclePos");

        Vector3[] positions = new Vector3[possiblegameObjects.Length];

        for (int i = 0; i < possiblegameObjects.Length; i++)
        {
            positions[i] = possiblegameObjects[i].transform.position;
        }

        foreach (var item in possiblegameObjects)
        {
            item.SetActive(false);
        }

        return positions;
    }
}
