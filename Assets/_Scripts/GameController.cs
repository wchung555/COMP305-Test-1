﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    // private instance variables
    private int _score = 0;
    private int _lives = 5;
    private int _currentEnemyCount = 0;
    private int _highScore = 0;
    private GameObject _txtScore, _txtLives, _txtGameOver, _txtHighScore, _btnRestart;
    private GameObject _player;

    // PUBLIC INSTANCE VARIABLES
    public int enemyCount;
    public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        this._txtScore = GameObject.Find("Score");
        this._txtLives = GameObject.Find("Hull Points");
        this._player = GameObject.FindGameObjectWithTag("Player");

        this._txtGameOver = GameObject.Find("Game Over");
        this._txtHighScore = GameObject.Find("High Score");
        this._btnRestart = GameObject.Find("Restart Button");

        this._txtGameOver.SetActive(false);
        this._txtHighScore.SetActive(false);
        this._btnRestart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this._lives >= 0)
        {
            this._GenerateEnemies();
            this._txtScore.GetComponent<Text>().text = "Score: " + this._score;
            this._txtLives.GetComponent<Text>().text = "Hull Points: " + this._lives;
        }

        else
        {
            this._player.SetActive(false);

            this._txtGameOver.SetActive(true);
            this._txtHighScore.SetActive(true);
            this._btnRestart.SetActive(true);

            if (this._score > this._highScore)
            {
                this._highScore = this._score;
            }

            this._txtHighScore.GetComponent<Text>().text = "High Score: " + this._highScore;
        }
    }

    // generate Clouds
    private void _GenerateEnemies()
    {
        while (this._currentEnemyCount < this.enemyCount)
        {
            Instantiate(enemy);
            this._currentEnemyCount++;
        }
    }

    public void DamageHull()
    {
        this._lives--;
        this._currentEnemyCount--;
    }

    public void AvoidFighter()
    {
        if (this._lives > 0)
            this._score += 10;
    }

    public void BtnRestart_onClick()
    {
        this._score = 0;
        this._lives = 5;

        this._txtGameOver.SetActive(false);
        this._txtHighScore.SetActive(false);
        this._btnRestart.SetActive(false);
        this._player.SetActive(true);

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(e);
        }
        this._currentEnemyCount = 0;
    }
}
