using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
      [SerializeField] GameObject thingToFollow;
      [SerializeField] float yAxis = 2f;
      int score = 0;
      bool hasExitedTrigger = false;

    void OnTriggerExit2D(Collider2D other)
    {
      if(other.gameObject.tag == "Player" && !hasExitedTrigger) 
      {
        score += 1;
        hasExitedTrigger = true;
      }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hasExitedTrigger)
        {
            hasExitedTrigger = false;
        }
    }

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, yAxis, 0);
    }

      void OnGUI()
    {
        // Render the label
        GUI.Label(new Rect(10, 10, 200, 40), "Flip Score: " + score.ToString());
    }
}
