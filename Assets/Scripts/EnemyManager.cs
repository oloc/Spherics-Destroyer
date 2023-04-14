using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemies;
    [SerializeField]
    private GameObject _enemyWalker;
    [SerializeField]
    private GameObject _enemyShield;
    [SerializeField]
    private GameObject _enemyShooter;
    [SerializeField]
    private GameObject _enemyStartSpots;
    [SerializeField]
    private CurrentValues _currentValues;

    [Header("Parameters")]
    [SerializeField]
    private float _initialEnemyPopTime;

    private float _instantiationTime;
    private Transform[] _startPositions;
    private const int _randomEnemyTypeRate = 6;

    private void Awake()
    {
        _instantiationTime = Time.time;
        _startPositions = _enemyStartSpots.GetComponentsInChildren<Transform>();
        _currentValues.enemyPopTime = _initialEnemyPopTime;
    }

    private GameObject NewEnemyType()
    {
        int enemyType = Random.Range(0, _randomEnemyTypeRate);
        switch(enemyType)
        {
            case 0:
                return _enemyShooter;
            case 1 or 2:
                return _enemyShield;
        }
        return _enemyWalker;
    }

    private Vector3 NewPosition(GameObject enemy)
    {
        int positionIndex = Random.Range(1, _startPositions.Length);
        Transform spotTransform = _startPositions[positionIndex].transform;
        Vector3 position = spotTransform.position;
        position.y = enemy.transform.localScale.y / 2;
        return position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _instantiationTime + _currentValues.enemyPopTime)
        {
            GameObject newEnemyType = NewEnemyType();
            GameObject newEnemy = Instantiate(newEnemyType, _enemies.transform);
            Vector3 startPosition = NewPosition(newEnemyType);
            newEnemy.transform.position = startPosition;
            _instantiationTime = Time.time;
        }
    }
}
