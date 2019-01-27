using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineGenerator : MonoBehaviour {

    public int vectors = 10;
    public int bowVectors = 2;
    public float radius = 2;

    private LineRenderer lr;

    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    private void Start() {
        Vector3 position;
        float deltaTheta = ((2f * Mathf.PI) / ((vectors))); //* bowVectors) + vectors));
        float theta = 0f;
        int n = 0;

        //BowVectors
        //float z = 1f / (bowVectors - 1); - the radius thats being added and subtraced while creating new positions
        //bool down = false; - when we hit our number that bool says that from now on we're going back to normal number

        lr.positionCount = vectors; //* bowVectors + vectors;
        for (int a = 0; a < vectors; a++) {
            //int r = Random.Range(0, 3); - getting rundom number for radius to make some of the points more stretched
            position = new Vector3((radius) * Mathf.Cos(theta), (radius) * Mathf.Sin(theta), 0);
            Debug.Log(gameObject.name + ": Main, " + position.x);
            lr.SetPosition(n, position);

            theta += deltaTheta; n++;

            Vector3 nPosition = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0); //Poz następnego punktu.
            float distance = Vector3.Distance(position, nPosition); // Długość pomiędzy punktami.
            Debug.Log("dystans: " + distance);
            distance /= bowVectors;

            for (int b = 0; b < bowVectors; b++) { //oblicza position ale nie ma wpływu.
                position = position + new Vector3(distance, distance, 0);
            }
            
            //float x = z;
            
            /*
            for (int b = 0; b < bowVectors; b++) {
                position = new Vector3((radius + x) * Mathf.Cos(theta), (radius + x) * Mathf.Sin(theta), 0);
                Debug.Log(gameObject.name + ": Err, " + position.x);
                lr.SetPosition(n, position);
                theta += deltaTheta; n++;
                Debug.Log(x);
                if (x == 1) down = true;
                if (down) x -= z;
                else x += z;
            }
            */
        }
    }
}

    /* Plan Koła
     * delta theta - Podzielenie okręgu na w tym przypadku 10 częsći.
     * W pętli tworzymy vector co wcześniej wyznaczoną długość pomiędzy punktami poprzez dodawanie do theta zmiennej delta theta.
     */

    /* Problem koła i dlaczego nie może byc to koło.
     * Tworzenie punktów łokowych pomiędzy vektorami prowadzi do rozciągania istniejącego już łuku.
     * tworzy w ten sposób łuk nigdy nie bedzie łukiem ze względu na podstawę.
     */

    /* Wielokąty!
     * 
     */
