using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private PlayerController _player;
    public AudioSource AudioSource { get; private set; }
    private Rigidbody2D _rb;
    private Vector2 playerPosition;
    [SerializeField] private int dmg = 50;
    public LifeController LifeController { get; private set; }
    

    private void Awake()
    {
        _player = Object.FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        LifeController = GetComponent<LifeController>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        //float dir = ;
        if (_player != null)
        {
            playerPosition = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.fixedDeltaTime);
            _rb.MovePosition(playerPosition);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LifeController>().TakeDamage(dmg);
            Destroy(gameObject);
        }
    }

}
