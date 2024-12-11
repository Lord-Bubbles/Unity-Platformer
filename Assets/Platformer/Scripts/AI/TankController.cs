using StarterAssets;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float initialVelocity;

    public GameObject projectile;

    public Transform spawnPoint;

    public void AttackTarget()
    {
        var _projectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        _projectile.GetComponent<Rigidbody>().linearVelocity = initialVelocity * spawnPoint.up;
    }
}
