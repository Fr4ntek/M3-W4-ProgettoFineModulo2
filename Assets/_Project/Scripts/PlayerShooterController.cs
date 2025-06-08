using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField]
    private float _fireRate = 1f;

    [SerializeField]
    private float _fireRange = 1f;

    [SerializeField]
    private Bullet _bulletPrefab;

    private GameObject[] enemies;

    private float _fireTime = 0f;


    public void Start()
    {

    }

    public void Update()
    { 
        Shoot();
    }

    public GameObject FindNearestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distanceFromPlayer = 0f;
        GameObject closest = null;

        foreach (GameObject enemy in enemies)
        {
            distanceFromPlayer = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceFromPlayer <= _fireRange)
            {
                closest = enemy;
            }
        }

        return closest;
    }

    public void Shoot()
    {
        GameObject enemy = FindNearestEnemy();
        if(enemy != null)
        {
            if(Time.time > _fireTime)
            {
                Bullet clone = Instantiate(_bulletPrefab, transform.position, transform.rotation);
                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                Vector2 dir = (enemy.transform.position - transform.position).normalized;
                rb.AddForce(dir * clone.GetSpeed(), ForceMode2D.Impulse);
                _fireTime = Time.time + _fireRate;
            }
           
        }
    }





}
