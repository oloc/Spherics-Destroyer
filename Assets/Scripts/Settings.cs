using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Custom/Settings")]
public class Settings : ScriptableObject
{
    public int playerStartLives = 3;
    public int playerMaxLives = 5;
}
