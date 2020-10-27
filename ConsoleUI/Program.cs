using BloodCenter;
using BloodCenter.Blood;
using BloodCenter.Donation;
using BloodCenter.Employees;
using BloodCenter.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        private static BloodBank bloodBank = new BloodBank();

        private static void FillHealthDeclaration()
        {
            var donor = new Donor(0, true, BloodType.ABn);
            var bloodDonation = bloodBank.StartBloodDonation(donor);
            var questionarie = new Questionaire(new List<Question>());
            var healthDeclaration = new HealthDeclaration(questionarie);
            questionarie.EvaluateQuestionaire();
            bloodDonation.AddHealthDeclaration(healthDeclaration);
        }

        private static void DrawBlood()
        {
            var nurse = new Nurse();
            var donors = bloodBank.ActiveDonors();
            var donor = donors.First();
            var bloodDonationBuilder = bloodBank.CheckoutBloodDonation(nurse, donor);
            bloodDonationBuilder.AddHeamaglobin(150);
            var bloodDonation = bloodDonationBuilder.StartBloodDonation();
            bloodDonation.HealthDeclaration.Approve();
            bloodDonation.Block("Not enough weight", 50);
            bloodDonation.EndDonation();
        }

        private static void Main(string[] args)
        {
            FillHealthDeclaration();
            DrawBlood();
        }
    }
}