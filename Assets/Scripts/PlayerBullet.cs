using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall" or "Bullet":
                Destroy(gameObject);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
            case "Player" or "Other":
                break;
            default:
                Debug.LogError($"Tag is not recognized for {other.name}");
                break;
        }
    }
}
