using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreBoard;
    [SerializeField]
    private CurrentValues _currentValues;

    void Start()
    {
        _scoreBoard.text = "Score: " + _currentValues.score.ToString();
    }
}