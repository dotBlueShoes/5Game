using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public BoardInitializer boardInitializer;
    public Material mA, mB, mC, mD;

    public float maxSpeed, minSpeed;

    private Vector3 pos, nPos;
    private Vector2 ori, dir;
    private Color color;
    private Camera cam;

    private float height, width;

    private void Awake() {
        cam = Camera.main;

        ori = Vector2.zero; dir = Vector2.zero;
        pos = transform.position;

        //Setting Up the Colors for masks.
        color = new Vector4(1, 1, 1, 0);
        mA.color = color;
        mB.color = color;
        mC.color = color;
        mD.color = color;

        // Do zmiany kod przy powiększaniu, zmniejszaniu wielk. kamery.
        height = cam.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void Update() {     
        if (Input.GetMouseButtonDown(0)) { //Origin Input
            ori = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) { //Direction Input
            dir = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) { // IEnumelator!!!! i będzie 
            StartCoroutine(Slide());
        }
    }

    private IEnumerator Slide() {
        pos = -2 * (Camera.main.ScreenToWorldPoint(dir) - Camera.main.ScreenToWorldPoint(ori));
        pos += transform.position;
        float sqrRemainingDistance = (transform.position - pos).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon) {
            if (sqrRemainingDistance > maxSpeed) nPos = Vector3.MoveTowards(transform.position, pos, maxSpeed * Time.deltaTime);
            else nPos = Vector3.MoveTowards(transform.position, pos, (sqrRemainingDistance / maxSpeed + minSpeed) * Time.deltaTime);
            float clampH = Mathf.Clamp(nPos.y, boardInitializer.MinB.y + height, boardInitializer.MaxB.y - height);
            float clampW = Mathf.Clamp(nPos.x, boardInitializer.MinB.x + width, boardInitializer.MaxB.x - width);

            if (clampW == boardInitializer.MinB.x + width) {
                break;
            }
            if (clampW == boardInitializer.MaxB.x - width) {
                break;
            }
            if (clampH == boardInitializer.MinB.y + height) {
                break;
            }
            if (clampH == boardInitializer.MaxB.y - height) {
                break;
            }

            transform.position = new Vector3(clampW, clampH, transform.position.z);
            MaskTransparent();

            sqrRemainingDistance = (transform.position - pos).sqrMagnitude;
            yield return null;
        }
    }

    private void MaskTransparent() {
        if (transform.position.x - width < boardInitializer.MinI.x) {
            color.a = (transform.position.x - width - boardInitializer.MinI.x) / -boardInitializer.length;
            mD.color = color;
        }
        else if (transform.position.x + width > boardInitializer.MaxI.x) {
            color.a = (transform.position.x + width - boardInitializer.MaxI.x) / boardInitializer.length;
            mB.color = color;
        }
        if (transform.position.y - height < boardInitializer.MinI.y) {
            color.a = (transform.position.y - height - boardInitializer.MinI.y) / -boardInitializer.length;
            mC.color = color;
        }
        else if (transform.position.y + height > boardInitializer.MaxI.y) {
            color.a = (transform.position.y + height - boardInitializer.MaxI.y) / boardInitializer.length;
            mA.color = color;
        }
    }

    
}

/* Prototype
    public void MaskEnable(int n) {
        if (n == 0) {
            maskA.SetActive(true);
        }
        if (n == 1) {
            maskB.SetActive(true);
        }
        if (n == 2) {
            maskC.SetActive(true);
        }
        if (n == 3) {
            maskD.SetActive(true);
        }
        color.a += 1f * Time.deltaTime;
        material.color = color;
    }
    */

/*Krawędź
 * Przy pobieraniu informacji o inside.bounds piebieramy starą informację...
 * Aby tego uniknąć można by się odwołać do skryptu odpowiedzialnego za zmienę jego boundsów i pobrać z tamtąd wartość zmiennych.
 * W ten sposób trzeba utworzyć zmienną przechowującą skrypt i obiekt board'a.
 * następnie odwołać skrypt do obiektu.
 * Ze skryptu zczytujemy wartość minB, maxB, minI, maxI.
 */

/* Znak końca mapy
 * Kiedy przekraczamy określoną wielkość mapy i zbliżamy się do jej końca zaczyna nam się odsłaniać maska nałozona na UI informująca nas o tym że jesteśmy bliżej krawędzi.
 * Kiedy oddalamy się od krawędzi maska staje się caraz to mniej widoczna.
 * 
 * Istnieje próg który zawsze znajduje się o (wartość) bliżej nas względem wielkości mapy.
 * Po przekroczeniu tego progu zależnie jak blisko jesteśmy krawędzi mapy zmieniać się będzie kanał alfa maski.
 */

/* V2
 * private IEnumerator Slide() {
        pos = -(Camera.main.ScreenToWorldPoint(dir) - Camera.main.ScreenToWorldPoint(ori));
        pos += transform.position;
        float sqrRemainingDistance = (transform.position - pos).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon) {
            nPos = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            float clampH = Mathf.Clamp(nPos.y, min.y + height, max.y - height);
            float clampW = Mathf.Clamp(nPos.x, min.x + width, max.x - width);
            if (clampW == min.x + width) {
                Debug.Log("Left Corner");
                break;
            }
            if (clampW == max.x - width) {
                Debug.Log("Right Corner");
                break;
            }
            if (clampH == min.y + height) {
                Debug.Log("Bot Corner");
                break;
            }
            if (clampH == max.y - height) {
                Debug.Log("Top Corner");
                break;
            }
            transform.position = new Vector3(clampW, clampH, transform.position.z);
            sqrRemainingDistance = (transform.position - pos).sqrMagnitude;
            yield return null;
        }
    }
 */

/* Old One
 * if (Input.GetMouseButtonUp(0)) { // IEMulator!!!! i będzie zajebiście

            pos = -(Camera.main.ScreenToWorldPoint(dir) - Camera.main.ScreenToWorldPoint(ori));
            pos += transform.position;

            nPos = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime); // Setting the Move

            float clampH = Mathf.Clamp(nPos.y, min.y + height, max.y - height); //Checking
            float clampW = Mathf.Clamp(nPos.x, min.x + width, max.x - width);

            // Checking for collision and stoping to movement on sides.
            if (nPos.x == min.x + width) {
                // Powinniśmy Kończyć cały ruch (całą funkcje ruchu). return false. 
                pos = transform.position;
                Debug.Log("Left Corner");
            }

            if (nPos.x == max.x - width) {
                pos = transform.position;
                Debug.Log("Right Corner");
            }

            if (nPos.y == min.y + height) {
                pos = transform.position;
                Debug.Log("Bot Corner");
            }

            if (nPos.y == max.y - height) {
                pos = transform.position;
                Debug.Log("Top Corner");
            }

            transform.position = new Vector3(clampW, clampH, transform.position.z);
        }
 */

/*
private IEnumerator SmoothMovement(Vector3 end) {
    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
    moveDone = false;
    while (sqrRemainingDistance > float.Epsilon) {
        Vector3 position = Vector3.MoveTowards(rb.position, end, speed * Time.deltaTime);
        rb.MovePosition(position);
        sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        yield return null;
    }
    moveDone = true;
    delay = false;
    col.enabled = true;
}
*/

/* Odciążenie Update'a
 * 1. Umieścić GetMouseButton(0) w GetMouseButtonDown(0) ;) jeśli się da. //Done!!!
 * 2. Stworzyć iEmulator który będzie nas przesuwał w danym kierunku na podstawnie reszty kodu + smooth move;
 * Pobieram Ori i Pos Myszy -> konwertuje na jednostki w świecie odejmuje je i neguje wartość żeby poruszać się w przeciwym kierunku.
 * -> dodaje tą pozycje do pozycji kamery żeby otrzymać punkt w którym pójdzie kamera ->
 */


/* Id clampH, clapmW
 *  clampH = Screen.height, ClampH = 0, clampW = Screen.width, clampW = 0
 *  Display Graphic at the top of camera.
 */
