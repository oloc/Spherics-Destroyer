using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _bulletLifeTime;

    private float _instantiationTime;

    private void Awake()
    {
        _instantiationTime = Time.time;
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Time.time > _instantiationTime + _bulletLifeTime)
        {
            Destroy(gameObject);
        }

        Vector3 velocity = _transform.forward * Time.fixedDeltaTime * _bulletSpeed;
        Vector3 newPosition = _rigidbody.position + velocity;
        _rigidbody.MovePosition(newPosition);
    }

}