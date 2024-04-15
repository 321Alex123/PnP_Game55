using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class APDroneTemp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackPower;
    [SerializeField] private float droneHeight;

    // private float enemyHealth; на будущее, чтобы сконектить с скриптом Матвея
    private PlayerBase _playerBase;
    private Rigidbody _enemyRb;

    void Start()
    {
        droneHeight = transform.position.y;
        _playerBase = GameObject.Find("Player Base").GetComponent<PlayerBase>(); // заменить цель на цель Матвея
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
        var newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        _enemyRb.MovePosition(newPosition);
    }

    private void PlayEffect()
    {
        // if (enemyHealth.health != 0) // на будущее, чтобы сконектить с скриптом Матвея
        // {
        //     GetComponentInChildren<ParticleSystem>().Play();
        // }
    }
}