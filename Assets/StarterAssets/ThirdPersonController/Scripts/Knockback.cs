using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce;

    private CharacterController characterController;

    private bool isKnockback = false;

    private Vector3 impact = Vector3.zero;

    private HealthManager healthManager;

    public float knockbackVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        healthManager = HealthManager.instance;
    }

    public void AddImpact(Vector3 direction)
    {
        direction.Normalize();
        if (direction.y < 0)
        {
            direction.y = -direction.y;
        }
        impact = direction.normalized * knockbackForce;
        isKnockback = true;
    }

    void Update()
    {
        if (impact.magnitude > 0f)
        {
            characterController.Move(impact * Time.deltaTime * knockbackVelocity);
        }
        impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime);

        if (isKnockback && healthManager.currentState == PlayerState.Alive)
        {
            impact *= 0;
            isKnockback = false;
        }
    }
}
