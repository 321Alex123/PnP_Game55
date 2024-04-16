using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BomberDrone : MonoBehaviour
{
    [SerializeField] private GameObject bombSpawnPoint;
    [SerializeField] private GameObject shellPrefab;
    [SerializeField] private InputActionReference dropBomb;

    [SerializeField] private int ammo = 3;
    [SerializeField] private int bombCooldown = 5;
    private bool readyToBomb = true;
    private List<GameObject> potentialTarget = new List<GameObject>();

    private Rocket rocket;

    private void Awake()
    {
        if (shellPrefab.GetComponent<Rocket>() != null)
        {
            rocket = shellPrefab.GetComponent<Rocket>();
        }
        dropBomb.action.performed += LaunchShell;
    }

    IEnumerator LaunchCooldown()
    {
        yield return new WaitForSeconds(bombCooldown);
        readyToBomb = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            potentialTarget.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            potentialTarget.Remove(other.gameObject);
        }
    }

    private void LaunchShell(InputAction.CallbackContext context)
    {
        if (SelectByClick.selectedDrones.Contains(gameObject))
        {
            if (readyToBomb)
            {
                GameObject shell = Instantiate(shellPrefab, bombSpawnPoint.transform.position, bombSpawnPoint.transform.rotation);

                if (rocket != null)
                {
                    if (potentialTarget.Count > 0) 
                    {
                        rocket.target = potentialTarget[0];
                    }
                }
                
                ammo--;

                if (ammo == 0)
                {
                    readyToBomb = false;
                    StartCoroutine(LaunchCooldown());
                }
            }
        }
    }
}