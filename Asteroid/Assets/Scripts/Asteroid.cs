using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float asteroidSpeed = 50.0f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    //initiate
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];  //to get random sprite in array

        this.transform.eulerAngles = new Vector3(0.0f,0.0f,Random.value*360.0f); //rotation
        this.transform.localScale = new Vector3(this.size, this.size, this.size); //size

        _rigidbody.mass = this.size; //mass
    }

    //let the asteroid move in a direction
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.asteroidSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((this.size * 0.5f) >= this.minSize)
            {
                Split();
                Split();
            }

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

        private void Split()
    {
        Vector2 position = this.transform.position; //get the current position of asteroid
        position += Random.insideUnitCircle * 0.5f; //change the direction of the small asteroid

        Asteroid half = Instantiate(this, position, this.transform.rotation); //craete a smaller asteorid
        half.size = this.size * 0.5f; // reduce the size
        half.SetTrajectory(Random.insideUnitSphere.normalized * this.asteroidSpeed); //set a new trajectory/angle of small asteroid
    }
}
