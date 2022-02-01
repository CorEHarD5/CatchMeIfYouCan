using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThis : MonoBehaviour {
    public static DontDestroyThis dontDestroyThis;
    void Awake() {
        if (dontDestroyThis == null) {
            dontDestroyThis = this;
            DontDestroyOnLoad(this);
        } else if (dontDestroyThis != this) {
            Destroy(gameObject);
        }
    }
}
