using UnityEngine;

public class KillZone : MonoBehaviour
{
    private HealthManager healthManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthManager = HealthManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthManager.currentState = PlayerState.Dead;
        }
        Destroy(other.gameObject);
    }
}
