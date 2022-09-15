using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>EndGameScreen</c> manages the play again functionality.
/// </summary>
public class EndGameScreen : MonoBehaviour {
    void Update() {
        CheckPlayAgain();
    }

    /// <summary>
    /// This method restarts the game if the player presses a key.
    /// </summary>
    void CheckPlayAgain() {
        if (Input.GetKey("space")) {
            SceneManager.LoadScene(1);
        }
    }
}
