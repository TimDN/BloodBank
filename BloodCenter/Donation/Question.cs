using System;

namespace BloodCenter.Donation
{
    public class Question
    {
        private readonly string _acceptableAnswer;

        public Question(string query, string acceptableAnswer, int blockTime)
        {
            Query = query;
            _acceptableAnswer = acceptableAnswer;
            BlockTimeInDays = blockTime;
        }

        public int BlockTimeInDays { get; }
        public string Query { get; }
        public string Answer { get; set; }
        public bool QuestionFailed { get; private set; }

        public bool QuestionAnsweredCorrectly()
        {
            return Answer != _acceptableAnswer;
        }
    }
}