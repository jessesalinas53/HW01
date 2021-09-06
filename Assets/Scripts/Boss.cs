using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int _health = 3;

    [SerializeField] ParticleSystem _takeDamParticles;
    [SerializeField] AudioClip _takeDamAudio;
    [SerializeField] ParticleSystem _destroyedParticles;
    [SerializeField] AudioClip _destroyedAudio;

    public void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        AudioHelper.PlayClip2D(_takeDamAudio, 1f);
        _takeDamParticles = Instantiate(_takeDamParticles, this.gameObject.transform.position, Quaternion.identity);
        if (_health <= 0)
        {
            Destroyed();
        }
    }

    public void Destroyed()
    {
        AudioHelper.PlayClip2D(_destroyedAudio, 1f);
        _destroyedParticles = Instantiate(_destroyedParticles, this.gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
