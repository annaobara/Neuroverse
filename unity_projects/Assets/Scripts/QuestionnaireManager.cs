using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestionnaireManager : MonoBehaviour
{

    public CalibrationQ questionList;

    public int currentQuestion;

    public string questionText;

    public List<string> possibleAnswers;

    public List<Button> buttonList;

    public bool participantHasSelected;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentQuestion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void NextQuestion()
    {

        if (participantHasSelected)
        {
            // Prepare for next question data

            currentQuestion++;

            possibleAnswers.Clear();

            // Get the question that is asked
            questionText = questionList.questions[currentQuestion].question;

            // And the list of possible answers the participant can give
            possibleAnswers.AddRange(questionList.questions[currentQuestion].answerChoices);


            // Insert UI configuration code here

            // Generate list of buttons with each possible answer


            // Make the UI adjustments management here, making it just look kinda nice automatically



        }
        else {
            Debug.Log("you have not entered an answer yet!!");
        
        }

    }



    void Selected()
    {
        // When button gets clicked

        // Find Index of the button selected
        // var buttonIndex = buttonList.FindIndexOf(currentButton)
        // update participant choice integer in the questionTemplate for the question
        // questionList.questions[currentQuestion].participantsChoice = buttonIndex

    }


    void GenerateQuestionnaire()
    {





    }




}
