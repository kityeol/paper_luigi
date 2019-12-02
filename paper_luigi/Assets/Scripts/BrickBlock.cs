using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    public BoxCollider boxcol;
    public MeshRenderer meshren;
    public ParticleSystem breakfx;
    public float maxTimer;
    private float timer;
    void Start()
    {
        timer = maxTimer;
    }

    void Update()
    {
        boxcol = GetComponent<BoxCollider>();
        meshren = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            breakfx.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        boxcol.enabled = false;
        meshren.enabled = false;
    }
}