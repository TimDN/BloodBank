using BloodCenter.Persons;
using System;

namespace BloodCenter.Questions
{
    public class Question
    {
        private readonly bool _acceptableAnswer;

        public Question(string query, bool acceptableAnswer, int blockTime, string description = "",
            AudienceForQuestion audienceForQuestion = AudienceForQuestion.Both)
        {
            Query = query;
            _acceptableAnswer = acceptableAnswer;
            BlockTimeInDays = blockTime;
            Description = description;
            AudienceForQuestion = audienceForQuestion;
        }

        public int BlockTimeInDays { get; }
        public string Description { get; }
        public AudienceForQuestion AudienceForQuestion { get; }
        public string Query { get; }
        public bool Answer { get; set; }

        public bool QuestionAnsweredCorrectly()
        {
            return Answer == _acceptableAnswer;
        }
    }
}