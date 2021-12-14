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
    private List<Ball> balls = new List<Ball>();

    [SerializeField] private Ball ballPrefab;
    private int _ballsReady;
    private BlockSpawner _blockSpawner;

    private void Awake()
    {
        _blockSpawner = FindObjectOfType<BlockSpawner>();
        _launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
    }

    void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        balls.Add(ball);
        _ballsReady++;

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
        StartCoroutine(LaunchBalls());
        
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = _endPosition - _startPosition;
        direction.Normalize();
        
        foreach (var VARIABLE in balls)
        {
            // var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            VARIABLE.transform.position = transform.position;
            VARIABLE.gameObject.SetActive(true);
            VARIABLE.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        }

        _ballsReady = 0;
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

    public void ReturnBall()
    {
        _ballsReady++;
        if (_ballsReady==balls.Count)
        {
            _blockSpawner.SpawnRowOfBlocks();
            CreateBall();
        }
    }
}
