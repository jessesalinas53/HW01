using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHealth = 10;
    [SerializeField] float _currentHealth = 10;

    [SerializeField] ParticleSystem _killParticles;
    [SerializeField] AudioClip _killAudio;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        AudioHelper.PlayClip2D(_killAudio, 1f);
        _killParticles = Instantiate(_killParticles, this.gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
