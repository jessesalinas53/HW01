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
