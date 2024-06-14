using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private TextMeshProUGUI _endscreenTest;
    private GameObject _startButton;
    public void Start()
    {
        GameObject obj = GameObject.FindWithTag("endscreen_text");
        _endscreenTest = obj.GetComponent<TextMeshProUGUI>();
        _endscreenTest.text = "";
        _startButton = GameObject.FindWithTag("start_button");
    }

    public void Win()
    {
        _endscreenTest.text = "YOU WON";
    }

    public void Lose()
    {
        StartCoroutine(LoseCoroutine());
    }

    private IEnumerator LoseCoroutine()
    {
        _endscreenTest.text = "YOU LOST... Try again?";
        yield return new WaitForSeconds(2);
        _endscreenTest.text = "";
        _startButton.SetActive(true);
    }
}
