using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BloodCenter.Questions
{
    public static class QuestionaireFactory
    { 
        public static Questionaire GetHealthDeclarationQuestionaire()
        {
            var questions = new List<Question>
            {
                {
                    new Question("Have you had a tatto in the last 6 months ?", false, 6*30)
                },
                {
                    new Question("Have you had a new sexual partner in the last 3 months ?", false, 3*30)
                },
                {
                    new Question("If your had a new sexual partner, are they at a high risk for a blood disease ?", false, 12*30, "High risk meaning:")
                },
                {
                    new Question("Have you visited a high risk country ?" , false, 12*30, "High risk countries are: ")

                },
                {
                    new Question("Are you pregnant ?", false, 9*30, audienceForQuestion:AudienceForQuestion.Female)
                }
            };
            return new Questionaire(new List<Question>(questions));
        }

        public static Questionaire GetInterviewQuestionaire()
        {
            var question = new Question("Have you had a tatto recently", false, 30);
            var question1 = new Question("Are you pregnant", false, 270);
            return new Questionaire(new List<Question>() { question });
        }
    }
}
