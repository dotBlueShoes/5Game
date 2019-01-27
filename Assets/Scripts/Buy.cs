using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour {

    public GameObject anten;
    public Texture2D cursor;
    public Text flow;

    private Camera cam;

    private const int antenaCost = 3000;
    //private bool onUse; W iEmulatorze trzeba było wyłączyć UI z prawego przycisku myszy. Lekki prob ma MoneyFlow.

    private void Awake() {
        cam = Camera.main;

        flow.color = new Vector4(0, 0, 0, 0);
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


    public void PurchaseAntenna() {
        if (Analyser.money < antenaCost) {
            Debug.Log("Not enought money"); // play sound
        }
        else {
            Analyser.money -= antenaCost;
            Analyser.Money();
            StartCoroutine(MoneyFlow());
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move() {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);

        while (!Input.GetMouseButtonDown(0)) {
            yield return null;
        }

        Instantiate(anten, (Vector2)cam.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0, 0, 0, 0));
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

/* Old Code
 * public GameObject antenna, antennaIcon;
    private GameObject attachment;
    private Camera cam;


    private void Awake() {
        cam = Camera.main;
    }

    public void BuyAntenna() {
        Debug.Log("U've brought an Antenna");

        if (attachment == null) attachment = Instantiate(antennaIcon, Input.mousePosition, new Quaternion(0, 0, 0, 0));
        else attachment.SetActive(true);

        StartCoroutine(Move());
    }

    private IEnumerator Move() {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        while (!Input.GetMouseButtonDown(0)) {
            attachment.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            yield return null;
        }
        attachment.SetActive(false);
        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(antenna, pos, new Quaternion(0, 0, 0, 0));
    }
 */
