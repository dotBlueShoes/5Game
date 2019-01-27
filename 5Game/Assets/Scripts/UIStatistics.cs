using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatistics : MonoBehaviour {

    public Text money, antennas, divices, coDivices;

    private void Awake() {
        Analyser.ui = this;
    }

    private void OnEnable() {
        CoDivices();
        Antennas();
        Divices();
        Money();
    }

    public void CoDivices() { coDivices.text = Analyser.coDivices.ToString(); }
    public void Antennas() { antennas.text = Analyser.antennas.ToString(); }
    public void Divices() { divices.text = Analyser.divices.ToString(); }
    public void Money() { money.text = Analyser.money.ToString(); }

}
