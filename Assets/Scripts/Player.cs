using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    public bool invincible = false;

    [SerializeField] Text _treasureText;
    int _treasureCount = 0;

    TankController _tankController;

    [SerializeField] Rigidbody _projectileRB;
    float _nextFire = 0f;
    float _fireRate = .5f;
    [SerializeField] Transform _projectileSpawn;
    [SerializeField] ParticleSystem _shootParticles;
    [SerializeField] AudioClip _shootAudio;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _treasureText.text = "Treasure: " + _treasureCount;
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            if(Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                AudioHelper.PlayClip2D(_shootAudio, 1f);
                _shootParticles = Instantiate(_shootParticles, _projectileSpawn.position, Quaternion.identity);

                Rigidbody _projectileClone = Instantiate(_projectileRB, _projectileSpawn.position, Quaternion.identity) as Rigidbody;
                _projectileClone.AddForce(transform.forward * 1600f);
            }
        }
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if(invincible == false)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        if(invincible == false)
        {
            gameObject.SetActive(false);
            // play particles
            // play sounds
        }
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureCount += amount;
        Debug.Log("Treasure count: " + _treasureCount);

    }
}
