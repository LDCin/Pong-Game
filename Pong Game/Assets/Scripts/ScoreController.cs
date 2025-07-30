using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController _instance;
    [SerializeField] public Player _player;
    [SerializeField] public Player _enemy;
    [SerializeField] private TextMeshProUGUI _playerScore;
    [SerializeField] private TextMeshProUGUI _enemyScore;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        _playerScore.text = "0";
        _enemyScore.text = "0";
    }
    public void ChangeScore(Player player)
    {
        player.IncreaseScore();
        if (player.CompareTag("Player"))
        {
            _playerScore.text = player.GetScore().ToString();
        }
        else if (player.CompareTag("Enemy"))
        {
            _enemyScore.text = player.GetScore().ToString();
        }
    }
}
