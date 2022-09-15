using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>StarGame</c> manages the start of the game.
/// </summary>
public class StartGame : MonoBehaviour {
    void Update() {
        CheckInitGame();
    }

    /// <summary>
    /// This method starts the game on key press.
    /// </summary>
    void CheckInitGame() {
        if (Input.GetKey("space")) {
            SceneManager.LoadScene(1);
        }
    }
}