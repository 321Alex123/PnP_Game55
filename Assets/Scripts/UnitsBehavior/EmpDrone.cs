using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EmpDrone : MonoBehaviour
{
    [SerializeField] private int ammo = 3;
    [SerializeField] private int bombCooldown = 5;
    private bool readyToBomb = true;
    private List<GameObject> potentialTarget = new List<GameObject>();
    [SerializeField] Transform bombSpawnPoint;
    [SerializeField] GameObject bombPrefab;

    [SerializeField] private InputActionReference dropBomb;

    private void Awake()
    {
        dropBomb.action.performed += DropButton;
    }

    IEnumerator BombCooldown()
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

    private void DropButton(InputAction.CallbackContext context)
    {
        if (SelectByClick.selectedDrones.Contains(gameObject))
        {
            if (readyToBomb)
            {
                GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
                if (potentialTarget[0] != null)
                {
                    bomb.GetComponent<Bomb>().target = potentialTarget[0];
                }
                
                ammo--;
                if (ammo == 0)
                {
                    readyToBomb = false;
                    StartCoroutine(BombCooldown());
                }
            }
        }
    }
}