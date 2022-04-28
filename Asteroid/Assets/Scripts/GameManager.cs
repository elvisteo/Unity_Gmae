using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public float repawnInvul = 3.0f;
    int score = 0;
    public TextMeshProUGUI HealthText;
    public Text ScoreText;
    public GameOver GameOverScreen;
    public Congrats CongratsScreen;
    private int target = 100;

    private void Start()
    {
        HealthText = FindObjectOfType<TextMeshProUGUI>();
        HealthText.SetText(lives.ToString()); //to show the live

        ScoreText.text = "Score: "+score.ToString() + " (" + target + ")";
       
    }

    //Event for when asteroid is destroyed
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position; //set it to where the position of asteroid is
        this.explosion.Play(); //play the explosion 

        //increase score
        if (asteroid.size < 0.75f)
        {
            this.score += 5; 
        }
        else if (asteroid.size < 1.0f)
        {
            this.score += 10;
        }
        else
        {
            this.score += 15;
        }

        if (this.score >= target)
        {
            GameWin();
        }

        ScoreText.text = "Score: "+this.score.ToString() + " (" + target + ")"; //to update the scoreboard when asteroid is destroyed
    }

    public void PlayerDeath()
    {
        this.explosion.transform.position = this.player.transform.position; //set it to where the position of player is
        this.explosion.Play(); //play the explosion when player died

        this.lives--; //reduce 1 life 

        HealthText.SetText(lives.ToString()); //update the board

        if (lives == 0)
        {
            GameOver();
        }
        else
        {
           Invoke(nameof(Respawn), this.respawnTime);
        }


    }

    //To revive player and let player to be invulnerable to asteroid for 3 sec
    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Immune");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollision), this.repawnInvul);
    }

    private void TurnOnCollision()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        GameOverScreen.Setup(score);
    }
    private void GameWin()
    {
        CongratsScreen.Congrat(this.score);
    }
}
