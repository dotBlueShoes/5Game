using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Image mark1, mark2, mark3, mark4;
    public Sprite checkmark;

    private void Start() {
        if (Analyser.s1f == true) mark1.sprite = checkmark;
        if (Analyser.s2f == true) mark2.sprite = checkmark;
        if (Analyser.s3f == true) mark3.sprite = checkmark;
        if (Analyser.s4f == true) mark4.sprite = checkmark;
    }

    public void Level1() {
        SceneManager.LoadScene(1);
    }

    public void Level2() {
        SceneManager.LoadScene(1);
    }

    public void Level3() {
        SceneManager.LoadScene(1);
    }

    public void Level4() {
        SceneManager.LoadScene(1);
    }

    public void Level5() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    //Zmienić Image X na Okejke
}
