using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
        
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 50.0f)
        {
            Destroy(gameObject);
        }
    }
}
