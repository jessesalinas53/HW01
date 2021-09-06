using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);

    [SerializeField] float _powerUpDuration = 5f;

    [SerializeField] ParticleSystem _powerUpParticles;
    [SerializeField] AudioClip _powerUpSound;

    Rigidbody _rb;
    Collider _collider;
    MeshRenderer _mesh;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _mesh = GetComponent<MeshRenderer>();
        Player player = gameObject.GetComponent<Player>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp();
            Feedback();
        }
    }

    protected virtual void PowerUp()
    {
        _collider.enabled = !_collider.enabled;
        _mesh.enabled = !_mesh.enabled;

        StartCoroutine(PowerDown());
    }

    protected virtual void Feedback()
    {
        // particles
        if (_powerUpParticles != null)
        {
            _powerUpParticles = Instantiate(_powerUpParticles, transform.position, Quaternion.identity);
        }
        // audio
        if (_powerUpSound != null)
        {
            AudioHelper.PlayClip2D(_powerUpSound, 1f);
        }
    }

    protected virtual IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(_powerUpDuration);
        gameObject.SetActive(false);
    }
}
