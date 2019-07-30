using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{

    [SerializeField] Transform target;
    private Vector3 direction;

    private void Awake()
    {
        direction = this.gameObject.transform.position - target.position;
    }
    void Update()
    {
        var newPos = target.transform.position + direction;
        transform.position = newPos;

    }
}
