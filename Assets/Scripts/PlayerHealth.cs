using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private CurrentValues _currentValues;
    [SerializeField]
    private Settings _settings;

    private void Awake()
    {
        _currentValues.playerLife = _settings.playerStartLives;
    }
}
