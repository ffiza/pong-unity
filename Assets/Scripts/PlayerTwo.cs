using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {
    public float verticalVelocity = 10f;
    private Vector3 velocity;
    private int score = 0;

    void FixedUpdate() {
        Move();
    }

    void Move() {
        velocity = new Vector3(0, verticalVelocity*Time.deltaTime, 0);

        if (Input.GetKey("up")) {
            transform.position += velocity;
        }
        if (Input.GetKey("down")) {
            transform.position -= velocity;
        }
    }

    public void IncreaseScore() {
        score += 1;
    }

    public int GetScore() {
        return score;
    }
}
