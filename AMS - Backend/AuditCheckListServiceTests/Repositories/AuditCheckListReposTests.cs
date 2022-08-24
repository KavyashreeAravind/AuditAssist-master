using AuditCheckListService.Models;
using AuditCheckListService.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AuditCheckListServiceTests.Repositories
{
    public class Tests
    {
        public List<QuestionsAndType> questions;
        public IQueryable<QuestionsAndType> questionsdata;

        [SetUp]
        public void Setup()
        {
            questions = new List<QuestionsAndType>()
            {
                new QuestionsAndType{Questions="1. Have all Change requests followed SDLC before PROD move?", AuditType="Internal"},
                new QuestionsAndType() { Questions = "2. Have all Change requests been approved by the application owner?", AuditType = "Internal" },
                new QuestionsAndType() { Questions = "3. Are all artifacts like CR document, Unit test cases available?", AuditType = "Internal" },
                new QuestionsAndType() { Questions = "1. Have all Change requests followed SDLC before PROD move?", AuditType = "SOX" },
                new QuestionsAndType() { Questions = "2. Have all Change requests been approved by the application owner?", AuditType = "SOX" },
                new QuestionsAndType() { Questions = "1. Have all Change requests followed SDLC before PROD move?", AuditType = "Financial" },
                new QuestionsAndType() { Questions = "2. Have all Change requests been approved by the application owner?", AuditType = "Financial" },
                new QuestionsAndType() { Questions = "1. Have all Change requests followed SDLC before PROD move?", AuditType = "PayRoll" },
                new QuestionsAndType() { Questions = "2. Have all Change requests been approved by the application owner?", AuditType = "PayRoll" }
            };
            questionsdata = questions.AsQueryable();
        }

        [Test]
        public void GetAllChecklistQuestionsListInternalTest()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("Internal");
            Assert.AreEqual(3, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListInternalTestFail()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("Internal");
            Assert.AreNotEqual(5, compList.Count());
        }



        [Test]
        public void GetAllChecklistQuestionsListSOXTest()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("SOX");
            Assert.AreEqual(2, compList.Count());
        }


        [Test]
        public void GetAllChecklistQuestionsListSOXTestFail()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("SOX");
            Assert.AreNotEqual(5, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListFinancialTest()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("Financial");
            Assert.AreEqual(2, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListFinancialTestFail()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("Financial");
            Assert.AreNotEqual(5, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListPayRollTest()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("PayRoll");
            Assert.AreEqual(2, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListTestFail()
        {

            var compRepo = new AuditChecklistRepos(questions);
            var compList = compRepo.AuditChecklistQuestions("PayRoll");
            Assert.AreNotEqual(5, compList.Count());
        }
    }
}