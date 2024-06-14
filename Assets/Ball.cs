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
    
    [SerializeField] private Vector3 ballStartVelocity = new Vector3(0, 0, 0);

    public void Start()
    {
        _ball = GameObject.FindWithTag("ball");
        _ball.AddComponent<FinishLevel>();
        _finishLevel = _ball.GetComponent<FinishLevel>();
    }
    
    public void InitiateBall()
    {
        _ball.AddComponent<Rigidbody>();
        _rigidbody = _ball.GetComponent<Rigidbody>();
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
        }
    }
}
