using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _turnDirection;
    private float thrustSpeed = 1.0f;
    private float turnSpeed = 1.0f;
    private Rigidbody2D _rigidbody;
    public Bullet bulletPrefab;

    //Will be called 1 time when initiating 
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //To update when keys are pressed
    private void Update() {
       //when A or Left key is pressed
       if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
       {
           _turnDirection = 1.0f;  //turn to left
       }

       //when D or Right key is pressed
       else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
       {
           _turnDirection = -1.0f;  //turn to right
       }
       else
       {

           _turnDirection = 0.0f;  //remain stationary 
       }

       if (Input.GetKeyDown(KeyCode.Space))
       {
           Shoot();
       }

       

    }

    private void FixedUpdate() 
    {
        //when W or up key is pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed); //to move forward in 2D game
        }
        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed); //to rotate object
        }
    }

    //shoot bullet
   private void Shoot()
   {
       //to let bullet be in the same position as the player
       Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
       bullet.Project(this.transform.up);  //project bullet in up direction
   }
}
