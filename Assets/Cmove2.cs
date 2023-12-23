using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmove2 : MonoBehaviour
{
    public float yForce;
    private Rigidbody2D enemyRigidBody;
   
    public void FixedUpdate(){

    }
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2d(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            Vector2 jumpForce = new Vector2(0, yForce);
            enemyRigidBody.AddForce(jumpForce);
        }
    }
}
