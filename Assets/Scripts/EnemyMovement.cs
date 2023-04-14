using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask _playerLayerMask;
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _rotationSpeed = 30f; // Angular speed in degrees per sec.
    [SerializeField]
    private CurrentValues _currentValues;

    private Transform _playerTransform;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _currentValues.enemyCount++;
    }

    private void FixedUpdate()
    {
        TurnTowardsPlayer();
        _rigidBody.velocity = transform.forward * _speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Player detection
        Collider[] colliders = Physics.OverlapSphere(transform.position, 50f, _playerLayerMask);
        if(colliders.Length > 0)
        {
            _playerTransform = colliders[0].transform;
        }
    }

    void TurnTowardsPlayer()
    {
        if(_playerTransform.position != null) { 
            // Debug.Log($"_playerTransform.position: {_playerTransform.position}, transform.position: {transform.position}");
            Vector3 direction = _playerTransform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion lookRotation = Quaternion.RotateTowards(_rigidBody.rotation, targetRotation, _rotationSpeed);
            _rigidBody.MoveRotation(lookRotation);
        }
    }
}