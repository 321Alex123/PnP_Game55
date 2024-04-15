using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldShield : MonoBehaviour
{
    [SerializeField] private float countDown;
    
    private EmpTank _parentTank;
    
    private void Start()
    {
        _parentTank = GetComponent<EmpTank>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EmpBomb"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            // SlowDownCountDown(countDown);
        }
    }

    // IEnumerator SlowDownCountDown(float countDown)
    // {
    //     _parentTank.speed = _parentTank.speed / 2;
    //     yield return new WaitForSeconds(countDown);
    //     _parentTank.speed = _parentTank.speed * 2;
    // }
}
