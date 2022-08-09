using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class PaintRoad : MonoBehaviour
{
    public float radius = 2;
    public List<Paintable> p = new List<Paintable>();

    Vector3 offset;
    private XROrigin xROrigin;
    // Start is called before the first frame update
    void Start()
    {
        xROrigin = GetComponent<XROrigin>();
        offset = xROrigin.CameraInOriginSpacePos;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < p.Count; i++) {
            PaintManager.instance.paint(p[i], transform.position + offset, radius, 1, 1, Color.blue);
        }
    }

    public void ClearRoad() {
        for (int i = 0; i < p.Count; i++) {
            p[i].OnDisable();
            p[i].Start();
        }
    }
}
