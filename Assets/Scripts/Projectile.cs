using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactAudio;
    [SerializeField] ParticleSystem _damParticles;
    [SerializeField] AudioClip _damAudio;

    int _damAmount = 1;

    private void OnCollisionEnter(Collision other)
    {
        //other.gameObject.GetComponent<IDamageable>();

        AudioHelper.PlayClip2D(_impactAudio, 1f);
        _impactParticles = Instantiate(_impactParticles, this.gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

        if(other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damAmount);
            AudioHelper.PlayClip2D(_damAudio, 1f);
            _damParticles = Instantiate(_damParticles, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
