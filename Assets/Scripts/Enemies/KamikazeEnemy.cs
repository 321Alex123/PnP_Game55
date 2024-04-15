using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KamikazeEnemy : MonoBehaviour
{
    [SerializeField] private float lightSpeed;
    [SerializeField] private float lightAttackPower;
    
    // private float enemyHealth; на будущее, чтобы сконектить с скриптом Матвея
    private PlayerBase _playerBase;
    private Rigidbody _enemyRb;
    private float gravity = 30;
    private Vector3 enemyPosition;
    
    void Start()
    {
        _playerBase = GameObject.Find("Player Base").GetComponent<PlayerBase>();
        _enemyRb = GetComponent<Rigidbody>();
        gameObject.transform.position = enemyPosition;
    }
    
    private void FixedUpdate()
    {
        Move();
        Gravity();
    }

    void Gravity()
    {
        enemyPosition.y -= gravity;
    }
    
    private void Move()
    {
        var playerPosition = _playerBase.transform.position;
        var targetPosition = new Vector3(playerPosition.x, 0, playerPosition.z);
        var newPosition = Vector3.MoveTowards(transform.position, targetPosition, lightSpeed * Time.deltaTime);
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
            Destroy(gameObject);
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    private void Attack(GameObject target)
    {
        var player = target.GetComponent<PlayerBase>();
        if (player != null)
        {
            player.ReceiveDamage(-lightAttackPower);
        }
    }
}
