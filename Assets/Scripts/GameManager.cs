using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>GameManager</c> manages some functionality of the game.
/// </summary>
public class GameManager : MonoBehaviour {
    private int targetScore = 21;

    void Update() {
        CheckQuitAction();
        CheckEndGame();
    }

    /// <summary>
    /// This method checks if player hits the escape key and quits the game.
    /// </summary>
    void CheckQuitAction() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    /// <summary>
    /// This method checks if any player has achieved the target score and
    /// ends the game.
    /// </summary>
    void CheckEndGame() {
        if (FindObjectOfType<PlayerOne>().GetScore() == targetScore) {
            SceneManager.LoadScene(2);
        }
        if (FindObjectOfType<PlayerTwo>().GetScore() == targetScore) {
            SceneManager.LoadScene(2);
        }
    }
}
