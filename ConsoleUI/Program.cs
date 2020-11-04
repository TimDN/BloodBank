using BloodCenter;
using BloodCenter.Blood;
using BloodCenter.Donation;
using BloodCenter.Employees;
using BloodCenter.Persons;
using BloodCenter.Questions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        private static BloodBank bloodBank = new BloodBank();

        private static bool ShouldQuestionBeShown(Donor donor, Question question)
        {
            var result = false;
            if (question.AudienceForQuestion == AudienceForQuestion.Both)
            {
                result = true;
            }
            else if (!donor.SexIsMale && question.AudienceForQuestion == AudienceForQuestion.Female)
            {
                result = true;
            }
            else if (donor.SexIsMale && question.AudienceForQuestion == AudienceForQuestion.Male)
            {
                result = true;
            }
            return result;
        }


        private static Questionaire AnswerQuestionaire(Donor donor)
        {
            var questionaire = QuestionaireFactory.GetHealthDeclarationQuestionaire();
            foreach (var question in questionaire.Questions)
            {
                if(ShouldQuestionBeShown(donor, question))
                {
                    ShowQuestion(question);
                }
            }
            questionaire.EvaluateQuestionaire();
            return questionaire;
        }

        private static void ShowQuestion(Question question)
        {
            Console.WriteLine(question.Query);
            if (!string.IsNullOrEmpty(question.Description))
            {
                Console.WriteLine(question.Description);
            }
            var answer = bool.Parse(Console.ReadLine());
            question.Answer = answer;
        }

        private static void FillInMedicine(HealthDeclaration healthDeclaration)
        {

            while (true)
            {

            }
        }

        private static void FillHealthDeclaration()
        {
            var donor = new Donor(Guid.NewGuid(), false, BloodType.ABn);
            var bloodDonation = bloodBank.StartBloodDonation(donor);
            var questionaire = AnswerQuestionaire(donor);
            var healthDeclaration = new HealthDeclaration(questionaire);
            bloodDonation.AddHealthDeclaration(healthDeclaration);
            if (questionaire.IsBlocked)
            {
                Console.WriteLine("You can not give blood:");
                Console.WriteLine(questionaire.BlockReason);
                bloodBank.AbortDonation(bloodDonation);
                throw new Exception();
            }

        }

        private static void DrawBlood()
        {
            var nurse = new Nurse();
            var donors = bloodBank.ActiveDonors();
            var donor = donors.First();
            var bloodDonation = bloodBank.CheckoutBloodDonation(donor);
            bloodDonation.HealthDeclaration.Approve(nurse);
            bloodDonation.Block(nurse, "Not enough weight", 50);
            bloodDonation.EndDonation();
        }

        private static void Main(string[] args)
        {
            FillHealthDeclaration();
            DrawBlood();
        }
    }
}