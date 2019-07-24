using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{

    public Material normalMaterial;
    public Material transparentMaterial;
    // Start is called before the first frame update
    private Renderer myRenderer;
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        myRenderer.material = transparentMaterial;
    }
    private void OnTriggerExit(Collider other)
    {

        myRenderer.material = normalMaterial;
    }

    public void BecomeTransparent()
    {
        throw new System.NotImplementedException();
    }
}
