using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour {
    public GameObject player;

    void Start() {
        transform.LookAt(player.transform);
    }
}
