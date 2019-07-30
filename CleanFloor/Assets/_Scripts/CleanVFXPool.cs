using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanVFXPool : MonoBehaviour
{

    [SerializeField] private GameObject cleanVFXPrefab;
    private Queue<GameObject> cleanVFXs = new Queue<GameObject>();

    public static CleanVFXPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        AddCleanVFX(20);
    }
    public GameObject Get()
    {
        if (cleanVFXs.Count == 0)
        {
            AddCleanVFX(1);
        }
        return cleanVFXs.Dequeue();
    }

    private void AddCleanVFX(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject cleanVFX = Instantiate(cleanVFXPrefab);
            cleanVFX.SetActive(false);
            cleanVFXs.Enqueue(cleanVFX);
        }

    }

    public void ReturnToPool(GameObject cleanVFX)
    {
        cleanVFX.SetActive(false);
        cleanVFXs.Enqueue(cleanVFX);
    }
}
