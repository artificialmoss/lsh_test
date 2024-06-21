using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private bool ballActive = false;
    private GameObject _ball;
    private Rigidbody _rigidBody;
    private FinishLevel _finishLevel;
    
    [SerializeField] private Vector3 ballStartVelocity = new Vector3(-3, 0, -3);

    public void Start()
    {
        _ball = GameObject.FindWithTag("ball");
        _ball.AddComponent<FinishLevel>();
        _finishLevel = _ball.GetComponent<FinishLevel>();
        _ball.AddComponent<Rigidbody>();
        _rigidBody = _ball.GetComponent<Rigidbody>();
        ResetBall();
    }

    private void ResetBall()
    {
        ballActive = false;
        _rigidBody.Sleep();
        _ball.transform.position = new Vector3();
    }
    
    public void InitiateBall()
    {
        ResetBall();
        _rigidBody.WakeUp();
        _rigidBody.velocity = ballStartVelocity;
        GameObject.FindWithTag("start_button").SetActive(false);
        ballActive = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        ballActive = false;
        _finishLevel.Win();
    }
    
    public void Update()
    {
        double eps = 1e-9;
        if (ballActive && _rigidBody.velocity.magnitude < eps)
        {
            ballActive = false;
            _finishLevel.Lose();
        }
    }
}
