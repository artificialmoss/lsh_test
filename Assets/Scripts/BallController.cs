using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private bool ballActive = false;
    
    private Rigidbody _rigidBody;
    
    [SerializeField] private Vector3 ballStartVelocity = new Vector3(-3, 0, -3);
    [SerializeField] private Vector3 ballStartPosition = new Vector3(0, 0.5f, 0);

    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        ResetBall();
    }

    private void ResetBall()
    {
        ballActive = false;
        _rigidBody.Sleep();
        Console.WriteLine(transform.position.ToString());
        Console.WriteLine(ballStartPosition.ToString());
        transform.position = ballStartPosition;
    }
    
    public void InitiateBall()
    {
        ResetBall();
        _rigidBody.WakeUp();
        _rigidBody.velocity = ballStartVelocity;
        FinishLevel.instance.DisableStartButton();
        ballActive = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        ballActive = false;
        FinishLevel.instance.Win();
    }

    private bool BallHasStopped()
    {
        const double comparisonPrecision = 1e-9;
        return ballActive && _rigidBody.velocity.magnitude < comparisonPrecision;
    }
    
    public void Update()
    {
        Console.WriteLine(_rigidBody.velocity.magnitude);
        if (BallHasStopped())
        {
            ballActive = false;
            FinishLevel.instance.Lose();
        }
    }
}
