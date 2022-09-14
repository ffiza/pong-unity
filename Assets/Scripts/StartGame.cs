using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    void Update() {
        CheckInitGame();
    }
    
    void CheckInitGame() {
        if (Input.GetKey("space")) {
            SceneManager.LoadScene(1);
        }
    }
}