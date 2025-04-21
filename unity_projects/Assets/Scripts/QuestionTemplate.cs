using UnityEngine;

[CreateAssetMenu(fileName = "QuestionTemplate", menuName = "Scriptable Objects/QuestionTemplate")]
public class QuestionTemplate : ScriptableObject
{
    public string question;

    public string[] answerChoices;

    public int participantsChoice;

    // ParticipantsChoice is basically how the questions are linked up with parameter control
    // It's pretty "manually" connected atm, as I haven't thought of an easy automation technique yet lol

    // Basically when a participant answers a question, their choice (as an integer, representing the choice object's index in the answerChoices list)
    // gets logged in the corresponding question, and that question is then connected to a specific parameter in the overall "management" script (hasn't been written yet)







    // For later: make it print out every answer the participant has selected as a .csv file or something in that line, so we have the data easily


}
