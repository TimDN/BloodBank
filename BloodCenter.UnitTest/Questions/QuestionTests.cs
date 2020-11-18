using BloodCenter.Questions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BloodCenter.UnitTest.Questions
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        public void AnswerQuestion_AnswerSet_AnswerWasSet()
        {
            Question question = EmptyQuestion();

            question.AnswerQuestion(true);

            Assert.AreEqual(true, question.Answer);
        }

        [TestMethod]
        public void QuestionAnsweredCorrectly_CorrectAnswerGiven_ReturnsTrue()
        {
            Question question = QuestionWithTrueAnswer();
            question.AnswerQuestion(true);

            var actual = question.QuestionAnsweredCorrectly();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void QuestionAnsweredCorrectly_IncorrectAnswerGiven_ReturnsFalse()
        {
            var question = QuestionWithTrueAnswer();
            question.AnswerQuestion(false);

            var actual = question.QuestionAnsweredCorrectly();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Query_SetToNull_ThrowsArgument()
        {
            //Arrange
            //Act
            new Question(null, false, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Query_SetToEmptyString_ThrowsArgument()
        {
            //Arrange
            //Act
            new Question("", false, 0);
        }

        private static Question EmptyQuestion()
        {
            return new Question("query", false, 0);
        }

        private static Question QuestionWithTrueAnswer()
        {
            return new Question("query", true, 0);
        }
    }
}
