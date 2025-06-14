using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _fireRange = 1f;
    private float _fireTime = 0f;
    private GameObject[] enemies;
    private PlayerController _player;

    private void Start()
    {
        _player = Object.FindObjectOfType<PlayerController>();
    }
    public void Update()
    { 
        Shoot();
    }

    public void Shoot()
    {
        if(CanShoot())
        {
            GameObject enemy = FindNearestEnemy();
            if (enemy != null)
            {
                if (Time.time >= _fireTime)
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

    private bool CanShoot()
    {
        if(_player != null)
        {
            if (transform.IsChildOf(_player.transform)) return true;
        }
        
        return false;
    }

}
