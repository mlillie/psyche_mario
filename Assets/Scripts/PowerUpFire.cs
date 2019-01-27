using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFire : MonoBehaviour {
    public float multiplier;
    public float growth = 1f;
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
            powerUp.Activation(false, false, true, false, 1, growth, timer);
            Destroy(gameObject);
        }
    }
}