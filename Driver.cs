using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 0.2f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float slowSpeed = 6f;
    [SerializeField] float fastSpeed = 15f;
    [SerializeField] string boost = ("boost");
    [SerializeField] string justObject = ("justObject");
    [SerializeField] float slowDelay = 3f;
    [SerializeField] float fastDelay = 3f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == justObject)
        {
            moveSpeed = slowSpeed;
            Invoke("SetMoveSpeedBack", slowDelay);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == boost)
        {
            moveSpeed = fastSpeed;
            Invoke("SetMoveSpeedBack", fastDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, turnAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void SetMoveSpeedBack()
    {
        moveSpeed = normalSpeed;
    }
}
