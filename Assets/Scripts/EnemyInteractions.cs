using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour
{
    [SerializeField]
    private CurrentValues _currentValues;
    [SerializeField]
    private int _life;

    private const string TAG_BULLET = "Bullet";
    private const string TAG_PLAYER = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        // Pour le Walker
        if (collision.collider.CompareTag(TAG_PLAYER))
        {
            _currentValues.playerLife--;
        }
    }

    private void OnDestroy()
    {
        _currentValues.enemyCount--;
    }

    private GameObject FindPartToDestroy(GameObject gameObject)
    {
        List<string> orderedParts = new List<string> { "Shield", "Cockpit", "Body" };
        foreach (string part in orderedParts)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == part)
                {
                    // Debug.Log($"Found: {child.gameObject.name}");
                    return child.gameObject;
                }
            }
        }
        return gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TAG_PLAYER)
        {
            _currentValues.playerLife--;
        }

        if (other.tag == TAG_BULLET)
        {
            _currentValues.score++;
            _life--;
            if (_life <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                GameObject toDestroy = FindPartToDestroy(gameObject);
                // Debug.Log($"Life: {_life}, To destroy: {toDestroy}, Other ID: {other.GetInstanceID()}");
                Destroy(toDestroy);
            }
        }
    }
}
