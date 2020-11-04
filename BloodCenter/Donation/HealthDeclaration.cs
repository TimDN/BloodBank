using BloodCenter.Employees;
using BloodCenter.Questions;
using System;
using System.Collections.Generic;

namespace BloodCenter.Donation
{
    public class HealthDeclaration : IReviewable
    {
        private string _notAcceptedReason;
        private int _notAcceptedBlockDays;
        private bool _wasBlocked;

        public HealthDeclaration(Questionaire questionaire)
        {
            Questionaire = questionaire;
        }

        public Questionaire Questionaire { get; }
        public List<string> Medications { get; } = new List<string>();

        public bool IsBlocked => Questionaire.IsBlocked || !_wasBlocked;

        public string BlockReason => Questionaire.BlockReason + " " + _notAcceptedReason;

        public int BlockTimeInDays => Math.Max(Questionaire.BlockTimeInDays, _notAcceptedBlockDays);

        public bool Reviewed { get; private set; }

        public Nurse ReviewBy { get; private set; }

        public void AddMedication(string medication)
        {
            Medications.Add(medication);
        }

        public void Approve(Nurse nurse)
        {
            Reviewed = true;
            ReviewBy = nurse;
        }

        public void Block(Nurse nurse, string reason, int blockTimeInDays)
        {
            Reviewed = false;
            ReviewBy = nurse;
            _wasBlocked = true;
            _notAcceptedReason = reason;
            _notAcceptedBlockDays = blockTimeInDays;
        }
    }
}