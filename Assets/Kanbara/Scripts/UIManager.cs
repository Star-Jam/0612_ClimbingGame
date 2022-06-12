using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public float Timer => _timer;

    [SerializeField]
    [Header("タイマー")]
    Text _timerText;

    [SerializeField]
    [Header("ゲーム開始前に表示するパネル")]
    GameObject _gameStartBeforePanel;

    [SerializeField]
    [Header("ゲームクリア時のパネル")]
    GameObject _gameClearPanel;

    [SerializeField]
    [Header("ゲームオーバー時のパネル")]
    GameObject _gameOverPanel;

    [SerializeField]
    [Header("リザルト画面に遷移するまでの秒数(ミリ秒)")]
    int _resultCount = 2000;
    
    float _timer = 0;

    private void Start()
    {
        _gameStartBeforePanel.SetActive(true);
        _gameClearPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        GameManager.Instance.OnGameStart += () => _gameStartBeforePanel.SetActive(false);
        GameManager.Instance.OnGameClear += () => GameEnd(_gameClearPanel);
        GameManager.Instance.OnGameOver += () => GameEnd(_gameOverPanel);
    }

    private void Update()
    {
        if(GameManager.Instance.IsGameEnd)
        {
            if(Input.GetButton("Jump"))
            {
                _resultCount = 0;
            }
        }
        if(GameManager.Instance.IsStarted && !GameManager.Instance.IsGameEnd)
        {
            _timer += Time.deltaTime;
            _timerText.text = _timer.ToString("f2");
        }
    }

    private async void GameEnd(GameObject panel)
    {
        panel.SetActive(true);
        await Task.Delay(_resultCount);
        SceneLoder.LoadScene("Rezult");
    }
}
