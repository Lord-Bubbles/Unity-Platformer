using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotationSpeed = 75f;

    private float angle = 0f;

    private ScoreManager scoreWidget;

    void Start()
    {
        scoreWidget = ScoreManager.instance;
    }

    void Update()
    {
        var spin = Quaternion.Euler(0, angle, 0);
        angle = (angle + rotationSpeed * Time.deltaTime) % 360f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, spin, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreWidget.UpdateScore(1);
            Destroy(gameObject);
        }
    }

}
