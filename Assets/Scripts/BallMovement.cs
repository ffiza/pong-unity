using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BallMovement</c> manages the movement of the ball and related
/// functionality.
/// </summary>
public class BallMovement : MonoBehaviour {
    public Animator animator;
    private float ballVelocity = 6f;
    private float velocityIncreaseStep = 0.25f;
    private Vector3 direction;

    void Start() {
        // Define initial direction of motion.
        DefineDirection();
    }

    void Update() {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        /* If the ball collide with edges, make it bounce, animate it
        and play sound.*/
        if (collision.gameObject.tag == "Edge") {
            // Get the collision normal.
            Vector3 collisionNormal = collision.GetContact(0).normal;
            // Change the direction.
            direction += 2f * collisionNormal;

            LaunchAnimation();
            FindObjectOfType<AudioManager>().PlaySound("BounceSound");
        }

        // If the ball collides with players, make it bounce with care.
        // TODO: There's probably a better way of doing this.
        if (collision.gameObject.tag == "Player") {
            Vector3 collisionNormal = collision.GetContact(0).normal;
            if (collisionNormal.x == 1f && transform.position.x < 0) {
                direction += 2f * collisionNormal;
                LaunchAnimation();
                FindObjectOfType<AudioManager>().PlaySound("BounceSound");
            }
            if (collisionNormal.x == -1f && transform.position.x > 0) {
                direction += 2f * collisionNormal;
                LaunchAnimation();
                FindObjectOfType<AudioManager>().PlaySound("BounceSound");
            }
        }

        /* If the ball collides with the score triggers increase the score, 
        reset the ball, play the score sound and increase the velocity. */
        if (collision.gameObject.tag == "ScoreTrigger") {
            // Increase the score of player one.
            if (transform.position.x > 0) {
                FindObjectOfType<PlayerOne>().IncreaseScore();
            }
            // Increase the score of player two.
            else if (transform.position.x < 0) {
                FindObjectOfType<PlayerTwo>().IncreaseScore();
            }
            // Reset the position of the ball.
            Reset();
            // Play the score sound.
            FindObjectOfType<AudioManager>().PlaySound("ScoreSound");
            // Increase the velocity of the ball.
            IncreaseVelocity();
        }
    }

    /// <summary>
    /// This method sets the direction of the ball.
    /// </summary>
    void DefineDirection() {
        // TODO: Use a random direction.
        direction = new Vector3(1f, 1f, 0f);
    }

    /// <summary>
    /// This method moves the ball.
    /// </summary>
    void Move() {
        transform.position += direction * ballVelocity * Time.deltaTime;
    }

    /// <summary>
    /// This method resets the position of the ball to the origin.
    /// </summary>
    void Reset() {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    /// <summary>
    /// This method starts the light animation when bouncing..
    /// </summary>
    void LaunchAnimation() {
        animator.Play("Idle");
        animator.Play("BallLight");
    }

    /// <summary>
    /// This method increses the velocity of the ball by a given step.
    /// </summary>
    void IncreaseVelocity() {
        ballVelocity += velocityIncreaseStep;
    }
}
