using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HardEnemy : MonoBehaviour
{
    [SerializeField] private float hardSpeed;
    [SerializeField] private float hardAttackPower;
    [SerializeField] private float droneHeight;

    private ParticleSystem aeroSpotEffect;
    private PlayerBase _playerBase;
    private Rigidbody _enemyRb;
    // private float enemyHealth; на будущее, чтобы сконектить с скриптом Матвея
    
    void Start()
    {
        droneHeight = transform.position.y;
        _playerBase = GameObject.Find("Player Base").GetComponent<PlayerBase>();
        _enemyRb = GetComponent<Rigidbody>(); 
        //enemyHealth = GetComponent<Health>(); на будущее, чтобы сконектить с скриптом Матвея
    }

    private void FixedUpdate()
    {
        Move();
        PlayEffect();
    }

    private void Move()
    {
        var playerPosition = _playerBase.transform.position;
        var targetPosition = new Vector3(playerPosition.x, droneHeight, playerPosition.z);
        var newPosition = Vector3.MoveTowards(transform.position, targetPosition, hardSpeed * Time.deltaTime);
        _enemyRb.MovePosition(newPosition);
    }

    private void PlayEffect()
    {
        if (enemyHealth.health != 0)
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack(other.gameObject);
        }
    }

    private void Attack(GameObject target)
    {
        var player = target.GetComponent<PlayerBase>();
        if (player != null)
        {
            player.ReceiveDamage(-hardAttackPower);
        }
    }
}