using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour {
    void Update() {
        CheckPlayAgain();
    }

    void CheckPlayAgain() {
        if (Input.GetKey("space")) {
            SceneManager.LoadScene(1);
        }
    }
}
