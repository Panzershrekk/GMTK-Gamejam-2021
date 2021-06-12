using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDisplay : MonoBehaviour
{
    public Transform originPos;
    public Transform destPos;
    public LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, new Vector3(originPos.position.x, originPos.position.y, 0));
        lineRenderer.SetPosition(1, new Vector3(destPos.position.x, destPos.position.y, 0));

    }
}
