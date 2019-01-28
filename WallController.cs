using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour {
    //Sprite myFruit;
    // Use this for initialization
    private int health;
    float explosionImpulse = 20.0f;
    //float explosionImpulse = 20.0f;
    void Start () {
        //myFruit= Resources.Load<Sprite>("picture/exp");
        //myFruit.
        health = 0;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }*/
      //  Time.timeScale = 0.3f;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float sx = this.gameObject.transform.localScale.x;
        float sy = this.gameObject.transform.localScale.y;
        float x = this.gameObject.transform.position.x;
        float y = this.gameObject.transform.position.y;
        // Debug.Log("printing:"+sx+"-"+sy);
        Vector2 impulseVector = col.rigidbody.mass * (col.relativeVelocity - Vector2.zero);
        float impulse = impulseVector.magnitude;
        if (col.gameObject.tag == "appleBullet"&& impulse >= explosionImpulse)
        {
            if (health != 0)
            {
                health--;
            }
            else {
                bool checkforX;
                if (sx > sy) {
                    checkforX = true;
                    if (sx>0.05f)
                    {
                        GameObject cannon,canon1;
                        if (this.gameObject.tag == "Vwall")
                        {
                            cannon = Resources.Load("Prefab/Vwall") as GameObject;
                            canon1 = Resources.Load("Prefab/Vwall") as GameObject;
                            Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
                            cannon.transform.localScale = new Vector3(sx / 2, sy, 0);
                            canon1.transform.localScale = new Vector3(sx / 2, sy, 0);
                            // float fsy = sy;
                            //  x = x - sx / 2;
                            float temp = y;
                            float sumconst = sx * 4.980175f;
                            // Debug.Log("temp:" + temp + "" + " sy:"+sy+ " sx:"+sx);
                            // Debug.Log("sum constant is:" + sumconst);
                            temp = y - sumconst;                        //  Debug.Log("y1:"+temp+""+" x1:"+x );
                            Instantiate(cannon, new Vector3(x, temp, 0), spawnRotation);
                            // x = x + sx / 2;
                            y = y + sumconst;
                            //  Debug.Log("y2:" + y + "" + " x2:" + x);
                            Instantiate(canon1, new Vector3(x, y, 0), spawnRotation);
                            // Debug.Log("-------------------------");
                            this.gameObject.SetActive(false);
                            // Debug.Log("-------------------------");
                            //   Debug.Log("1hit herev");
                        }
                        else {
                           
                            cannon = Resources.Load("Prefab/Hwall") as GameObject;
                            canon1 = Resources.Load("Prefab/Hwall") as GameObject;
                            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
                            cannon.transform.localScale = new Vector3(sx/2, sy , 0);
                            canon1.transform.localScale = new Vector3(sx/2, sy , 0);
                            // float fsy = sy;
                            //  x = x - sx / 2;
                            float temp = y;
                            float sumconst = sx * 4.90175f;
                            // Debug.Log("temp:" + temp + "" + " sy:"+sy+ " sx:"+sx);
                            // Debug.Log("sum constant is:" + sumconst);
                            temp = x - sumconst;
                            //  Debug.Log("y1:"+temp+""+" x1:"+x );
                            Instantiate(cannon, new Vector3(temp, y, 0), spawnRotation);
                            // x = x + sx / 2;
                            x = x + sumconst;
                            //  Debug.Log("y2:" + y + "" + " x2:" + x);
                            Instantiate(canon1, new Vector3(x, y, 0), spawnRotation);
                            this.gameObject.SetActive(false);
                            // Debug.Log("1hit hereH");
                        }

                       
                    }
                    else
                    {
                        GameObject cannon = Resources.Load("Prefab/smallWall") as GameObject;
                      

                      
                        Instantiate(cannon, new Vector3(x, y, 0), Quaternion.identity);
                        this.gameObject.SetActive(false);
                    }
                }
                else {
                    checkforX = false;
                    if (sy > 0.05f)
                    {
                        GameObject cannon, canon1;
                        if (this.gameObject.tag == "Hwall")
                        {
                           // cannon = Resources.Load("Prefab/Hwall") as GameObject;
                           
                            cannon = Resources.Load("Prefab/Hwall") as GameObject;
                            canon1 = Resources.Load("Prefab/Hwall") as GameObject;
                          
                          //  Debug.Log("2hit hereH");
                        }
                        else
                        {
                            cannon = Resources.Load("Prefab/Vwall") as GameObject;
                            canon1 = Resources.Load("Prefab/Vwall") as GameObject;
                    
                         //   Debug.Log("2hit hereV");
                        }
                        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
                        cannon.transform.localScale = new Vector3(sx, sy / 2, 0);
                        canon1.transform.localScale = new Vector3(sx, sy / 2, 0);
                        // float fsy = sy;
                        //  x = x - sx / 2;
                        float temp = y;
                        float sumconst = sy * 4.980175f;
                        // Debug.Log("temp:" + temp + "" + " sy:"+sy+ " sx:"+sx);
                        // Debug.Log("sum constant is:" + sumconst);
                        temp = x - sumconst;
                        //  Debug.Log("y1:"+temp+""+" x1:"+x );
                        Instantiate(cannon, new Vector3(temp, y, 0), spawnRotation);
                        // x = x + sx / 2;
                        x = x+ sumconst;
                        //  Debug.Log("y2:" + y + "" + " x2:" + x);
                        Instantiate(canon1, new Vector3(x, y, 0), spawnRotation);
                        // Debug.Log("1hit hereH");
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        GameObject cannon = Resources.Load("Prefab/smallWall") as GameObject;
                        
                   
                        Instantiate(cannon, new Vector3(x, y, 0), Quaternion.identity);
                        this.gameObject.SetActive(false);
                    }
                }
                
            }
        }
    }

  
}
