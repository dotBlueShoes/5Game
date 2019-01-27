using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject town;

    private GameObject mTown;
    private Vector2 pos;
    

	void Awake () {
        pos = new Vector2(30, 15);
        mTown = Instantiate(town, pos, new Quaternion(0, 0, 0, 0));
        Debug.Log("Town: " + mTown); //Right Now just for Error

        pos = new Vector2(-30, 15);
        mTown = Instantiate(town, pos, new Quaternion(0, 0, 0, 0));
        Debug.Log("Town: " + mTown); //Right Now just for Error

        pos = new Vector2(-30, -15);
        mTown = Instantiate(town, pos, new Quaternion(0, 0, 0, 0));
        Debug.Log("Town: " + mTown); //Right Now just for Error
    }
	

    // Odpalana funkcja w skrypcie LineGenerator z tad podczas tworzenia obiektu, zmiena promienia i większa płyność.
}
