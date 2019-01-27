using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public static class Analyser {

    public static bool s1f = false, s2f = false, s3f = false, s4f = false, s5f = false;

    public static Image i1, i2, i3, i4;
    public static UIStatistics ui;
    public static UIGoals goals;

    public static GameManager gm;

    public static int antennas = 0, divices = 0, money = 24000, coDivices = 0;

    /*
    public static int lastGenAntennas;
    public static float happines, progression;
    */

    public static void AddCoDivice() {
        coDivices++;
        if (ui != null) ui.CoDivices();
        if (goals != null) goals.Refresh();

        if (coDivices == 25) {
            if (i1 != null) i1.gameObject.SetActive(true);
            if (antennas >= 5) gm.EndGame();
        }
    }

    public static void LoseCoDivice() {
        coDivices--;
        if (goals != null) goals.Refresh();
    }

    public static void AddAntena() {
        antennas++;
        if (ui != null) ui.Antennas();
        if (goals != null) goals.Refresh();

        if (antennas == 5) {
            if (i2 != null) i2.gameObject.SetActive(true);
            if (antennas >= 25) gm.EndGame();
        }
    }

    public static void AddDivice() {
        divices++;
        if (ui != null) ui.Divices();
    }

    public static void Money() {
        if (ui != null) ui.Money();
    }

}

/*
    private static void Send(string tag, int var) {
        if (GameObject.FindGameObjectWithTag(tag) != null) {
            Text text = GameObject.FindGameObjectWithTag(tag).GetComponent<Text>();
            text.text = var.ToString();
        }
    }
 */

/* Money
 * Zakładamy że zmienna w ustawionym przez nas czasie będzie dostwać + (wartość).
 * Wiemy też że kupienie anteny spowoduje odliczenie - (wartość) od niej.
 * Set będzie zawsze taki sam więc można 
 */

/* Analyser
 * The main purpose of this script is to contain all the values about curroent divices, connected divices, antennas, lastGenAntennas, money, goal of game, happines and progression.
 * It basicly collates all the values and counts them to show as certain numbers and percentages.
 */


/* Workflow
 *  All the anthenas and divices could be childs of this objects and easy share their data to their parent Analyser.. i guess.
 */
