using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordSelector : MonoBehaviour
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
