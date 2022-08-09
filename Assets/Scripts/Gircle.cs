using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Gircle : MonoBehaviour
{
    [HideInInspector]public float radius = 0.5f;
    // Start is called before the first frame update
    void OnEnable()
    {
        GizmosCirclesM.gircles.Add(this);
    }

    // Update is called once per frame
    void OnDisable()
    {
        GizmosCirclesM.gircles.Remove(this);
    }
    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
