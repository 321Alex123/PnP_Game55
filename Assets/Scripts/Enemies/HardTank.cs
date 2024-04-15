using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HardTank : MonoBehaviour
{
    [SerializeField] private float hardSpeed;
    [SerializeField] private float hardAttackPower;

    private ParticleSystem aeroSpotEffect;
    private PlayerBase target;
    private Rigidbody _enemyRb;
    // private float enemyHealth; на будущее, чтобы сконектить с скриптом Матвея
    private Vector3 enemyPosition;
    private float gravity = 30;
    
    
    void Start()
    {
        target = GameObject.Find("Player Base").GetComponent<PlayerBase>();
        _enemyRb = GetComponent<Rigidbody>(); 
        //enemyHealth = GetComponent<Health>(); на будущее, чтобы сконектить с скриптом Матвея
        gameObject.transform.position = enemyPosition;
    }

    private void FixedUpdate()
    {
        Move();
        // PlayEffect();
        Gravity();
    }

    void Gravity()
    {
        enemyPosition.y -= gravity;
    }
    private void Move()
    {
        var playerPosition = target.transform.position;
        var targetPosition = new Vector3(playerPosition.x, 0, playerPosition.z);
        var newPosition = Vector3.MoveTowards(transform.position, targetPosition, hardSpeed * Time.deltaTime);
        _enemyRb.MovePosition(newPosition);
    }

    // private void PlayEffect()
    // {
    //     if (enemyHealth.health != 0)
    //     {
    //         GetComponentInChildren<ParticleSystem>().Play();
    //     }
    // }

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