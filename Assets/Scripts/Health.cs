using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float _currentHealth = 10;

    [SerializeField] ParticleSystem _killParticles;
    [SerializeField] AudioClip _killAudio;

    public HealthBar healthBar;
    public CameraShake cameraShake;

    [SerializeField] FlashImage _flashImage = null;
    [SerializeField] Color _newColor = Color.red;

    public UnityEvent TakeDamage;

    public void Damaged(int amount)
    {
        Debug.Log("Took " + amount + " damage");

        _currentHealth -= amount;
        healthBar.SetHealth(_currentHealth);

        TakeDamage?.Invoke();

        if (_currentHealth <= 0)
        {
            Kill();
        }

        StartCoroutine(cameraShake.Shake(.15f, .3f));
        _flashImage.StartFlash(.25f, .5f, Color.red);
    }

    void Kill()
    {
        Debug.Log("Kill");
        AudioHelper.PlayClip2D(_killAudio, 1f);
        ParticleSystem newKillParticles = Instantiate(_killParticles, this.gameObject.transform.position, Quaternion.identity);
        Destroy(newKillParticles);
        Destroy(gameObject);
    }
}
