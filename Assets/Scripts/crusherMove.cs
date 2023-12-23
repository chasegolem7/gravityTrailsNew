using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crusherMove : MonoBehaviour
{
    public int maximumXPosition;
    public int minimumXPosition;
    public float yForce;
    public float xForce;
    public float xDirection;
    private Rigidbody2D enemyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(transform.position.x <= minimumXPosition)
        {
            xDirection = 1;
            enemyRigidBody.AddForce(Vector2.right * xForce);
        }

        if(transform.position.x >= maximumXPosition)
        {
            xDirection = -1;
            enemyRigidBody.AddForce(Vector2.left * xForce);
        }
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "ground")
        {  
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidBody.AddForce(jumpForce);
        }

        if(collision.gameObject.tag == "roof")
        {  
            Vector2 downForce = new Vector2(xForce * xDirection, yForce*-1);
            enemyRigidBody.AddForce(downForce);
        }

        if(collision.gameObject.tag == "wall")
        {  
            Vector2 wallForce = new Vector2(xForce * xDirection * -1, yForce);
            enemyRigidBody.AddForce(wallForce);
        }
    }
}
