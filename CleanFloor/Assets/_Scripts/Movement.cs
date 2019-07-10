using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    private Rigidbody myRigidbody;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {

        //transform.position += transform.up * Time.deltaTime * moveSpeed;
        myRigidbody.position += -transform.forward * Time.deltaTime * moveSpeed;

    }
}