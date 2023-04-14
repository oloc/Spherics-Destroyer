using UnityEngine;

[CreateAssetMenu(fileName = "New CurrentValues", menuName = "Custom/CurrentValues")]
public class CurrentValues : ScriptableObject
{
    public int score;
    public float enemyPopTime;
    public int enemyCount;
    public int playerLife;
}
