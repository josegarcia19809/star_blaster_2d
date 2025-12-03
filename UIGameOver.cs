using System;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        //scoreKeeper = ScoreKeeper.GetInstance();
    }

    void Start()
    {
        scoreText.text = "FINAL SCORE: \n" + ScoreKeeper.GetInstance().GetCurrentScore().ToString();
        //scoreKeeper = ScoreKeeper.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
    }
}