using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {
    public delegate void OnEnemyCollisionDelegate(int value);
    public delegate void OnAllyCollisionDelegate();
    public static event OnEnemyCollisionDelegate OnCollisionIncMaxScore;
    public static event OnAllyCollisionDelegate OnCollisionIncRestartScore;

    Rigidbody rbTarget;
    private float destroyTimer;
    public bool isAlive;
    public AudioSource audioSourceHit;

    void Start() {
        rbTarget = GetComponent<Rigidbody>();
        destroyTimer = 3f;
        isAlive = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (isAlive && collision.gameObject.tag == "bullet") {
            audioSourceHit.Play();
            rbTarget.useGravity = true;
            isAlive = false;
            if (this.gameObject.tag == "santa") {
                OnCollisionIncMaxScore(20);
            } else if (this.gameObject.tag == "robber") {
                OnCollisionIncMaxScore(5);
            } else {
                OnCollisionIncRestartScore();
            }
            Destroy(this.gameObject, destroyTimer);
        }
    }

}
