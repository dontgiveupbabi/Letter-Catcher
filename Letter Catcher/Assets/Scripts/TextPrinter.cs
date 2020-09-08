using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.U2D;
using UnityEngine;

public class TextPrinter : MonoBehaviour
{
    [SerializeField] public string levelTask;
    public List<char> levelTaskList;
    public string textWritten;
    private List<char> textWrittenList;
    public string leftText;
    private List<char> leftTextList;
    public int letterIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var letter in levelTask)
        {
            levelTaskList.Add(letter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Letter"))
        {
            Debug.Log(other.transform.gameObject.GetComponent<Letter>().whichLetter);
            AddToWrittenText(other.transform.gameObject.GetComponent<Letter>().whichLetter);
            Destroy(other.transform.gameObject);
        }
    }

    private void AddToWrittenText(string letter)
    {
        if (letter == "Space")
        {
            textWritten = textWritten + " ";
            letterIndex++;
        }
        else
        {
            textWritten = textWritten + letter;
            letterIndex++;
        }
        
    }

}
