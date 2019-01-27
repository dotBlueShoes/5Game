using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Transform antenna = null;


    public float lenght = 5.0f;
    public float speed = 1.0f;

    private void LateUpdate () {
        transform.position = antenna.position + (transform.position - antenna.position).normalized * lenght;
        transform.RotateAround(antenna.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
    }

    public IEnumerator Distance() {
        float b = Random.Range(0, 1);
        float a = 0.01f;
        while (a < 1) {
            if (lenght < 1) break;
            lenght = lenght - ((b/0.01f) + 0.01f); 
            a += 0.01f;
            yield return null;
        }
    }
}

/* Zmienna lenght
 * Divice uruchamia IEmulator który zmnniejsza powoli długość lenght o 1 + randomowa liczba do max 2f. 
 */ 

//Orbital movement

/* Move Idea
 * Basicly i wan't object to move forward in random direction and when it hits the box / get to max range it bounces and moves on the same lane
 */
