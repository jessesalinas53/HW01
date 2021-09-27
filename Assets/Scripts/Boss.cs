using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] public float _moveForce = 6f;
    private Rigidbody _rb;
    [SerializeField] public Vector3 _moveDir;
    [SerializeField] LayerMask _whatIsWall;
    [SerializeField] float _maxDistFromWall = 0f;

    [SerializeField] GameObject _turret;
    [SerializeField] Transform _tank;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(_moveDir);
    }

    public void Update()
    {
        _rb.velocity = _moveDir * _moveForce;

        if(Physics.Raycast(transform.position, transform.forward, _maxDistFromWall, _whatIsWall))
        {
            _moveDir = ChooseDirection();
            transform.rotation = Quaternion.LookRotation(_moveDir);
        }

        _turret.transform.LookAt(_tank);
    }

    Vector3 ChooseDirection()
    {
        System.Random _ran = new System.Random();
        int i = _ran.Next(0, 3);
        Vector3 temp = new Vector3();

        if(i == 0)
        {
            temp = transform.forward;
        }
        else if (i == 1)
        {
            temp = -transform.forward;
        }
        else if (i == 2)
        {
            temp = transform.right;
        }
        else if (i == 3)
        {
            temp = -transform.right;
        }

        return temp;
    }
}
