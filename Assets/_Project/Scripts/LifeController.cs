using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public enum ON_DEFEAT_BEHAVIOUR { DISABLE = 0, DESTROY = 1, RESTART_SCENE = 2 }


    [SerializeField] private int _hp = 100;
    [SerializeField] private ON_DEFEAT_BEHAVIOUR _onDefeatBehaviour = ON_DEFEAT_BEHAVIOUR.RESTART_SCENE;


    public void AddHp(int amount)
    {
        SetHp(_hp + amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
        Debug.Log($"{gameObject.name} ha ricevuto danno! Vita attuale {_hp}");
        if (_hp <= 0)
        {
            switch (_onDefeatBehaviour)
            {
                default:
                    Debug.LogError($"The option {_onDefeatBehaviour} is not recognized!");
                    break;
                case ON_DEFEAT_BEHAVIOUR.DISABLE:
                    gameObject.SetActive(false);
                    break;
                case ON_DEFEAT_BEHAVIOUR.DESTROY:
                    Destroy(gameObject);
                    break;
                case ON_DEFEAT_BEHAVIOUR.RESTART_SCENE:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
            }
        }
    }

    public bool isAlive()
    {
        if (_hp <= 0) return false;
        return true;
    }
    public int GetHp() => _hp;
    public void SetHp(int hp) => _hp = hp;

}
