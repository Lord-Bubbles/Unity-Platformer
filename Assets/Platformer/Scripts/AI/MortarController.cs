using System.Collections;
using UnityEngine;


public class MortarController : MonoBehaviour
{
    public float initialVelocity;

    public Transform spawnPoint;

    public GameObject projectile;

    private bool isRotating = false;

    public float rotationSpeed;

    public float range = 60f;

    private Quaternion baseRotation;

    void Start()
    {
        baseRotation = transform.rotation;
    }

    void Update()
    {
        if (!isRotating)
        {
            var yRotation = (int)Random.Range(baseRotation.eulerAngles.y - range, baseRotation.eulerAngles.y + range);
            var newRotation = Quaternion.Euler(baseRotation.eulerAngles.x, yRotation, baseRotation.eulerAngles.z);
            StopAllCoroutines();
            isRotating = true;
            StartCoroutine(RotateAndFire(newRotation));
        }
    }

    IEnumerator RotateAndFire(Quaternion newRotation)
    {
        float time = 0;

        var currentRotation = transform.rotation;

        while (time < 5)
        {
            transform.rotation = Quaternion.Slerp(currentRotation, newRotation, time);

            time += Time.deltaTime * rotationSpeed;

            yield return null;

        }
        var _object = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        _object.GetComponent<Rigidbody>().linearVelocity = initialVelocity * spawnPoint.up;
        yield return new WaitForSeconds(1f);
        isRotating = false;
    }
}

