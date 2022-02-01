using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {
    public AudioSource AudioSourceButton;

    public void Reproduce() {
        AudioSourceButton.Play();
    }
}
