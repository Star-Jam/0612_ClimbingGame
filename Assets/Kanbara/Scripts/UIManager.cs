using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    [Header("ゲーム開始前に表示するパネル")]
    GameObject _gameStartBeforePanel;

    [SerializeField]
    [Header("ゲームクリア時のパネル")]
    GameObject _gameClearPanel;

    [SerializeField]
    [Header("ゲームオーバー時のパネル")]
    GameObject _gameOverPanel;

    private void Start()
    {
        _gameClearPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        GameManager.Instance.OnGameClear += () => _gameClearPanel.SetActive(true);
        GameManager.Instance.OnGameOver += () => _gameOverPanel.SetActive(true);
    }
}
