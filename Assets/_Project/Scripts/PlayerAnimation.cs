using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (_animator != null && (_playerController.Horizontal != 0 || _playerController.Vertical != 0))
        {     
            _animator.SetFloat("hDir", _playerController.Horizontal);
            _animator.SetFloat("vDir", _playerController.Vertical);
        }
    }
}
