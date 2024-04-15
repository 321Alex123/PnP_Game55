using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(Destruction());
    }
}
