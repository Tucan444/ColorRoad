using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GizmosCirclesM : MonoBehaviour
{
    public float gizmosRadius = 0.5f;
    public static List<Gircle> gircles = new List<Gircle>();

    void SetSizes() {
        for (int i = 0; i < gircles.Count; i++) {
            gircles[i].radius = gizmosRadius;
        }
    }

    void OnEnable() {
        SetSizes();
    }

    void OnValidate() {
        SetSizes();
    }
}
