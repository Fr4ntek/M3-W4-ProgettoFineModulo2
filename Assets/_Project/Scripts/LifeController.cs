using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp = 100;


    public void AddHp(int amount)
    {
        SetHp(_hp + amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHp() => _hp;
    public void SetHp(int hp) => this._hp = hp;

}
