using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    public float speed;
    private float _jumpVelocity;
    public float jumpHeight;
    public float gravity;
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var direction = Vector3.forward * speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpVelocity = jumpHeight;
            }
        }
        else
        {
            _jumpVelocity -= gravity;
        }

        direction.y = _jumpVelocity;

        _controller.Move(direction * Time.deltaTime);
    }
}
