using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowie : MonoBehaviour
{
    SurfaceEffector2D surfaceEffector;
    float timeHeld = 0f; // Variable to keep track of how long the button has been held
    [SerializeField] float speedIncreaseInterval = 1f; // The interval at which the speed should increase
    [SerializeField] float speedIncreaseAmount = 2f; // The amount by which the speed should increase

    // Start is called before the first frame update
    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            timeHeld += Time.deltaTime; // Increment the time held by the time since last frame

            if (timeHeld > speedIncreaseInterval)
            {
                surfaceEffector.speed += speedIncreaseAmount; // Increase the speed by the specified amount
                timeHeld = 0f; // Reset the time held
            }
        }
        else
        {
            timeHeld = 0f; // Reset the time held if the button is not being held down
        }
    }
}
