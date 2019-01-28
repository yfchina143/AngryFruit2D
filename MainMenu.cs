using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
    int amount;
    static string name1="user", size="8";
    public void play() {
        SceneManager.LoadScene("SampleScene");
        //currentText = gameObject.Find("Canvas/Panal/Input Field").GetComponent(UI.InputField).text;
        // userNameInputText = this.transform.Find("name/Input Field").GetComponent<UI.InputField>();
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        Transform textTr = canvasObject.transform.Find("name");
        InputField text = textTr.GetComponent<InputField>();
        Transform textTr1 = canvasObject.transform.Find("appleSize");
        InputField text1 = textTr1.GetComponent<InputField>();
       // Debug.Log(text.text);
        //Debug.Log(text1.text);
        name1 = text.text;
        size = text1.text;

        PlayerPrefs.SetString("PlayerName", name1);
        PlayerPrefs.SetString("BulletCount", size);

    }

    public static string getName() {
        return name1;
    }
    public static string getSize()
    {
        return size;
    }
}
