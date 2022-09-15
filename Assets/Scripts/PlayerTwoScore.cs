using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>PlayerTwoScore</c> manages the screen text of the score.
/// </summary>
public class PlayerTwoScore : MonoBehaviour {
    public Text scoreText;

    void Update() {
        scoreText.text = FindObjectOfType<PlayerTwo>().GetScore().ToString();
    }
}
