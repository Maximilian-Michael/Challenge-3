using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = true;

    public float floatForce = 10.0f;
    private float gravityModifier = 1.0f;
    public Rigidbody playerRb;
    
    

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
       
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
        if (transform.position.y > 16 )
        {
            transform.position = new Vector3(transform.position.x, 16, transform.position.z);
            playerRb.AddForce(Vector3.down * 8, ForceMode.Impulse);
        }
        else if(transform.position.y == 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }





    }

    private void OnCollisionEnter(Collision collision)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (collision.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(collision.gameObject);
        } 

        // if player collides with money, fireworks
        else if (collision.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(collision.collider.gameObject);

        }

        

        

    }

}
