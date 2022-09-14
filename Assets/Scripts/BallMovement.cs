using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public Animator animator;
    private float ballVelocity = 6f;
    private float velocityIncreaseStep = 0.25f;
    private Vector3 direction;

    void Start() {
        // Define initial direction of motion.
        direction = new Vector3(1f, 1f, 0f);
    }

    void Update() {
        // Move ball according to direction of motion.
        transform.position += direction * ballVelocity * Time.deltaTime;
    }

    void Reset() {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // If the ball collide with edges, make it bounce.
        if (collision.gameObject.tag == "Edge") {
            Vector3 collisionNormal = collision.GetContact(0).normal;
            direction += 2f * collisionNormal;
            LaunchAnimation();
            FindObjectOfType<AudioManager>().PlaySound("BounceSound");
        }

        // If the ball collides with players, make it bounce with care.
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

        /* If the ball collides with the score triggers, reset the ball,
        increase the score and spawn a new ball. */
        if (collision.gameObject.tag == "ScoreTrigger") {
            // Increase score.
            if (transform.position.x > 0) {
                FindObjectOfType<PlayerOne>().IncreaseScore();
            }
            else if (transform.position.x < 0) {
                FindObjectOfType<PlayerTwo>().IncreaseScore();
            }
            // Reset the position of the ball and increase speed.
            Reset();
            FindObjectOfType<AudioManager>().PlaySound("ScoreSound");
            IncreaseSpeed();
        }
    }

    void LaunchAnimation() {
        animator.Play("Idle");
        animator.Play("BallLight");
    }

    void IncreaseSpeed() {
        ballVelocity += velocityIncreaseStep;
    }
}
