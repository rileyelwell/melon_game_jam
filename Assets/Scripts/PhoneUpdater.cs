using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUpdater : MonoBehaviour
{
    private string currentTextFull;

    [SerializeField] private GameObject choice1, choice2;
    [SerializeField] private Button sendTextButton;
    [SerializeField] private Canvas choicesCanvas;
    [SerializeField] private string[] responseDictKeys;
    private string[] responses;

    private WordSelector selectorScript1, selectorScript2;
    private int currentDictKeyIndex = 0;
    private int currentLikenessPoints = 0;


    private void Start() {
        if (ScriptDataDictionary.scriptDict.TryGetValue(responseDictKeys[currentDictKeyIndex], out string[] output))
        {
            // Use the array of strings
            responses = output;
        }

        selectorScript1 = choice1.GetComponent<WordSelector>();
        selectorScript2 = choice2.GetComponent<WordSelector>();

        sendTextButton.onClick.AddListener(PlayerSendText);
    }

    private void UpdatePhoneTextDisplay()
    {
        // move text to correct order (essentially up)

        // check if the text is still in the bounds of the phone, display accordingly

        // animations?
    }

    private void DisplayResponseText()
    {
        // determine correct response based on the answer given
        DetermineTextResponse();

        // send text from computer to player's phone (display new dialogue in correct order)
        // print(responses[0]);

        // update responses for next loop
        currentDictKeyIndex++;
        if (ScriptDataDictionary.scriptDict.TryGetValue(responseDictKeys[currentDictKeyIndex], out string[] output))
        {
            // Use the array of strings
            responses = output;
        }
    }

    void PlayerSendText()
    {
        // convert the current selected words into a full text string 
        currentTextFull = selectorScript1.GetCurrentPhrase() + " " + selectorScript2.GetCurrentPhrase();
        print(currentTextFull);

        // move this string to display as a "text" above the typing area
        UpdatePhoneTextDisplay();

        // reset the typing to be either null or contain the next set of words
        selectorScript1.ResetPhrases();
        selectorScript2.ResetPhrases();
        choicesCanvas.gameObject.SetActive(false);

        // start the ienumerator function for delay until "Alex" responds
        StartCoroutine(GenerateResponseText());
    }

    private IEnumerator GenerateResponseText()
    {
        // wait for cooldown
        yield return new WaitForSeconds(1f);

        // display the response text on the phone display
        DisplayResponseText();

        yield return new WaitForSeconds(1f);

        // generate new set of selections for player to choose from
        selectorScript1.UpdatePhraseDisplay();
        selectorScript2.UpdatePhraseDisplay();
        choicesCanvas.gameObject.SetActive(true);
    }

    private void DetermineTextResponse()
    {
        switch (currentDictKeyIndex)
        {
            case 0:
                print(responses[0]);
                break;
            case 1:
                if (currentTextFull.ToLower().Contains("call"))
                    print(responses[0]);
                else if (currentTextFull.ToLower().Contains("bored"))
                    print(responses[1]);
                else if (currentTextFull.ToLower().Contains("astral"))
                    print(responses[2]);
                break;
            case 2:
                if (currentTextFull.ToLower().Contains("remember")) {
                    currentLikenessPoints--;
                    print(responses[0]);
                }
                else if (currentTextFull.ToLower().Contains("resuscitation"))
                    print(responses[1]);
                else if (currentTextFull.ToLower().Contains("rescue")) {
                    currentLikenessPoints++;
                    print(responses[2]);
                }
                    
                break;
            case 3: 
                if (currentTextFull.ToLower().Contains("focus")){
                    currentLikenessPoints--;
                    print(responses[0]);
                }
                    
                else if (currentTextFull.ToLower().Contains("help")) {
                    currentLikenessPoints++;
                    print(responses[1]);
                }
                else if (currentTextFull.ToLower().Contains("smecture") && currentTextFull.ToLower().Contains("beam")) {
                    print(responses[3]);
                }
                else {
                    currentLikenessPoints++;
                    print(responses[2]);
                }
                break;
            case 4://
                if (currentTextFull.ToLower().Contains("stellar") && currentTextFull.ToLower().Contains("shrimp")){
                    currentLikenessPoints++;
                    print(responses[0]);
                }
                    
                else if (currentTextFull.ToLower().Contains("horribly") && currentTextFull.ToLower().Contains("shrimp")) {
                    currentLikenessPoints++;
                    print(responses[1]);
                }
                else if (currentTextFull.ToLower().Contains("headache")) {
                    print(responses[2]);
                }   
                if (currentTextFull.ToLower().Contains("fly over"))
                    currentLikenessPoints--;
                    print(responses[3]);

                // second part of case 4
                if (currentLikenessPoints < 0)
                    print(responses[4]);
                else if (currentLikenessPoints >= 0 && currentLikenessPoints < 2)
                    print(responses[5]);
                else if (currentLikenessPoints >= 2)
                    print(responses[6]);
                break;
            case 5:
                print(responses[0]);
                break;
            case 6:
                if (currentTextFull.ToLower().Contains("i took you") && currentTextFull.ToLower().Contains("movies")){
                    currentLikenessPoints--;
                    print(responses[0]);
                }
                    
                else if (currentTextFull.ToLower().Contains("you wanted") && currentTextFull.ToLower().Contains("movies")){
                    currentLikenessPoints--;
                    print(responses[1]);
                }
                    
                else if (currentTextFull.ToLower().Contains("i took you") && currentTextFull.ToLower().Contains("bar")){
                    currentLikenessPoints++;
                    print(responses[2]);
                }
                    
                else if (currentTextFull.ToLower().Contains("you wanted") && currentTextFull.ToLower().Contains("bar")){
                    currentLikenessPoints++;
                    print(responses[3]);
                }
                    
                else if (currentTextFull.ToLower().Contains("i took you") && currentTextFull.ToLower().Contains("paris")){
                    print(responses[4]);
                }  
                else if (currentTextFull.ToLower().Contains("you wanted") && currentTextFull.ToLower().Contains("paris")){
                    print(responses[5]);
                }
                break;
            case 7:
                if (currentTextFull.ToLower().Contains("impression"))
                    print(responses[0]);
                else if (currentTextFull.ToLower().Contains("date"))
                    print(responses[1]);
                else if (currentTextFull.ToLower().Contains("going into it"))
                    print(responses[2]);
                print(responses[responses.Length-1]);
                break;
            case 8:
                if (currentTextFull.ToLower().Contains("gin") && currentTextFull.ToLower().Contains("soda"))
                    print(responses[0]);
                else if (currentTextFull.ToLower().Contains("gin") && currentTextFull.ToLower().Contains("fireball"))
                    print(responses[1]);
                else if (currentTextFull.ToLower().Contains("tequila") && currentTextFull.ToLower().Contains("fireball"))
                    print(responses[2]);
                else if (currentTextFull.ToLower().Contains("tequila") && currentTextFull.ToLower().Contains("soda"))
                    print(responses[3]);
                else if (currentTextFull.ToLower().Contains("apple") && currentTextFull.ToLower().Contains("soda"))
                    print(responses[4]);
                else if (currentTextFull.ToLower().Contains("apple") && currentTextFull.ToLower().Contains("fireball"))
                    print(responses[5]);
                else if (currentTextFull.ToLower().Contains("apple") && currentTextFull.ToLower().Contains("umbrella"))
                    print(responses[6]);
                else
                    print(responses[7]);
                print(responses[responses.Length-1]);
                break;
            case 9:
                if (currentTextFull.ToLower().Contains("laughed") && currentTextFull.ToLower().Contains("party"))
                    print(responses[0]);
                else if (currentTextFull.ToLower().Contains("laughed") && currentTextFull.ToLower().Contains("school"))
                    print(responses[1]);
                else if (currentTextFull.ToLower().Contains("tensed") && currentTextFull.ToLower().Contains("party"))
                    print(responses[2]);
                else if (currentTextFull.ToLower().Contains("tensed") && currentTextFull.ToLower().Contains("school"))
                    print(responses[3]);
                print(responses[responses.Length-1]);
                break;
            case 10:
                if (currentTextFull.ToLower().Contains("didn't mean")) {
                    currentLikenessPoints++;
                    print(responses[0]);
                }
                    
                else if (currentTextFull.ToLower().Contains("my business")){
                    print(responses[1]);
                }
                    
                else if (currentTextFull.ToLower().Contains("old habits")){
                    currentLikenessPoints--;
                    print(responses[2]);
                }
                print(responses[responses.Length-1]);
                break;
            case 11:
                if (currentTextFull.ToLower().Contains("another")) {
                    print(responses[0]);
                }   
                    
                else if (currentTextFull.ToLower().Contains("mom")){
                    currentLikenessPoints++;
                    print(responses[1]);
                }
                    
                else if (currentTextFull.ToLower().Contains("friend")){
                    currentLikenessPoints--;
                    print(responses[2]);
                }
                    
                // second part of case 11
                if (currentLikenessPoints < 0)
                    print(responses[5]);
                else if (currentLikenessPoints >= 0 && currentLikenessPoints < 2)
                    print(responses[4]);
                else if (currentLikenessPoints >= 2)
                    print(responses[3]);
                break;
            
        }

    }
}
