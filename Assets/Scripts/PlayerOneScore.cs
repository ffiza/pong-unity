using UnityEngine;
using UnityEngine.UI;

public class PlayerOneScore : MonoBehaviour {
    public Text scoreText;

    void Update() {
        scoreText.text = FindObjectOfType<PlayerOne>().GetScore().ToString();
    }
}
