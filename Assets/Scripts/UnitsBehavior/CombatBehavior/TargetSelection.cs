using System.Collections.Generic;
using UnityEngine;

public class TargetSelection : MonoBehaviour
{
    [SerializeField] private Tracking tracking;
    [SerializeField] private Shooting shooting;

    public List<GameObject> targets = new List<GameObject>();
    private GameObject currentTarget = null;

    [SerializeField] private bool isEnemy;

    private void Awake()
    {
        shooting.isEnemy = isEnemy;
    }

    private void Update()
    {
        if (targets.Count != 0 && targets[0] == null)
        {
            targets.RemoveAt(0);
        }
            

        if (currentTarget == null && targets.Count != 0)
        {
            currentTarget = targets[0];
            tracking.target = currentTarget;
            shooting.target = currentTarget;
        }
            
        if (targets.Count == 0)
        {
            tracking.target = null;
            shooting.target = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEnemy)
        {
            if (other.CompareTag("Player"))
                targets.Add(other.gameObject);
        }
        else
        {
            if (other.CompareTag("Enemy"))
                targets.Add(other.gameObject);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (isEnemy)
        {
            if (other.CompareTag("Player"))
            {
                targets.Remove(other.gameObject);
                currentTarget = null;
            }
        }
        else
        {
            if (other.CompareTag("Enemy"))
            {
                targets.Remove(other.gameObject);
                currentTarget = null;
            };
        }
    }
}
