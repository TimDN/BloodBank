using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodCenter.Donation
{
    public class Questionaire
    {
        public Questionaire(List<Question> questions)
        {
            Questions = questions;
        }

        public List<Question> Questions { get; } = new List<Question>();
        public List<Question> FailedQuestion { get; } = new List<Question>();
        public bool QuestionairePassed => FailedQuestion.Count == 0;

        public bool IsBlocked => FailedQuestion.Count != 0;

        public string BlockReason => "Failed questions";

        public int BlockTimeInDays => BlockTime();

        public void EvaluateQuestionaire()
        {
            foreach (var question in Questions)
            {
                question.QuestionAnsweredCorrectly();
                if (question.QuestionFailed)
                {
                    FailedQuestion.Add(question);
                }
            }
        }

        private int BlockTime()
        {
            if (FailedQuestion.Count == 0)
            {
                return 0;
            }
            return FailedQuestion.Max(e => e.BlockTimeInDays);
        }
    }
}