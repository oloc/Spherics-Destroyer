using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreBoard;
    [SerializeField]
    private TextMeshProUGUI _bonusBoard;
    [SerializeField]
    private CurrentValues _currentValues;
    [SerializeField]
    private GameObject _ground;
    [SerializeField]
    private Material[] _groundMaterials;

    [Header("Parameters")]
    [Tooltip("Cumulative bonus earn when all enemies are killed.")]
    [SerializeField]
    private int _initialBonus;
    [Tooltip("Each time all enemies are killed, this factor modifies the pop period (tips: set it between 0.1 and 1).")]
    [SerializeField]
    private float _enemyPopFactor;
    [SerializeField]
    private float _timeToFade;

    [Header("Colors")]
    [SerializeField]
    private Color _loseColor;
    [SerializeField]
    private Color _scoreColor;
    [SerializeField]
    private Color _bonusColor;

    private int _bonus;
    private bool _bonusEnable;
    private int _bonusFactor = 1;

    private void Start()
    {
        _currentValues.score = 0;
        _bonus = _initialBonus;
        _bonusBoard.text = "";
        _ground.GetComponent<MeshRenderer>().material = _groundMaterials[0];
    }

    private void Lose()
    {
        _scoreBoard.color = _loseColor;
        _scoreBoard.text = "Perdu !";
        SceneManager.LoadScene("LoseScene");
    }

    private void Bonus()
    {
        if (_bonusEnable)
        {
            _bonus = _initialBonus * _bonusFactor;
            StartCoroutine(BonusDisplay(_timeToFade));
            _currentValues.score += _bonus;
            if (_bonusFactor < _groundMaterials.Length)
            {
                _ground.GetComponent<MeshRenderer>().material = _groundMaterials[_bonusFactor];
            }
            _currentValues.enemyPopTime *= _enemyPopFactor;
            _bonusFactor++;
            _bonusEnable = false;
        }
    }


    private IEnumerator BonusDisplay(float timeToFade)
    {
        float timer = 0f;
        while (timer < timeToFade)
        {
            _bonusBoard.color = _bonusColor;
            _bonusBoard.text = "+ " + _bonus.ToString();
            _bonusBoard.enabled = true;
            Debug.Log($"Bonus: {_bonusBoard.text}");
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _bonusBoard.enabled = false;
    }

    private void Update()
    {
        if (_currentValues.enemyCount <= 0)
        {
            Bonus();
        }
        if (_currentValues.playerLife <= 0)
        {
            Lose();
        }
        if (_currentValues.enemyCount > 0 && _currentValues.playerLife > 0)
        {
            _scoreBoard.color = _scoreColor;
            _scoreBoard.text = _currentValues.score.ToString();
            _bonusEnable = true;
        }
    }
}
