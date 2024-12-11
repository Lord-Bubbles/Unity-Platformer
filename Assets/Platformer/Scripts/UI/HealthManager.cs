using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using StarterAssets;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    const float maxHealth = 100f;

    private float health = maxHealth;

    public TextMeshProUGUI healthText;

    public static HealthManager instance { get; private set; }

    public PlayerState currentState;

    public float invulnerableTimer = 2f;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    void Start()
    {
        healthText.text = health + "/100";
        healthBar.fillAmount = 1;
        currentState = PlayerState.Alive;
    }

    IEnumerator StayInvulnerable()
    {
        yield return new WaitForSeconds(invulnerableTimer);
        currentState = PlayerState.Alive;
    }


    public void TakeDamage(float value)
    {
        if (currentState == PlayerState.Alive)
        {
            health -= value;

            health = Mathf.Clamp(health, 0, 100);
            healthBar.fillAmount = health / 100;
            healthText.text = health + "/100";

            if (health <= 0)
            {
                currentState = PlayerState.Dead;
            }
            else
            {
                currentState = PlayerState.Invulnerable;

                StopAllCoroutines();
                StartCoroutine(StayInvulnerable());
            }
        }
    }

    public void Heal(float value)
    {
        health += value;
        health = Mathf.Clamp(health, 0, 100);

        healthBar.fillAmount = health / 100;
        healthText.text = health + "/100";
    }
}

