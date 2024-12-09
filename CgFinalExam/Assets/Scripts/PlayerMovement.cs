using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.D)) {

            rb.velocity = new Vector3(2.5f, rb.velocity.y, 0);
        
        }
        if (Input.GetKey(KeyCode.A))
        {

            rb.velocity = new Vector3(-2.5f, rb.velocity.y, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.position.y <1)
        {

            rb.velocity = new Vector3(0, 5f, 0);

        }

        if (Input.GetKey(KeyCode.F))
        {

            rb.velocity = new Vector3(0, 2.5f, 0);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Enemy" && rb.position.y > 1)
        {
            Destroy(collision.rigidbody.gameObject);
        }
        else
        {
            Destroy(rb);
            
        }
    }
}
