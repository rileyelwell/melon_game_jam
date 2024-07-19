using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneInteractionsScript : MonoBehaviour
{
    [SerializeField] private TMP_Text wordDisplay;
    [SerializeField] private Button leftArrowButton, rightArrowButton;

    private string[] words = { "Option 1", "Option 2", "Option 3", "Option 4" };
    private int currentIndex = 0;

    void Start()
    {
        // assign the button click events
        leftArrowButton.onClick.AddListener(FlipLeft);
        rightArrowButton.onClick.AddListener(FlipRight);

        // Display the first word
        UpdateWordDisplay();
    }

    void SendText()
    {
        // convert the current selected words into a full text string 
        

        // move this string to display as a "text" above the typing area

        // reset the typing to be either null or contain the next set of words
    }

    void FlipLeft()
    {
        // update index
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = words.Length - 1; 

        // update displayed word
        UpdateWordDisplay();
    }

    void FlipRight()
    {
        // update index
        currentIndex++;
        if (currentIndex >= words.Length)
            currentIndex = 0;

        // update displayed word
        UpdateWordDisplay();
    }

    void UpdateWordDisplay()
    {
        wordDisplay.text = words[currentIndex];
    }

    string GetCurrentWord() { return wordDisplay.text; }

    
}
