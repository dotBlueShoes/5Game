using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    private List<GameObject> divices = new List<GameObject>();

    private void Start() {
        Analyser.AddAntena();
        divices.Clear();
    }

    public void ShowDivices() {
        foreach (var element in divices) {
            Debug.Log(element);
        }
        if (divices.Count == 0) { Debug.Log("No divices connected"); }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        Divice divice = col.gameObject.GetComponent<Divice>();
        float distance = Vector2.Distance(transform.position, col.gameObject.transform.position);
        divice.Orbit(transform, distance);

        divices.Add(col.gameObject);
        Analyser.AddCoDivice();
    }

    private void OnTriggerExit2D(Collider2D col) {
        divices.Remove(col.gameObject);
        Analyser.LoseCoDivice();
    }
}

/* Bug z AddCoDivice();
 * Urządzenie po zetknięciu z polem nowej anteny jest dodawane do CoDivices kiedy informacja o usunięciu go z CoDivices wcześniejszej anteny odświeża się dopiero kiedy wyjdzie z jego pola.
 * roz1. Ustalić czy urzadzenie nie znajduje się już w CoDivices...
 * roz2. //Za dużo na ten etap.
 */ 

/* Divices Class
 * It shares GameObject and an Intiger identificator value for each of divices. also his happines??? 
 */ 
