using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.TakeDamage();
            if(e.GetLifePoints() == 0)
            {
                e.setDeath(true);
                e.GetAnim().SetBool("isDeath", true);
                Destroy(collision.gameObject, 1f);
            }
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    public float GetSpeed() => _speed;

}
