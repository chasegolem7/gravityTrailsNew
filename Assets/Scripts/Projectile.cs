using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Throwable direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.FindGameObjectWithTag("Player").GetComponent<Throwable>();
        Invoke("DestroyThrowable", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.offset * Time.deltaTime * speed;
    }

       private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {  
            Destroy(collision.gameObject);
            Destroy(gameObject);
            // enemyCount -= 1;
        }
        
        if(collision.gameObject.tag == "wall" || collision.gameObject.tag == "ground")
        {  
            Destroy(gameObject);
        }
    }

    private void DestroyThrowable()
    {
        Destroy(gameObject);
    }

}
