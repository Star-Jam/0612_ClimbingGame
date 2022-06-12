using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    bool _isStarted = false;

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
        OnGameClear?.Invoke();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
