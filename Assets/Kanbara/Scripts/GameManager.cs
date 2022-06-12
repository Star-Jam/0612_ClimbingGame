using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsStarted => _isStarted;
    public bool IsGameEnd => _isGameEnd;

    bool _isStarted = false;
    bool _isGameEnd = false;

    public Action OnGameStart;
    public Action OnGameClear;
    public Action OnGameOver;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (_isStarted) return;
        if(Input.GetButton("Jump"))
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        _isStarted = true;
        OnGameStart?.Invoke();
    }

    public void GameClear()
    {
        _isGameEnd = true;
        OnGameClear?.Invoke();
    }

    public void GameOver()
    {
        _isGameEnd = true;
        OnGameOver?.Invoke();
    }
}
