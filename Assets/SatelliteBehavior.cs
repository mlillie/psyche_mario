using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteBehavior : MonoBehaviour
{
    private Vector2 LAUNCH_VELOCITY = new Vector2(20f, 80f); // TODO take trajectory/powerbar values
    private Vector2 INITIAL_POSITION = Vector2.zero;
    private Vector2 GRAVITY = new Vector2(0f, -240f); //TODO
    private bool launched = false;
    private TrajectorySelect traj;
    private Powerbar powerbar;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        traj = FindObjectOfType<TrajectorySelect>();
        powerbar = FindObjectOfType<Powerbar>();
        rb = GetComponent<Rigidbody2D>();
        // So it cannot move
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(launched)
        {
            float powerValue = powerbar.value;
            float angleValue = (traj.currentAngle - traj.startingRotation);
            //rb.isKinematic = true;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * angleValue), Mathf.Cos(Mathf.Deg2Rad * angleValue)) * powerValue * 2f;
        }
    }

    private Vector2 CalculatePosition(float elapsedTime)
    {
        return GRAVITY * elapsedTime * elapsedTime * 0.5f +
                   LAUNCH_VELOCITY * elapsedTime + INITIAL_POSITION;
    }

    void OnMouseDown()
    {
        launched = true;
    }
}
