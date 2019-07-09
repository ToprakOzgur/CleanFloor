using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    [SerializeField]
    protected float moveSpeed = 1f;

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        //  transform.position += -Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
