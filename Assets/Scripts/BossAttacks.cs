using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    [SerializeField] Rigidbody _smProjectileRB;
    [SerializeField] Transform _smProjectileSpawn;
    [SerializeField] ParticleSystem _smShootParticles;
    [SerializeField] AudioClip _smShootAudio;
    float _smNextFire = 2f;
    float _smFireRate = 3f;

    [SerializeField] Rigidbody _lgProjectileRB;
    [SerializeField] Transform _lgProjectileSpawn;
    [SerializeField] ParticleSystem _lgShootParticles;
    [SerializeField] AudioClip _lgShootAudio;
    float _lgNextFire = 6f;
    float _lgFireRate = 6f;

    [SerializeField] Transform _tank;
    [SerializeField] Transform _turretDir;
    [SerializeField] Transform _bossBody;
    Boss _boss;

    private void Awake()
    {
       _boss = GetComponent<Boss>();
    }
    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Time.time > _lgNextFire)
        {
            _boss._moveForce = 0f;
            _bossBody.transform.LookAt(_tank);
            _lgNextFire = Time.time + _lgFireRate;
            //play build up particles
            StartCoroutine(holdFire());
            AudioHelper.PlayClip2D(_lgShootAudio, 1f);
            ParticleSystem _shootLgParticlesClone = Instantiate(_lgShootParticles, _lgProjectileSpawn.position, Quaternion.identity);
            Destroy(_shootLgParticlesClone, 1f);
            Rigidbody _lgProjectileClone = Instantiate(_lgProjectileRB, _lgProjectileSpawn.position, Quaternion.identity) as Rigidbody;
            _lgProjectileClone.AddForce(_turretDir.forward * 1200f);
            _boss._moveForce = 6f;
            _bossBody.transform.LookAt(_turretDir);
            StartCoroutine(holdFire());
        }
        else if(Time.time > _smNextFire && _smNextFire < _lgNextFire)
        {
            _smNextFire = Time.time + _smFireRate;
            AudioHelper.PlayClip2D(_smShootAudio, 1f);
            ParticleSystem _shootParticlesClone = Instantiate(_smShootParticles, _smProjectileSpawn.position, Quaternion.identity);
            Destroy(_shootParticlesClone, 1f);
            Rigidbody _projectileClone = Instantiate(_smProjectileRB, _smProjectileSpawn.position, Quaternion.identity) as Rigidbody;
            _projectileClone.AddForce(_turretDir.forward * 1200f);
        }
    }

    IEnumerator holdFire()
    {
        yield return new WaitForSeconds(2);
    }
}
