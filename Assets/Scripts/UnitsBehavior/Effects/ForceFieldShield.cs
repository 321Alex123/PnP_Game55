using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldShield : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private GameObject shield;

    private void Start()
    {
        health.activeShield = true; 
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        shield.SetActive(false);
    }
}