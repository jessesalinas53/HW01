using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    TankController _tankController;

    [SerializeField] Rigidbody _projectileRB;
    float _nextFire = 0f;
    float _fireRate = .5f;
    [SerializeField] Transform _projectileSpawn;
    [SerializeField] ParticleSystem _shootParticles;
    [SerializeField] AudioClip _shootAudio;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            if(Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                AudioHelper.PlayClip2D(_shootAudio, 1f);
                _shootParticles = Instantiate(_shootParticles, _projectileSpawn.position, Quaternion.identity);

                Rigidbody _projectileClone = Instantiate(_projectileRB, _projectileSpawn.position, Quaternion.identity) as Rigidbody;
                _projectileClone.AddForce(transform.forward * 1600f);
            }
        }
    }
}
