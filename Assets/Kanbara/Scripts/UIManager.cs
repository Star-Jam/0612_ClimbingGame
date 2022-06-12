using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    [Header("�Q�[���J�n�O�ɕ\������p�l��")]
    GameObject _gameStartBeforePanel;

    [SerializeField]
    [Header("�Q�[���N���A���̃p�l��")]
    GameObject _gameClearPanel;

    [SerializeField]
    [Header("�Q�[���I�[�o�[���̃p�l��")]
    GameObject _gameOverPanel;

    private void Start()
    {
        _gameClearPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        GameManager.Instance.OnGameClear += () => _gameClearPanel.SetActive(true);
        GameManager.Instance.OnGameOver += () => _gameOverPanel.SetActive(true);
    }
}
