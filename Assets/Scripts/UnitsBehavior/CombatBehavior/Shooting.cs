using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float fireColldown;
    [SerializeField] private float fireDistance;
    [SerializeField] private GameObject projectile;
    public GameObject target;
    [SerializeField] private GameObject projectileSpawn;
    private float _fireTimer = 0;
    public bool isEnemy;
    private Quaternion lookAtRotation;

    private void Update()
    {
        _fireTimer += Time.deltaTime;

        if (target != null)
        {
            if (_fireTimer >= fireColldown)
            {
                lookAtRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                if (transform.rotation == lookAtRotation)
                {
                    SpawnProjectiles();
                    _fireTimer = 0;
                }
                /*
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

                if (angle < fireDistance)
                {
                    SpawnProjectiles();
                    _fireTimer = 0;
                }*/
            }
        }
    }

    private void SpawnProjectiles()
    {
        GameObject newProjectile = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        newProjectile.GetComponent<Projectile>().isEnemy = isEnemy;
        Vector3 direction = projectileSpawn.transform.forward;
        newProjectile.GetComponent<Projectile>().direction = direction;
    }
}
