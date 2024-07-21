using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHidePhone : MonoBehaviour
{
    private bool isPhoneHidden = false;
    private bool isMoving = false;    // Flag to check if the coroutine is running

    [SerializeField] private Transform phoneTransform;
    [SerializeField] private Vector3 hiddenPhoneLocation, unHiddenPhoneLocation;

    private float duration = 3f;
    
    
    private void HidePhone()
    {
        // move the transform of the phone to be lowered from view
        StartCoroutine(TranslateOverTime(phoneTransform, hiddenPhoneLocation, duration));
    }

    private void UnhidePhone()
    {
        // move the transform of the phone to be back in view
        StartCoroutine(TranslateOverTime(phoneTransform, unHiddenPhoneLocation, duration));
    }

    private void Update() {
        if (!isMoving)
        {
            if (!isPhoneHidden && Input.GetKey(KeyCode.H))
                HidePhone();
            else if (isPhoneHidden && Input.GetKey(KeyCode.H))
                UnhidePhone();
        }
    }

    private IEnumerator TranslateOverTime(Transform target, Vector3 endPos, float time)
    {
        isMoving = true;
        Vector3 startPos = target.position;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / time);

            // Easing in and out
            t = Mathf.SmoothStep(0f, 1f, t);

            target.position = Vector3.Lerp(startPos, endPos, t);

            yield return null;
        }

        // Ensure the final position is set
        target.position = endPos;

        // once phone is completely back to position, negate the bool
        isPhoneHidden = !isPhoneHidden;

        isMoving = false;
    }

    public bool GetIsPhoneHidden() { return isPhoneHidden; }

}
