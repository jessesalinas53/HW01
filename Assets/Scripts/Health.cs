using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHealth = 10;
    [SerializeField] float _currentHealth = 10;

    [SerializeField] ParticleSystem _killParticles;
    [SerializeField] AudioClip _killAudio;

    public HealthBar healthBar;
    public CameraShake cameraShake;

    [SerializeField] FlashImage _flashImage = null;
    [SerializeField] Color _newColor = Color.red;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Kill();
        }

        StartCoroutine(cameraShake.Shake(.15f, .3f));
        _flashImage.StartFlash(.25f, .5f, Color.red);
    }

    void Kill()
    {
        AudioHelper.PlayClip2D(_killAudio, 1f);
        _killParticles = Instantiate(_killParticles, this.gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
