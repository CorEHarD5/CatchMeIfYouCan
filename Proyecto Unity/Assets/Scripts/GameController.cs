using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController gameController;

    private bool isGameFinished;

    private int maxScore;
    private int correction;
    private int nShoots;
    private int score;
    private int livingRobbers;
    private int maxRobbers;

    public GameObject fireworkPrefab1;
    public GameObject fireworkPrefab2;
    public GameObject fireworkPrefab3;
    public GameObject fireworkPrefab4;
    public GameObject fireworkPrefab5;

    public Transform fireworkLocalization1;
    public Transform fireworkLocalization2;
    public Transform fireworkLocalization3;
    public Transform fireworkLocalization4;
    public Transform fireworkLocalization5;

    public Text scoreText;
    public Text shootsText;
    public Text endGameText;

    void Awake() {
        if (gameController == null) {
            gameController = this;
            DontDestroyOnLoad(this);
        } else if (gameController != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        livingRobbers = GameObject.FindGameObjectsWithTag("robber").Length;
        maxRobbers = livingRobbers;
        Hit.OnCollisionIncMaxScore += IncMaxScore;
        Hit.OnCollisionIncRestartScore += RestartScore;
        SimpleShoot.OnShootIncShootNum += IncShootNum;
        RestartGame.onClickRestartGUI += RestartAll;

        isGameFinished = false;
        maxScore = 0;
        correction = 0;
        score = 0;
        nShoots = 0;
    }

    void Update() {
        if (!isGameFinished && livingRobbers == 0) {
            isGameFinished = true;
            EndGame();
        }
    }

    void IncMaxScore(int value) {
        if (!isGameFinished) {
            maxScore += value;
            correction++;
            updateScore();

            if (value == 5) livingRobbers--;
        }
    }

    void IncShootNum () {
        if (!isGameFinished) {
            nShoots++;
            shootsText.text = $"Disparos: {nShoots}";
            updateScore();
        }
    }

    void updateScore() {
        if (!isGameFinished) {
            score = maxScore - nShoots + correction;
            if (score < 0) score = 0;
            scoreText.text = $"Puntuación: {score}";
        }
    }

    void RestartScore() {
        if (!isGameFinished) {
            score = 0;
            correction++;
            scoreText.text = $"Puntuación: {score}";
        }
    }

    void RestartAll() {
        endGameText.text = "";
        isGameFinished = false;
        maxScore = 0;
        correction = 0;
        score = 0;
        nShoots = 0;
        livingRobbers = maxRobbers;
        scoreText.text = "Puntuación: 0";
        shootsText.text = "Disparos: 0";
        SceneManager.LoadScene("MainScene");
    }

    void EndGame() {
        // TODO: Fireworks
        endGameText.text = "¡Felicidades!\n¡La ciudad está limpia de malandros!";
        Instantiate(fireworkPrefab1, fireworkLocalization1.position, fireworkLocalization1.rotation);
        Instantiate(fireworkPrefab2, fireworkLocalization2.position, fireworkLocalization2.rotation);
        Instantiate(fireworkPrefab3, fireworkLocalization3.position, fireworkLocalization3.rotation);
        Instantiate(fireworkPrefab4, fireworkLocalization4.position, fireworkLocalization4.rotation);
        Instantiate(fireworkPrefab5, fireworkLocalization5.position, fireworkLocalization5.rotation);
    }

    void OnDisable() {
        Hit.OnCollisionIncMaxScore -= IncMaxScore;
        SimpleShoot.OnShootIncShootNum -= IncShootNum;
        Hit.OnCollisionIncRestartScore -= RestartScore;
        RestartGame.onClickRestartGUI -= RestartAll;
    }
}
