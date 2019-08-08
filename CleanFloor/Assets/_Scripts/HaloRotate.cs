using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloRotate : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    private int speed = 60;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
    }
}
