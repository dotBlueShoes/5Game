using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Image mark1, mark2, mark3, mark4;
    public Sprite checkmark;

    private void Start() {
        bool[] data = SaveSystem.LoadData();

        if (data != null) {
            Analyser.s1f = data[0];
            Analyser.s2f = data[1];
            Analyser.s3f = data[2];
            Analyser.s4f = data[3];
            Analyser.s5f = data[4];
        }
        Debug.Log(data);

        if (Analyser.s1f == true) mark1.sprite = checkmark;
        if (Analyser.s2f == true) mark2.sprite = checkmark;
        if (Analyser.s3f == true) mark3.sprite = checkmark;
        if (Analyser.s4f == true) mark4.sprite = checkmark;
    }

    public void Level1() {
        Analyser.divices = 0;
        Analyser.antennas = 0;
        Analyser.coDivices = 0;
        SceneManager.LoadScene(1);
    }

    public void Level2() {
        Analyser.divices = 0;
        Analyser.antennas = 0;
        Analyser.coDivices = 0;
        SceneManager.LoadScene(1);
    }

    public void Level3() {
        Analyser.divices = 0;
        Analyser.antennas = 0;
        Analyser.coDivices = 0;
        SceneManager.LoadScene(1);
    }

    public void Level4() {
        Analyser.divices = 0;
        Analyser.antennas = 0;
        Analyser.coDivices = 0;
        SceneManager.LoadScene(1);
    }

    public void Level5() {
        Analyser.divices = 0;
        Analyser.antennas = 0;
        Analyser.coDivices = 0;
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    //Zmienić Image X na Okejke
}
