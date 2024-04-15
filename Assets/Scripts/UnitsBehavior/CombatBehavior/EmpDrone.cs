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
    public int ammo = 3;
    public int bombCooldown;


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
    }

    private void DropButton(InputAction.CallbackContext context)
    {
        Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
    }
}