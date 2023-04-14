using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    public GameObject _bulletPrefab;
    [SerializeField]
    public Transform _cannonTransform;
    [SerializeField]
    public float _delayBetweenShots;
    [SerializeField]
    public AudioClip _bulletShotAudioClip;

    private float _nextShotTime;
    private AudioSource _audioSource;

    private void Awake()
    {
        _nextShotTime = Time.time;
        _audioSource = GetComponent<AudioSource>();
    }
    private void FireBullet()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _cannonTransform);
        newBullet.transform.position = _cannonTransform.position;
        newBullet.transform.rotation = _cannonTransform.rotation;
        Bullet bullet = newBullet.GetComponent<Bullet>();

        _audioSource.clip = _bulletShotAudioClip;
        float randomPitch = Random.Range(0.95f, 1.05f);
        _audioSource.pitch = randomPitch;
        _audioSource.Play();
    }

    public void TryToShoot()
    {
        if (Time.time > _nextShotTime)
        {
            if (_cannonTransform != null)
            {
                FireBullet();
                _nextShotTime = Time.time + _delayBetweenShots;
            }
        }
    }

}
