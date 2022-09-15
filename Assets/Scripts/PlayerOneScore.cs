using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>PlayerOneScore</c> manages the screen text of the score.
/// </summary>
public class PlayerOneScore : MonoBehaviour {
    public Text scoreText;

    void Update() {
        scoreText.text = FindObjectOfType<PlayerOne>().GetScore().ToString();
    }
}
