using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    Transform _transform;
    float _speed;
    Rigidbody _rigidbody;
    float _force;
    Animator _playerAnimator;

    Player _player;
    public Movement(Transform t,float s,Rigidbody rb,float f,Player p,Animator a )
    {
        _transform = t;
        _speed = s;
        _rigidbody = rb;
        _force = f;
        _player = p;
        _playerAnimator = a;
    }
    public void move(float vertical, float horizontal)
    {
        //Vector3 direction = (_transform.forward * vertical + _transform.right * horizontal).normalized * _speed ;
        //_rigidbody.velocity = new Vector3(direction.x, _rigidbody.velocity.y, direction.z);
        Vector3 direction = new Vector3(vertical, 0f, -horizontal).normalized;

        // Mover al personaje en la dirección calculada
        _rigidbody.velocity = direction * _speed;

        // Si hay movimiento, hacer que el personaje gire en la dirección del movimiento
        if (direction != Vector3.zero)
        {
            _transform.forward = direction;
            _playerAnimator.SetBool("Run", true);
           

        }else
        {
            _playerAnimator.SetBool("Run", false);
        }
        
        
    }
    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }

    public void reload()
    {
        Debug.Log("Recargando");

    }

    public void Shoot()
    {
        Debug.Log("Shooting");
    }
}
