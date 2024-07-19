using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHidePhone : MonoBehaviour
{
    private bool isPhoneHidden = false;
    
    private void HidePhone()
    {
        // move the camera to adjust view of player and phone

        // move the transform of the phone to be lowered from view

        // once phone is completely lowered to given position, set a boolean to be "hidden"
        isPhoneHidden = true;
    }

    private void UnhidePhone()
    {
        // move the camera to adjust view of player and phone

        // move the transform of the phone to be back in view

        // once phone is completely back to normal position, set a boolean to be "unhidden"
        isPhoneHidden = false;
    }

    private void Update() {
        if (!isPhoneHidden && Input.GetKey(KeyCode.Space))
            HidePhone();
        else if (isPhoneHidden && Input.GetKey(KeyCode.Space))
            UnhidePhone();
    }

    public bool GetIsPhoneHidden() { return isPhoneHidden; }

}
