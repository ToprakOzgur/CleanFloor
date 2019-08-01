using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustPool : MonoBehaviour
{

    [SerializeField] private GameObject dustPrefab;
    private Queue<GameObject> dusts = new Queue<GameObject>();

    public static DustPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        AddDusts(1650);
    }
    public GameObject Get()
    {
        if (dusts.Count == 0)
        {
            AddDusts(1);
        }
        return dusts.Dequeue();
    }

    private void AddDusts(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject dust = Instantiate(dustPrefab);
            dust.SetActive(false);
            dusts.Enqueue(dust);
        }

    }

    public void ReturnToPool(GameObject dust)
    {
        dust.SetActive(false);
        dusts.Enqueue(dust);
    }
}