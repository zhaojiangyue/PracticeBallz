using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private LaunchPreview _launchPreview;
    
    [SerializeField] private GameObject ballPrefab;

    private void Awake()
    {
        _launchPreview = GetComponent<LaunchPreview>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint((Input.mousePosition)) + Vector3.back * -10;
        
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }else if (Input.GetMouseButton(0))
        {
                ContinueDrag(worldPosition);
        } else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        Vector3 direction = _endPosition - _startPosition;
        direction.Normalize();

        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(-direction);
    }


    private void ContinueDrag(Vector3 worldPosition)
    {
        _endPosition = worldPosition;
        _launchPreview.SetEndPoint(_endPosition);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        _startPosition = worldPosition;
        _launchPreview.SetStartPoint(_startPosition);
    }
}
