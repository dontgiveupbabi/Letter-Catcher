using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSpawner : MonoBehaviour
{
    TextPrinter textPrinterScript;
    [SerializeField] private GameObject[] letterPositions;
    [SerializeField] GameObject letter;

    //public  GameObject up1Prefab;

    private GameObject up;
    private GameObject down;
   
    // Start is called before the first frame update
    void Start()
    {
        
       /* up1Prefab =  Resources.Load(textPrinterScript.levelTask[textPrinterScript.letterIndex].ToString() ,typeof(GameObject)) as GameObject;
        if (up1Prefab != null)
        {
            Instantiate(up1Prefab,letterPositions[0].transform.position,Quaternion.identity,letterPositions[0].transform);
        }*/
       
       
       textPrinterScript = GameObject.Find("Player").GetComponent<TextPrinter>();
       
       down = Instantiate(letter, letterPositions[1].transform.position,Quaternion.identity,letterPositions[1].transform) as GameObject;
       down.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = textPrinterScript.levelTask[textPrinterScript.letterIndex].ToString();
       down.GetComponent<Letter>().whichLetter = textPrinterScript.levelTask[textPrinterScript.letterIndex].ToString();
       
       up = Instantiate(letter,letterPositions[0].transform.position,Quaternion.identity,letterPositions[0].transform) as GameObject;
       up.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = textPrinterScript.levelTask[textPrinterScript.letterIndex + 1].ToString();
       up.GetComponent<Letter>().whichLetter = textPrinterScript.levelTask[textPrinterScript.letterIndex+1].ToString();
       //down = Instantiate(Resources.Load(textPrinterScript.levelTask[textPrinterScript.letterIndex].ToString()), letterPositions[1].transform.position,Quaternion.identity,letterPositions[1].transform) as GameObject;
       //up = Instantiate(Resources.Load(textPrinterScript.levelTask[textPrinterScript.letterIndex+1].ToString()), letterPositions[0].transform.position,Quaternion.identity,letterPositions[0].transform) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
