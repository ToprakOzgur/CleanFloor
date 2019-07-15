using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustGenerator : MonoBehaviour
{
    [SerializeField] private GameObject dust = null;
    [SerializeField] private int xDistance = 0;
    [SerializeField] private int yDistance = 0;
    [SerializeField] private int roomWeight = 0;
    [SerializeField] private int roomHeight = 0;


    [HideInInspector] public List<GameObject> AllDust = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -roomWeight; i < roomWeight; i += xDistance)
        {
            for (int k = -roomHeight; k < roomHeight; k += yDistance)
            {
                Vector3 pos = new Vector3(i, 0, k);
                var newDust = GameObject.Instantiate(dust, pos, Quaternion.identity);
                newDust.transform.SetParent(this.gameObject.transform);
                AllDust.Add(newDust);
            }
        }
    }
}
