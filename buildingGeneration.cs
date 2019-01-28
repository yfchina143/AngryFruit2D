using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingGeneration : MonoBehaviour {
    static int te = 1;
	// Use this for initialization
	void Start () {
        // float temp=Random.Range(0,4);
        //Debug.Log("temp"+ temp);
        // baselevel();
        GameObject vwall;
        //vwall = Resources.Load("Prefab/fullBuilding_3") as GameObject;
        
        if (te==1)
        {
            vwall = Resources.Load("Prefab/fullBuilding_33") as GameObject;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(vwall, new Vector3(11.5635f, -6f, 0), spawnRotation);
            te = 2;
        }
        else {
            vwall = Resources.Load("Prefab/building22") as GameObject;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(vwall, new Vector3(11.5635f, 2.799807f, 0), spawnRotation);
            te = 1;
        }
     
    }
	


	// Update is called once per frame
	void Update () {
		
	}

    public void baselevel() {
        int levelamount = Random.Range(1, 4);
        int levelSize = levelamount+2;
        float lengthX = this.transform.position.x;
        float widthY= this.transform.position.y;
        for (int i=0;i<levelamount;i++) {

            if (i==0) {
                // lengthX = lengthX * 40;

                genLevel(lengthX, widthY, levelSize);

            } else if(i==1){
                
            } else if(i==2){
               
            }
            else {
                
            }

            levelSize = Random.Range(2, levelSize);
        }
        // Debug.Log("hit here");
    }


    public void genLevel(float lengthX, float widthY, int levelWallAmount) {
        GameObject vwall = Resources.Load("Prefab/Vwall") as GameObject;
        float sx = Random.Range(0.20f, 0.20f);
        float sy = 0.1f;
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        float lengthx = lengthX - 30;
        float widthy = widthY + 5.5f;
        for (int i=0;i< levelWallAmount;i++) {
            lengthx= Random.Range(lengthx-2, lengthx+5);
            //widthy= Random.Range(lengthx, 0.30f);
            vwall.transform.localScale = new Vector3(sx , sy, 0);

            Instantiate(vwall, new Vector3(lengthx, widthy, 0), spawnRotation);
          //  vwall.collider2D.b
        }
       
       
    }
}
