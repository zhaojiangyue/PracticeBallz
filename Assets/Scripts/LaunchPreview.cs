using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStartPoint;

    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPoint = worldPoint;
        // print("DragStartPoint is " + dragStartPoint);
        // lineRenderer.SetPosition(0,dragStartPoint);
        // lineRenderer.SetPosition(0,new Vector3(0f,0f,0f));
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        Vector3 pointOffset = worldPoint - dragStartPoint;
        // print("DragOffsetPoint is " + pointOffset);

        Vector3 endPoint = transform.position + pointOffset;

        // lineRenderer.SetPosition(1, endPoint);
        // lineRenderer.SetPosition(1, new Vector3(5f,5f,5f));
    }
}
