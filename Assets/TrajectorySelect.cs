using UnityEngine;


/**
 * Created by: Matthew Lillie
 * Date: February 8th, 2019
 * 
 * Handles the trajectory selection process for the satellite to be "launched" into the orbit of the asteroid. 
 *
 */
public class TrajectorySelect : MonoBehaviour
{
    private float rotationSpeed = 30f;
    private float rotationAngle = 60f;
    public float startingRotation;
    private bool stillMoving = true, positiveMovement = true;
    public float currentAngle;

    void Start()
    {
        startingRotation = transform.eulerAngles.z;
        currentAngle = startingRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (stillMoving)
        {
            if(positiveMovement)
            {
                currentAngle = Mathf.MoveTowards(currentAngle, startingRotation + rotationAngle,
                                rotationSpeed * Time.deltaTime);
                if(currentAngle >= startingRotation + rotationAngle)
                {
                    positiveMovement = false;
                }
                transform.eulerAngles = new Vector3(0, 0, currentAngle);
            } else
            {
                currentAngle = Mathf.MoveTowards(currentAngle, startingRotation - rotationAngle,
                                rotationSpeed * Time.deltaTime);
                if (currentAngle <= startingRotation - rotationAngle)
                {
                    positiveMovement = true;
                }
                transform.eulerAngles = new Vector3(0, 0, currentAngle);
            }
  
        }
    }

    void OnMouseDown()
    {
        stillMoving = !stillMoving;
    }
}
