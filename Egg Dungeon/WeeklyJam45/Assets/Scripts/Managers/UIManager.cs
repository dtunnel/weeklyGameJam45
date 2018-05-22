using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public Text TimerText;
    private GameManager gameManager;
    private float timeLeft;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timeLeft = gameManager.timeLeftMinutes;
    }

    // Update is called once per frame
    void Update() {
        timeLeft = gameManager.timeLeftMinutes;
        string minutesLeft;
        string secondsLeft;

        if (timeLeft % 60f > 59f) {
            minutesLeft = ((int)(timeLeft / 60f) + 1).ToString();
            secondsLeft = "00";
        }
        else {
            minutesLeft = ((int)(timeLeft / 60f)).ToString();
            secondsLeft = ((timeLeft % 60f)).ToString("f0");
        }

        if (timeLeft % 60f < 10) {
            TimerText.text = minutesLeft + ":0" + secondsLeft;
        }
        else
            TimerText.text = minutesLeft + ":" + secondsLeft;
	}
}
