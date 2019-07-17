using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustGenerator : MonoBehaviour
{
    [SerializeField] private GameObject dust = null;
    [SerializeField] private int xDistance = 0;
    [SerializeField] private int yDistance = 0;
    [SerializeField] private LevelGenerator levelGenerator;
    void Start()
    {
        var roomWidth = Mathf.CeilToInt(levelGenerator.room.width * 5) - 1;
        var roomLength = Mathf.CeilToInt(levelGenerator.room.length * 5) - 1;

        for (int i = -roomWidth; i < roomWidth; i += xDistance)
        {
            for (int k = -roomLength; k < roomLength; k += yDistance)
            {
                Vector3 pos = new Vector3(i, 0, k);
                var newDust = GameObject.Instantiate(dust, pos, Quaternion.identity);
                newDust.transform.SetParent(this.gameObject.transform);

            }
        }
    }
}
