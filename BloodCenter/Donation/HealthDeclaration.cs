using System;
using System.Collections.Generic;

namespace BloodCenter.Donation
{
    public class HealthDeclaration : IBlockable
    {
        private string _notAcceptedReason;
        private int _notAcceptedBlockDays;

        public HealthDeclaration(Questionaire questionaire)
        {
            Questionaire = questionaire;
        }

        public Questionaire Questionaire { get; }
        public List<string> Medications { get; } = new List<string>();

        public bool IsBlocked => Questionaire.IsBlocked || !Approved;

        public string BlockReason => Questionaire.BlockReason + " " + _notAcceptedReason;

        public int BlockTimeInDays => Math.Max(Questionaire.BlockTimeInDays, _notAcceptedBlockDays);

        public bool Approved { get; private set; }

        public void AddMedication(string medication)
        {
            Medications.Add(medication);
        }

        public void Approve()
        {
            Approved = true;
        }

        public void Block(string reason, int blockTimeInDays)
        {
            Approved = false;
            _notAcceptedReason = reason;
            _notAcceptedBlockDays = blockTimeInDays;
        }
    }
}