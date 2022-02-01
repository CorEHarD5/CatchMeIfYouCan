using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {
    public Transform player;
    public Vector3 rotation;

    void Start() {
        rotation = new Vector3(0, 0, 0);
    }

    void Update() {
        rotation.z = Camera.main.transform.eulerAngles.y;
        transform.localEulerAngles = rotation;
    }
}
