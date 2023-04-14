using UnityEngine;

public class PlayerShoot : Shoot
{
    private const string FIRE_INPUT_NAME = "Fire1";


    private void Update()
    {
        if (Input.GetButton(FIRE_INPUT_NAME))
        {
            TryToShoot();
        }
    }
}
