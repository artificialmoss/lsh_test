using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private bool ballInitiated = false;
    private GameObject _ball;
    private Rigidbody _rigidbody;
    private FinishLevel _finishLevel;
    
    [SerializeField] private Vector3 ballStartVelocity = new Vector3(-3, 0, -3);

    public void Start()
    {
        _ball = GameObject.FindWithTag("ball");
        _ball.AddComponent<FinishLevel>();
        _finishLevel = _ball.GetComponent<FinishLevel>();
        _ball.AddComponent<Rigidbody>();
        _rigidbody = _ball.GetComponent<Rigidbody>();
        ResetBall();
    }

    private void ResetBall()
    {
        ballInitiated = false;
        _rigidbody.Sleep();
        _ball.transform.position = new Vector3();
    }
    
    public void InitiateBall()
    {
        ResetBall();
        _rigidbody.WakeUp();
        _rigidbody.velocity = ballStartVelocity;
        GameObject.FindWithTag("start_button").SetActive(false);
        ballInitiated = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        ballInitiated = false;
        _finishLevel.Win();
    }
    
    public void Update()
    {
        double eps = 1e-9;
        if (ballInitiated && _rigidbody.velocity.magnitude < eps)
        {
            _finishLevel.Lose();
            ballInitiated = false;
        }
    }
}
