using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorScript : MonoBehaviour
{
    [SerializeField] private float turnCooldown = 10f;         // time for professor to turn around to student/player
    [SerializeField] private float turnDuration = 5f;         // time for professor to turn back away from student/player

    [SerializeField] private GameObject gameOverCanvas;

    private float timer;

    private bool isProfessorTurned = false;

    private bool isPhoneHidden;

    private int playerStrikes = 0;


    void Start()
    {
        // isPhoneHidden = 

        // set the timer to 0 for start
        timer = 0.0f;

        // start the coroutine to handle the cooldown action
        StartCoroutine(ProfessorTurnCooldown());
    }

    void Update()
    {
        // increment timer by time passed since last frame
        timer += Time.deltaTime;

        // keep updating the phone hidden bool, only if the professor is turned
        // if (isProfessorTurned)
            // isPhoneHidden = ;
    }

    private IEnumerator ProfessorTurnCooldown()
    {
        while (true)
        {
            // wait for cooldown
            yield return new WaitForSeconds(turnCooldown);

            ProfessorTurn();

            yield return new WaitForSeconds(turnDuration);

            ProfessorTurn();

            // reset the timer back to 0
            timer = 0.0f;
        }
    }

    private void ProfessorTurn()
    {
        if (!isProfessorTurned)
        {
            // make the professor turn with tranform movement

            // once the professor has fully turned, update bool variable
            isProfessorTurned = true;
        }

        else if (isProfessorTurned)
        {
            // make the professor turn back away with tranform movement

            // once the professor has fully turned back away, update bool variable
            isProfessorTurned = false;
        }
    }

    private void CheckStudentForPhone()
    {
        if (isProfessorTurned && !isPhoneHidden)
        {
            // apply one strike to the player's record
            playerStrikes++;

            // have professor say a line?

            // check for game over (may need to add buffer for professor to finish his line)
            CheckPlayerStrikes();
        }

    
    }

    private void CheckPlayerStrikes()
    {
        // if the player has 3 strikes, they're out! aka game over and display screens
        if (playerStrikes == 3)
        {
            // game over screen display
            print("Game Over");
            gameOverCanvas.SetActive(true);

            GameManager.instance.QuitGame();
        }

            
    }

}
