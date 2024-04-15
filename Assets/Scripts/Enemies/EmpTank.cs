using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpTank : MonoBehaviour
{
    [SerializeField] private float health = 100f;  // Здоровье танка
    [SerializeField] public float speed = 5f;  // Скорость движения танка

    private PlayerBase target;  // Цель, к которой будет двигаться танк (база игрока)
    private Rigidbody EnemyRb;  // Rigidbody танка для физического перемещения
    private Vector3 enemyPosition;
    private float gravity = 30;

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();  // Получаем компонент Rigidbody
        target = GameObject.Find("Player Base").GetComponent<PlayerBase>();
        gameObject.transform.position = enemyPosition;
    }

    void FixedUpdate()
    {
        MoveTowardsTarget();  // Вызываем метод перемещения к цели
        Gravity();
    }

    void Gravity()
    {
        enemyPosition.y -= gravity;
    }
    
    private void MoveTowardsTarget()
    {
        if (target != null)
        {
            var tankPosition = transform.position;
            Vector3 direction = (target.transform.position - tankPosition).normalized;  // Направление к цели
            EnemyRb.MovePosition(tankPosition + direction * (speed * Time.deltaTime));  // Перемещаем танк к цели
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;  // Уменьшаем здоровье танка при получении урона
        if (health <= 0)
        {
            Destroy(gameObject);  // Уничтожаем танк, если здоровье <= 0
        }
    }
}