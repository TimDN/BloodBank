using BloodCenter.Persons;
using System;

namespace BloodCenter.Questions
{
    public class Question
    {
        private readonly bool _acceptableAnswer;
        private bool _answer;

        public Question(string query, bool acceptableAnswer, int blockTime, string description = "",
            AudienceForQuestion audienceForQuestion = AudienceForQuestion.Both, Question innerQuestion = null)
        {
            Query = query;
            _acceptableAnswer = acceptableAnswer;
            BlockTimeInDays = blockTime;
            Description = description;
            AudienceForQuestion = audienceForQuestion;
            InnerQuestion = innerQuestion;
        }

        public Question InnerQuestion { get;}
        public int BlockTimeInDays { get; }
        public string Description { get; }
        public AudienceForQuestion AudienceForQuestion { get; }
        public string Query { get; }

        public bool QuestionAnsweredCorrectly()
        {
            return _answer == _acceptableAnswer;
        }

        public void AnswerQuestion(bool answer)
        {
            _answer = answer;
        }

    }
}