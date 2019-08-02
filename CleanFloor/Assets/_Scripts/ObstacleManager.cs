using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleManager : MonoBehaviour
{
    public Obstacle[] obstacles = new Obstacle[0];

    Queue<Vector3> shuffledPossiblePositions;
    public int obstacleCount = 4;


    public void CreateObstacles()
    {
        //gets possible object positions from room prefab
        var possiblePositions = GetPossibleObstaclePositions();

        //random shuffle all possiblepositions Random changes with seed( seed also changes with levelnumber)
        shuffledPossiblePositions = new Queue<Vector3>(RandomNumberGenerator.ShuffleArray(possiblePositions));

        for (int i = 0; i < obstacleCount; i++)
        {
            Instantiate(obstacles[0], GetRandomPosition(), Quaternion.identity);
        }
    }
    public Vector3[] GetPossibleObstaclePositions()
    {
        var possiblegameObjects = GameObject.FindGameObjectsWithTag("ObstaclePos");

        Vector3[] positions = new Vector3[possiblegameObjects.Length];

        for (int i = 0; i < possiblegameObjects.Length; i++)
        {
            positions[i] = possiblegameObjects[i].transform.position;
        }

        return positions;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPos = shuffledPossiblePositions.Dequeue();

        //shuffledPossiblePositions.Enqueue(randomPos);

        return randomPos;
    }
}
