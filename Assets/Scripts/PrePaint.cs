using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePaint : MonoBehaviour
{
    public List<Paintable> p = new List<Paintable>();
    [HideInInspector]public bool done = false;
    // Start is called before the first frame update
    void Update()
    {
        if (done == false) {
            for (int i = 0; i < p.Count; i++) {
                PaintManager.instance.paint(p[i], transform.position, 3, 1, 1, Color.blue);
            }
            done = true;
        }
    }
}
