using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAudio : MonoBehaviour
{
    public GameObject clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        clip.SetActive(true);
    }
}
