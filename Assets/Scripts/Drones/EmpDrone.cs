using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EmpDrone : MonoBehaviour
{
    public float health = 100f; // Здоровье танка
    public float speed = 5f; // Скорость движения танка
    public int ammo = 3;
    public float countDown = 3f;
    private float currentCountdown;

    [SerializeField] GameObject bombSpawnPlace;
    [SerializeField] GameObject bomb;

    private PlayerBase target; // Цель, к которой будет двигаться танк (база игрока)
    private Rigidbody EnemyRb; // Rigidbody танка для физического перемещения
    private Button launchBombButton;

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
        target = GameObject.Find("Player Base").GetComponent<PlayerBase>();
    }

    void FixedUpdate()
    {
        MoveTowardsTarget(); // Вызываем метод перемещения к цели
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentCountdown <= 0f)
        {
            CloneObject();
            currentCountdown = countDown; // Начинаем перезарядку
        }

        // Обновляем время перезарядки
        if (currentCountdown > 0f)
        {
            currentCountdown -= Time.deltaTime;
        }
    }

    private void MoveTowardsTarget()
    {
        if (target != null)
        {
            var tankPosition = transform.position;
            Vector3 direction = (target.transform.position - tankPosition).normalized; // Направление к цели
            EnemyRb.MovePosition(tankPosition + direction * (speed * Time.deltaTime)); // Перемещаем танк к цели
        }
    }


    private void CloneObject()
    {
        GameObject bulletClone = Instantiate(bomb);
        bulletClone.transform.position = bombSpawnPlace.transform.position;
        bulletClone.GetComponent<EmpBomb>().SetPosition(transform.forward);
        bulletClone.transform.position = transform.position;
    }

    public void TakeDamage(float damage)
    {
        health -= damage; // Уменьшаем здоровье танка при получении урона
        if (health <= 0)
        {
            Destroy(gameObject); // Уничтожаем танк, если здоровье <= 0
        }
    }
}