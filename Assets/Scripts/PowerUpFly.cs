using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : MonoBehaviour {

    private PowerUp powerUp;

    void Start()
    {
        powerUp = FindObjectOfType<PowerUp>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            powerUp.Activation(true, false, false, false, 1, 1f, 5f);
            Destroy(gameObject);
        }
    }
}
