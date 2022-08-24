using AuditCheckListService.Models;
using AuditCheckListService.Providers;
using AuditCheckListService.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AuditCheckListServiceTests.Providers
{
    public class Tests
    {
        public List<QuestionsAndType> questions;

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
        }


        [Test]
        public void GetAllChecklistQuestionsListInternalTest()
        {
            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Internal")).Returns(questions.Where(q => q.AuditType == "Internal").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("Internal");
            Assert.AreEqual(3, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListInternalTestFail()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Internal")).Returns(questions.Where(q => q.AuditType == "Internal").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("Internal");
            Assert.AreNotEqual(5, compList.Count());
        }



        [Test]
        public void GetAllChecklistQuestionsListSOXTest()
        {
            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("SOX")).Returns(questions.Where(q => q.AuditType == "SOX").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("SOX");
            Assert.AreEqual(2, compList.Count());
        }


        [Test]
        public void GetAllChecklistQuestionsListSOXTestFail()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("SOX")).Returns(questions.Where(q => q.AuditType == "SOX").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("SOX");
            Assert.AreNotEqual(5, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListFinancialTest()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Financial")).Returns(questions.Where(q => q.AuditType == "Financial").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("Financial");
            Assert.AreEqual(2, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListFinancialTestFail()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Financial")).Returns(questions.Where(q => q.AuditType == "Financial").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("Financial");
            Assert.AreNotEqual(5, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListPayRollTest()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("PayRoll")).Returns(questions.Where(q => q.AuditType == "PayRoll").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("PayRoll");
            Assert.AreEqual(2, compList.Count());
        }

        [Test]
        public void GetAllChecklistQuestionsListPayRollTestFail()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("PayRoll")).Returns(questions.Where(q => q.AuditType == "PayRoll").ToList);
            var compPro = new AuditCheckListProvider(rmock.Object);
            var compList = compPro.AuditChecklistQuestions("PayRoll");
            Assert.AreNotEqual(5, compList.Count());
        }
    }
}