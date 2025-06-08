using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    [SerializeField]
    private float _speed = 5f;

    float h;
    float v;
    Vector2 direction;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = new Vector2(h, v);

        if(_animator != null && (h != 0 || v != 0))
        {
            _animator.SetFloat("hDir", h);
            _animator.SetFloat("vDir", v);
        }
    }

    void FixedUpdate()
    {
        if (h != 0 && v != 0)
        {
            float length = direction.magnitude;
            if (length > 1) 
                direction = direction / length;
        }
        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime)); 
    }

   

      
}
