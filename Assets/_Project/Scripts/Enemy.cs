using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    private PlayerController _player;
    private int _lifePoints = 3;
    private AudioSource _audioSource;
    private Animator _anim;
    private bool _isDeath = false;

    private void Awake()
    {
        _player = Object.FindObjectOfType<PlayerController>();
        
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _anim.SetBool("isDeath", false);
    }

    void Update()
    {
        if (!_isDeath)
        {
            EnemyMovement();
        }
        
    }

    public void EnemyMovement()
    {

        float dir = _speed * Time.deltaTime;
        if (_player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, dir);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage()
    {
        _audioSource.Play();
        SetLifePoints(GetLifePoints() - 1);
    }

    public int GetLifePoints() => _lifePoints;
    public void SetLifePoints(int lifePoints) => _lifePoints = lifePoints;

    public Animator GetAnim() => _anim;
    public bool isDeath() => _isDeath;
    public void setDeath(bool isDeath) => _isDeath = isDeath;   

}
