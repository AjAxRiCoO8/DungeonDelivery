using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayer : MonoBehaviour {

    public GameObject player;
    public Vector2 offset; 

	// Update is called once per frame
	void Update ()
    {
        GetComponent<Transform>().position = new Vector2( player.transform.position.x + offset.x, player.transform.position.y + offset.y);
    }
}
