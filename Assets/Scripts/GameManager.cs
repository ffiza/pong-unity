using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private int targetScore = 21;

    void Update() {
        CheckQuitAction();
        CheckEndGame();
    }

    void CheckQuitAction() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    void CheckEndGame() {
        if (FindObjectOfType<PlayerOne>().GetScore() == targetScore) {
            SceneManager.LoadScene(2);
        }
        if (FindObjectOfType<PlayerTwo>().GetScore() == targetScore) {
            SceneManager.LoadScene(2);
        }
    }
}
