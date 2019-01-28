using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallWall : MonoBehaviour {
    private int health;
    // Use this for initialization
    void Start () {
        health = 1;
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "appleBullet")
        {
            if (health != 0)
            {
                health--;
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
