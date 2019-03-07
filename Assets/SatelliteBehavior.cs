﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteBehavior : MonoBehaviour
{

    // Enum to represent the current game state.
    private enum GameState
    {
        TRAJECTORY_SELECTION,
        POWER_SELECTION,
        LAUNCH,
        LAUNCHED
    }

    private Vector2 LAUNCH_VELOCITY = new Vector2(20f, 80f); // TODO take trajectory/powerbar values
    private Vector2 INITIAL_POSITION = Vector2.zero;
    private Vector2 GRAVITY = new Vector2(0f, -240f); //TODO
    private TrajectorySelect traj;
    private Powerbar powerbar;
    private Rigidbody2D rb;
    private GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        traj = FindObjectOfType<TrajectorySelect>();
        powerbar = FindObjectOfType<Powerbar>();
        rb = GetComponent<Rigidbody2D>();
        // So it cannot move
        rb.gravityScale = 0;
        // Initial state
        currentState = GameState.TRAJECTORY_SELECTION;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If the screen was clicked / tapped
        {
            switch (currentState)
            {
                case GameState.TRAJECTORY_SELECTION:
                    //TODO Add popup?
                    traj.stillMoving = false;
                    currentState = GameState.POWER_SELECTION;
                    break;
                case GameState.POWER_SELECTION:
                    //TODO Add popup?
                    powerbar.stillMoving = false;
                    currentState = GameState.LAUNCH;
                    break;
                case GameState.LAUNCH:
                    currentState = GameState.LAUNCHED;
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentState == GameState.LAUNCHED)
        {
            float powerValue = powerbar.value;
            float angleValue = (traj.currentAngle - traj.startingRotation);
            rb.isKinematic = true;
            rb.gravityScale = 1;
            Vector2 vel = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * angleValue), Mathf.Cos(Mathf.Deg2Rad * angleValue)) * 
                powerValue * 2f;
            rb.MovePosition(rb.position + vel * Time.fixedDeltaTime);
        }
    }
    private Vector2 CalculatePosition(float elapsedTime)
    {
        return GRAVITY * elapsedTime * elapsedTime * 0.5f +
                   LAUNCH_VELOCITY * elapsedTime + INITIAL_POSITION;
    }

}
