using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoScore : MonoBehaviour {
    public Text scoreText;

    void Update() {
        scoreText.text = FindObjectOfType<PlayerTwo>().GetScore().ToString();
    }
}
