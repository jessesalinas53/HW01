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
    float _smFireRate = 2f;

    [SerializeField] Rigidbody _lgProjectileRB;
    [SerializeField] Transform _lgProjectileSpawn;
    [SerializeField] ParticleSystem _lgShootParticles;
    [SerializeField] AudioClip _lgShootAudio;
    float _lgNextFire = 6f;
    float _lgFireRate = 6f;

    [SerializeField] Transform _turretDir;
    
    [SerializeField] ParticleSystem buildUpParticles;
    [SerializeField] AudioClip buildUpAudio;

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Time.time > _lgFireRate)
        {
            ShootLarge();
        }
        else if(Time.time > _smFireRate)
        {
            ShootSmall();
        }
    }

    void ShootLarge()
    {
        _lgFireRate = Time.time + _lgNextFire;

        AudioHelper.PlayClip2D(_lgShootAudio, 1f);

        ParticleSystem _shootLgParticlesClone = Instantiate(_lgShootParticles, _lgProjectileSpawn.position, Quaternion.identity);

        Rigidbody _lgProjectileClone = Instantiate(_lgProjectileRB, _lgProjectileSpawn.position, Quaternion.identity) as Rigidbody;
        _lgProjectileClone.AddForce(_turretDir.forward * 1300f);
    }

    void ShootSmall()
    {
        _smFireRate = Time.time + _smNextFire;

        AudioHelper.PlayClip2D(_smShootAudio, 1f);

        ParticleSystem _shootParticlesClone = Instantiate(_smShootParticles, _smProjectileSpawn.position, Quaternion.identity);

        Rigidbody _projectileClone = Instantiate(_smProjectileRB, _smProjectileSpawn.position, Quaternion.identity) as Rigidbody;
        _projectileClone.AddForce(_turretDir.forward * 1500f);
    }
}
