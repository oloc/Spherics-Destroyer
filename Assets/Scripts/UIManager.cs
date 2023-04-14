using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private CurrentValues _currentValues;
    [Header("Lives")]
    [SerializeField]
    private Transform _heartsParent;
    [SerializeField]
    private GameObject _heartPrefab;

    List<GameObject> _heartGameObjects = new List<GameObject>();

    private void AddHearts(int lives)
    {
        for(int i = 0; i < lives; i++) {
            InstantiateHeart();
        }
    }
    private void InstantiateHeart()
    {
        _heartGameObjects.Add(Instantiate(_heartPrefab, _heartsParent));
    }

    // Start is called before the first frame update
    void Start()
    {
        AddHearts(_currentValues.playerLife);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentValues.playerLife < _heartGameObjects.Count) {
            GameObject heartToRemove = _heartGameObjects[_currentValues.playerLife];
            _heartGameObjects.Remove(heartToRemove);
            Destroy(heartToRemove);
        } else if (_currentValues.playerLife > _heartGameObjects.Count) {
            AddHearts(_currentValues.playerLife);
        }
    }
}
