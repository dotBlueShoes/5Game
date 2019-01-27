using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInitializer : MonoBehaviour {

    public Vector2 MinI { get { return inside.bounds.min; } }
    public Vector2 MaxI { get { return inside.bounds.max; } }
    public Vector2 MinB { get { return coll.bounds.min; } }
    public Vector2 MaxB { get { return coll.bounds.max; } }

    private Vector2 val;

    public Collider2D inside;
    public int length = 1;

    private Collider2D coll;
    private float x, y;

	void Awake() {
        coll = GetComponent<BoxCollider2D>();

        x = (inside.transform.lossyScale.x - length) / inside.transform.lossyScale.x;
        y = (inside.transform.lossyScale.y - length) / inside.transform.lossyScale.y;
        inside.transform.localScale = new Vector3(x, y, 1);
    }
}

//localScale == 1
//lossyScale == 50
//length == 5
//moja skala -> localScale == (50 - 5)/50



/* Krańce Mapy - pobieranie wartości pozycji kamery gracza i zmienianie przezroczystości maski.
 * Im bliżej gracz jest krańca mapy 
 * Za kazdym razem kiedy wykonywany jest ruch to zaleznie od wartości punktu docelowego ruchu zmieniana jest przezroczystośc maski o wartość równą:
 * 
 * Dla lewej ściany (im bliżej jesteśmy ściany tym mniej kanału alfa) (im mniejsza jest wartośćx tym mniej kanału alfa)
 *  wartośćx = bounds.min.x(-50) - transform.position.x 
 *  wartośćAlfaObiektu(0-1) = wartośćx(-25) / bounds.min.x
 *  
 * Dla Prawej ściany
 *  wartośćx = bounds.max.x(50) - transform.position.x
 *  wartośćAlfaObiektu(0-1) = wartośćx(25) / bounds.max.x
 *  
 * Dla Dolnej ściany
 *  wartośćy = bounds.min.y(-50) - transform.position.y
 *  wartośćAlfaObiektu(0-1) = wartośćy(-25) / bounds.min.y
 *  
 * Dla Górnej ściany
 *  wartośćy = bounds.max.y(50) - transform.position.y
 *  wartośćAlfaObiektu(0-1) = wartośćy(25) / bounds.max.y
 *  
 *  Jeśli transform.position > 0 -> max; else (transform.position < 0) -> min;
 */
