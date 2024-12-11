using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject waypoint;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = waypoint.transform.position;
    }
}
