using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject menu, endScreen;
    public Text flow;

    public int grant = 2000, grantTime = 60;

    public void EndGame() {
        Analyser.s1f = true;
        SaveSystem.SaveData(Analyser.s1f, Analyser.s2f, Analyser.s3f, Analyser.s4f, Analyser.s5f);
        endScreen.SetActive(true);
    }

    private void Grant() {
        Analyser.money += grant;
        Analyser.Money();
        StartCoroutine(MoneyFlow());
    }

    private IEnumerator MoneyFlow() {
        float alpha = 0.01f;
        while (alpha < 1f) {
            flow.color = new Vector4(0, 0, 0, alpha);
            alpha += 0.01f;
            yield return null;
        }
        while (alpha > 0f) {
            flow.color = new Vector4(0, 0, 0, alpha);
            alpha -= 0.01f;
            yield return null;
        }
    }

    private void Start() {
        Analyser.gm = this;
        flow.color = new Vector4(0, 0, 0, 0);
        InvokeRepeating("Grant", grantTime, grantTime);
    }

    public void Options() {
        if (menu.activeSelf == false) menu.SetActive(true);
        else menu.SetActive(false);
    }

    private void Update () {
        if (Input.GetKeyDown("escape")) Options();
	}

    public void Exit() {
        SceneManager.LoadScene(0);
    }
}

