using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactAudio;
    [SerializeField] ParticleSystem _damParticles;
    [SerializeField] AudioClip _damAudio;

    [SerializeField] int _damAmount = 2;

    private void OnCollisionEnter(Collision other)
    {
        AudioHelper.PlayClip2D(_impactAudio, 1f);
        ParticleSystem newImpactParticles = Instantiate(_impactParticles, this.gameObject.transform.position, Quaternion.identity);
        //Destroy(newImpactParticles);

        Health health = other.collider.GetComponent<Health>();

        if(health != null)
        {
            health.Damaged(_damAmount);

            AudioHelper.PlayClip2D(_damAudio, 1f);

            ParticleSystem _damParticlesClone = Instantiate(_damParticles, this.gameObject.transform.position, Quaternion.identity);
            Destroy(_damParticlesClone);
        }
        Destroy(gameObject);
    }
}
