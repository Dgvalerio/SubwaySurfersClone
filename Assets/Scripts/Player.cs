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
    
    public float horizontalSpeed;
    private bool _isMovingRight;
    private bool _isMovingLeft;
    
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
            else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 5f && !_isMovingRight)
            {
                _isMovingRight = true;
                StartCoroutine(RightMove());
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -5f && !_isMovingLeft)
            {
                _isMovingLeft = true;
                StartCoroutine(LeftMove());
            }
        }
        else
        {
            _jumpVelocity -= gravity;
        }

        direction.y = _jumpVelocity;

        _controller.Move(direction * Time.deltaTime);
    }

    private IEnumerator LeftMove()
    {
        for (float i = 0; i < 10; i += 0.1f)
        {
            _controller.Move(Time.deltaTime * horizontalSpeed * Vector3.left);
            yield return null;
        }

        _isMovingLeft = false;
    }

    private IEnumerator RightMove()
    {
        for (float i = 0; i < 10; i += 0.1f)
        {
            _controller.Move(Time.deltaTime * horizontalSpeed * Vector3.right);
            yield return null;
        }

        _isMovingRight = false;
    }
}
