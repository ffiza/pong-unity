using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PlayerOne</c> manages the movement and score of player one.
/// </summary>
public class PlayerOne : MonoBehaviour {
    public float verticalVelocity = 10f;
    private Vector3 velocity;
    private int score = 0;

    void FixedUpdate() {
        Move();
    }

    /// <summary>
    /// This method moves the player on key press.
    /// </summary>
    void Move() {
        velocity = new Vector3(0, verticalVelocity*Time.deltaTime, 0);

        if (Input.GetKey("q")) {
            transform.position += velocity;
        }
        if (Input.GetKey("a")) {
            transform.position -= velocity;
        }
    }

    /// <summary>
    /// This method increases the score of the player.
    /// </summary>
    public void IncreaseScore() {
        score += 1;
    }

    /// <summary>
    /// Getter method for the score.
    /// </summary>
    public int GetScore() {
        return score;
    }
}
