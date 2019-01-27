using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divice : MonoBehaviour {

    private Mover mover;

    private void Start() {
        Analyser.AddDivice();
        mover = GetComponent<Mover>();
    }

    public void Orbit(Transform t, float d) {
        mover.antenna = t; mover.lenght = d;
        mover.enabled = true;
        StartCoroutine(mover.Distance());
    }
}
