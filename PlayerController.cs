using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    static int te = 1;

    // Flags
    bool cannonReady;
    bool gameEnd;
    bool gameWin;

    // Cannon
    GameObject cannon;
    Vector3 cannonPosition = new Vector3(0,0,0);

    // Bullet
    GameObject bullet;
    Rigidbody2D bulletRigidbody;
    CircleCollider2D bulletCollider;
    float power;
    float force = 200.0f;
    float maxDistance = 80f;
    int bulletCount;
    Vector2 prevPosition;

    // UI
    string playerName;
    GameObject playerNameText;
    GameObject bulletCountText;
    GameObject finalMessage;
    GameObject cannonStatus;
    GameObject birdsLeft;
    GameObject windSpeedText;

    // Birds
    int birdsCount;

    // Wind Effects
    float windSpeed;
    bool windReset;

    // Use this for initialization
    void Start () {

        // resume time in case of termination
        Time.timeScale = 1;

        // initialize
        power = 0;
        cannonReady = true;
        gameEnd = false;
        gameWin = false;
        windReset = false;
        prevPosition = new Vector2(0,0);
        birdsCount = GameObject.FindGameObjectsWithTag("Birds").Length;

        // cannon setup
        cannon = Resources.Load("Prefab/Cannon") as GameObject;
        cannon = Instantiate(cannon, transform);
        cannon.AddComponent<CannonController>();

        // UI setup
        finalMessage = GameObject.Find("Final Message");
        playerNameText = GameObject.Find("Player Name");
        playerName = PlayerPrefs.GetString("PlayerName");
        bulletCountText = GameObject.Find("Bullet Count");
        bulletCount = int.Parse(PlayerPrefs.GetString("BulletCount"));
        cannonStatus = GameObject.Find("Cannon Status");
        birdsLeft = GameObject.Find("Birds Left");
        windSpeedText = GameObject.Find("Wind Speed");

        // generate new level
        GameObject vwall;
        //vwall = Resources.Load("Prefab/fullBuilding_3") as GameObject;

        if (te == 1) {
            vwall = Resources.Load("Prefab/fullBuilding_3") as GameObject;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(vwall, new Vector3(11.5635f, -6f, 0), spawnRotation);
            te = 2;
        }
        else {
            vwall = Resources.Load("Prefab/building2") as GameObject;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(vwall, new Vector3(11.5635f, 2.799807f, 0), spawnRotation);
            te = 1;
        }

    }
	
	// Update is called once per frame
	void Update () {

        // Check if player want to quit game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        // Check if player want to quit to menu
        if (Input.GetKeyDown(KeyCode.Q)) {
            SceneManager.LoadScene("starting_scene");
        }

        // Count birds left & update UI
        birdsCount = GameObject.FindGameObjectsWithTag("Birds").Length;
        birdsLeft.GetComponent<Text>().text = "Birds Left: " + birdsCount;

        // If no birds left, player wins the game
        if (birdsCount == 0) {
            gameEnd = true;
            gameWin = true;
        }

        // Check Game Conditions
        if (gameEnd) {
            if (gameWin) {
                // Display victory message
                finalMessage.GetComponent<Text>().text =
                    "Victory! You successfully killed all the birds\n" +
                    "Press 'R' to restart new level\n" +
                    "Press 'Q' to quit to menu";
                if (Input.GetKeyDown(KeyCode.C)) {
                    SceneManager.LoadScene("SampleScene");
                }
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
            return;
        }

        // If cannon is available and game is not ended
        if (cannonReady && !gameEnd) {
            // Reset wind speed if cannon just back to ready
            if (windReset == false) {
                windSpeed = Random.Range(-20.0f, 20.0f);
                windReset = true;
            }
            // if all bullets are used
            if (bulletCount <= 0) {
                gameEnd = true;
                // Display game loss message
                finalMessage.GetComponent<Text>().text = 
                    "You failed to kill all the birds\n" + 
                    "Press 'R' to restart current level\n" + 
                    "Press 'Q' to quit to menu";
            }
            else {
                // If user press space to project bullet
                if (Input.GetKeyDown(KeyCode.Space)) {
                    power = 50.0f;
                }
                if (Input.GetKeyUp(KeyCode.Space) && bulletCount > 0) {
                    Generate();
                    bulletCount--;
                    power = 0;
                }
                if (Input.GetKey(KeyCode.Space)) {
                    power += force * Time.deltaTime;
                    if (power >= 200.0f) {
                        power = 200.0f;
                    }
                }
            }
        }
        else {
            // cannon is ready again if:
            // 1. it stops moving
            // 2. it falls off the platform
            if ( bulletRigidbody.velocity.SqrMagnitude() < 0.1f && Mathf.Abs(bulletRigidbody.angularVelocity) < 20f 
                || Vector2.Distance(bullet.transform.position, transform.position) > maxDistance ) {
                cannonReady = true;
            }
        }

        // Update UI
        bulletCountText.GetComponent<Text>().text = "Bullet Count: " + bulletCount;
        playerNameText.GetComponent<Text>().text = "Player Name: " + playerName;
        cannonStatus.GetComponent<Text>().text = "Cannon Status: " + (cannonReady ? "Ready" : "Waiting");
        windSpeedText.GetComponent<Text>().text = "Wind Speed: " + windSpeed;

    }

    // Method to generate and shoot new bullet
    void Generate () {
        cannonReady = false;
        bullet = Resources.Load("Prefab/apple") as GameObject;
        bullet = Instantiate(bullet, transform);
        bullet.AddComponent<BulletController>();
        bullet.GetComponent<BulletController>().SetPower(power);
 
        // Add rigidbody to bullet
        bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.mass = 10;

        // Add collider to bullet
        bulletCollider = bullet.GetComponent<CircleCollider2D>();

        // setup projecting angle
        float cannonAngle = cannon.transform.localEulerAngles.z;
        Quaternion cannonRotation = Quaternion.AngleAxis(cannonAngle, Vector3.forward);
        // Noitce! Put quaternion before vector3 !
        Vector3 cannonVector = cannonRotation * Vector3.right;

        // Add foce based on computed angle
        bulletRigidbody.AddForce(cannonVector * power, ForceMode2D.Impulse);

        // Add wind effects
        bulletRigidbody.AddForce(Vector2.right * windSpeed * 100, ForceMode2D.Force);
        windReset = false;
    }

}
