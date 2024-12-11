using System;
using StarterAssets;
using UnityEngine;


public class AISensor : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public ThirdPersonController playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        InvokeRepeating("FieldOfViewCheck", 0f, 0.2f);
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 2, target.position.z);
            Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Vector3 directionToTarget = (targetPosition - currentPosition).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) <= angle)
            {
                float distanceToTarget = Vector3.Distance(currentPosition, targetPosition);

                if (!Physics.Raycast(currentPosition, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
