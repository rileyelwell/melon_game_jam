using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUpdater : MonoBehaviour
{
    private string currentTextFull;


    private void UpdateTextDisplay()
    {
        // move text to correct order (essentially up)

        // check if the text is still in the bounds of the phone, display accordingly

        // animations?
    }

    private void ComputerSendText()
    {
        // send text from computer to player's phone (display new dialogue in correct order)

        // animations?
    }

    void PlayerSendText()
    {
        // convert the current selected words into a full text string 
        // currentTextFull = 

        // move this string to display as a "text" above the typing area

        // reset the typing to be either null or contain the next set of words

        // animations?
    }
}
