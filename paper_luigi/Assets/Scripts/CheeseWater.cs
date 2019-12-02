using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWater : MonoBehaviour
{
    public BoxCollider boxcol;

    void Start()
    {
        boxcol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Player")
        {
            boxcol.isTrigger = true;
        }
    }
}
