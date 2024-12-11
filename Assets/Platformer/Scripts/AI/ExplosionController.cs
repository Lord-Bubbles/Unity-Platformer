using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
