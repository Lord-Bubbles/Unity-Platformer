using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject self;

    private HealthManager healthWidget;

    void Start()
    {
        healthWidget = HealthManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var knockback = other.gameObject.GetComponent<Knockback>();

            if (gameObject.layer == LayerMask.NameToLayer("EnemyBody"))
            {
                knockback.AddImpact(other.gameObject.transform.position - self.transform.position);
                healthWidget.TakeDamage(20);
            }
            else if (gameObject.layer == LayerMask.NameToLayer("EnemyHead"))
            {
                Destroy(self);
            }
        }
    }
}
