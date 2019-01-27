using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGrow : MonoBehaviour {
    public float growth = 1.3f;
    public float timer = 10f;

    private PowerUp powerUp;

    void Start()
    {
        powerUp = FindObjectOfType<PowerUp>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            powerUp.Activation(false, false, false, false, 1, growth, timer);
            Destroy(gameObject);
        }       
    }
}