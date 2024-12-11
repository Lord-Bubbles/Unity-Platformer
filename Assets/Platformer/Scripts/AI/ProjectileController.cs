using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float airTime;

    private HealthManager healthWidget;

    public GameObject explosion;

    void Start()
    {
        healthWidget = HealthManager.instance;
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(airTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var knockback = other.gameObject.GetComponent<Knockback>();
            knockback.AddImpact(transform.position - other.gameObject.transform.position);
            healthWidget.TakeDamage(20);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
