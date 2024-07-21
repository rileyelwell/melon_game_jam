using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WordSelector : MonoBehaviour
{
    [SerializeField] private TMP_Text wordDisplay;
    [SerializeField] private Button leftArrowButton, rightArrowButton;
    [SerializeField] private string[] dictKeys;
    private int currentDictKey = 0;

    private string[] words;
    private int currentIndex = 0;

    void Start()
    {
        if (ScriptDataDictionary.scriptDict.TryGetValue(dictKeys[currentDictKey], out string[] output))
        {
            // Use the array of strings
            words = output;
        }

        // assign the button click events
        leftArrowButton.onClick.AddListener(FlipLeft);
        rightArrowButton.onClick.AddListener(FlipRight);

        // Display the first word
        UpdatePhraseDisplay();
    }

    public void ResetPhrases()
    {
        // reset the typing to be either null or contain the next set of words
        wordDisplay.text = "";
        currentIndex = 0;

        // update list of words to be next set of choices
        currentDictKey++;
        if (ScriptDataDictionary.scriptDict.TryGetValue(dictKeys[currentDictKey], out string[] output))
        {
            // Use the array of strings
            // Debug.Log("Words for Choices1: " + string.Join(", ", output));
            words = output;
        }

        // choicesCanvas.gameObject.SetActive(false);
    }

    void FlipLeft()
    {
        // update index
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = words.Length - 1; 

        // update displayed word
        UpdatePhraseDisplay();
    }

    void FlipRight()
    {
        // update index
        currentIndex++;
        if (currentIndex >= words.Length)
            currentIndex = 0;

        // update displayed word
        UpdatePhraseDisplay();
    }

    public void UpdatePhraseDisplay()
    {
        wordDisplay.text = words[currentIndex];
    }

    public string GetCurrentPhrase() { return wordDisplay.text; }

    
}
