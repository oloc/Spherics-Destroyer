using UnityEngine;

public class EnemyBullet : Bullet
{

    [SerializeField]
    CurrentValues _currentValues;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        switch (other.tag)
        {
            case "Wall" or "Bullet":
                Destroy(gameObject);
                break;
            case "Player":
                Destroy(gameObject);
                _currentValues.playerLife--;
                break;
            case "Enemy" or "Other":
                break;
            default:
                Debug.LogError($"Tag is not recognized for {other.name}");
                break;
        }
    }
}
