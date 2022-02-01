using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {
    public delegate void onClickDelegate();
    public static event onClickDelegate onClickRestartGUI;

    public void Restart() {
        onClickRestartGUI();
    }
}
