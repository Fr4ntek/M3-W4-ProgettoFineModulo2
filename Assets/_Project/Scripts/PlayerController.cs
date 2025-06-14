using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;
    public Vector2 Direction { get; private set; }
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private Rigidbody2D _rb;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Direction = new Vector2(Horizontal, Vertical).normalized;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Direction * (_speed * Time.fixedDeltaTime)); 
    }

}
