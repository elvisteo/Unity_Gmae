using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float bulletSpeed = 500.0f;
    public float duration = 10.0f;

    //initiate
    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //to project/shoot bullet in a direction
    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.bulletSpeed); //project bullet in a direction

        Destroy(this.gameObject, this.duration); //destroy the bullet after 10s
    }

    //when collision with object
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(this.gameObject); //destroy anything in collision
    }
}
