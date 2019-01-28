using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird_Controller : MonoBehaviour {
    Sprite myFruit;
    public static int killedamount=0;
    // the impulse limit for explosion
    float explosionImpulse = 20.0f;
    // get the main platform's transform
    Transform platformTransform;
    float maxDistance = 60f;

    // Use this for initialization
    void Start () {
        myFruit = Resources.Load<Sprite>("picture/exp");
        platformTransform = GameObject.Find("Platform").GetComponent<PlayerController>().transform;
    }
	
	// Update is called once per frame
	void Update () {
        //Collider.
        //Debug.Log("in 2 d");
        /*
        if (killedamount==5) {
            killedamount = 0;
            SceneManager.LoadScene("SampleScene");

        }*/
       // Debug.Log(Vector2.Distance(transform.position, platformTransform.position));
        if (Vector2.Distance(transform.position, platformTransform.position) > maxDistance) {
            Explosion();
            StartCoroutine(ShowAndHide(gameObject, 1.0f));
            killedamount += 1;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Force = Mass * Acceleration (assume self is not moving at all)
        Vector2 impulseVector = col.rigidbody.mass * (col.relativeVelocity - Vector2.zero);
        float impulse = impulseVector.magnitude;
       // Debug.Log("impulse is: " + impulse);
        if (impulse >= explosionImpulse) {
            Explosion();
            StartCoroutine(ShowAndHide(gameObject, 1.0f));
            killedamount += 1;
        }

        /*
        Debug.Log("OnCollisionEnter2D"+col.gameObject.tag);
        if (col.gameObject.tag == "wall")
        {   
            //col.gameObject.GetComponent<Rigidbody2D>();
            if (col.gameObject.GetComponent<Rigidbody2D>().angularVelocity > 2)
            {
                Debug.Log("we hit here" + col.gameObject.tag);
                Explosion();
                //  yield return new WaitForSeconds(100);
                StartCoroutine(ShowAndHide(gameObject, 1.0f));
                //  Destroy(this.gameObject);
            }
            //  Debug.Log("----------------------------");
        }
        */
    }

    /*
    void OnCollisionStay2D(Collision2D col) {
        // Force = Mass * Acceleration (assume self is not moving at all)
        Vector2 impulseVector = col.rigidbody.mass * (col.relativeVelocity - Vector2.zero);
        float impulse = impulseVector.magnitude;
        Debug.Log("impulse is: " + impulse);
        if (impulse >= explosionImpulse) {
            Explosion();
        }
    }
    */

        IEnumerator ShowAndHide(GameObject go, float delay)
    {
        //go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 3);

        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

    void Explosion() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = myFruit;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.gameObject.GetComponent<Rigidbody2D>().mass = 0.5f;
    }

}
