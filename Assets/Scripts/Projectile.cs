using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactAudio;

    private void OnCollisionEnter(Collision other)
    {
        Boss boss = other.gameObject.GetComponent<Boss>();
        boss.TakeDamage(1);

        AudioHelper.PlayClip2D(_impactAudio, 1f);
        _impactParticles = Instantiate(_impactParticles, this.gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
