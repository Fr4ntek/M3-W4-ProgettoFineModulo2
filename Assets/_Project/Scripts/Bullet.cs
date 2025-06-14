using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private int dmg = 20;

    //danno
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LifeController _lc = collision.gameObject.GetComponent<LifeController>();
            _lc.TakeDamage(dmg);
            if (_lc.isAlive())
            {
                collision.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        Destroy(gameObject);
    }

    public float GetSpeed() => _speed;

}
