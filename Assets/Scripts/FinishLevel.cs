using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLevel : SingletonBehaviourBase<FinishLevel>
{
    [SerializeField] private TextMeshProUGUI endscreenTest;
    [SerializeField] private GameObject startButton;
    
    public void DisableStartButton()
    {
        startButton.SetActive(false);
    }
    
    public void Start()
    {
        endscreenTest.enabled = false;
    }

    public void Win()
    {
        endscreenTest.text = "YOU WON";
        endscreenTest.enabled = true;
    }

    public void Lose()
    {
        StartCoroutine(LoseCoroutine());
    }

    private IEnumerator LoseCoroutine()
    {
        endscreenTest.text = "YOU LOST... Try again?";
        endscreenTest.enabled = true;

        yield return new WaitForSeconds(3);
        endscreenTest.enabled = false;

        startButton.SetActive(true);
    }
}
