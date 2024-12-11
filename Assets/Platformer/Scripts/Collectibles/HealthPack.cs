using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private ScoreManager scoreWidget;

    private HealthManager healthWidget;

    void Start()
    {
        scoreWidget = ScoreManager.instance;
        healthWidget = HealthManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreWidget.UpdateScore(1);
            healthWidget.Heal(20);
            Destroy(gameObject);
        }
    }
}

