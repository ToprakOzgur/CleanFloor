using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public TransparentChild[] transparentChild;
    public Material normalMaterial;
    public Material transparentMaterial;

    private Renderer myRenderer;
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Robot")
            return;
        myRenderer.material = transparentMaterial;
        foreach (var item in transparentChild)
        {
            item.GetComponent<Renderer>().material = item.transparentMaterial;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Robot")
            return;
        myRenderer.material = normalMaterial;

        foreach (var item in transparentChild)
        {
            item.GetComponent<Renderer>().material = item.normalMaterial;
        }
    }


}


