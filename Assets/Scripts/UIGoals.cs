using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoals : MonoBehaviour {

    public Text goal1, goal2, goal3, goal4;
    public Image mark1, mark2, mark3, mark4;

    private void Awake() {
        Analyser.goals = this;
        Analyser.i1 = mark1;
        Analyser.i2 = mark2;
        Analyser.i3 = mark3;
        Analyser.i4 = mark4;
    }

    public void Refresh() {
        goal1.text = Analyser.coDivices.ToString() + "/25";
        goal2.text = Analyser.antennas.ToString() + "/5";
    }
}
