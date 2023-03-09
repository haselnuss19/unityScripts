using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
   [SerializeField] string obstacal = ("PickUps");
   [SerializeField] string obstical = ("Customers");
   [SerializeField] float destroyingDelay = 0.3f;
   [SerializeField] Color32 colorChange = new Color32 (1,1,1,1);
   [SerializeField] Color noColorChange = new Color (1,1,1,1);
   bool hasPickUp = false;
   int timesDeliverd = 0;
   SpriteRenderer spriteRenderer;

   void Start() 
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }

void OnTriggerEnter2D(Collider2D other)
{
   if (other.tag == obstacal && !hasPickUp) 
   {
    Debug.Log ("Picking up the pizza");
    hasPickUp = true;
    timesDeliverd = 0;
    spriteRenderer.color = colorChange;
    Destroy(other.gameObject, destroyingDelay);
   }

   if (other.tag == obstical && hasPickUp && timesDeliverd == 0) 
   {
      Debug.Log("Deliverd!");
      timesDeliverd = 1;
      spriteRenderer.color = noColorChange;
   }
}

}
