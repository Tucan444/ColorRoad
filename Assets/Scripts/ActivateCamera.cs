using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class shouldnt exist but theres weird bug where unity doesnt use camera by default
public class ActivateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.active = false;
        gameObject.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
