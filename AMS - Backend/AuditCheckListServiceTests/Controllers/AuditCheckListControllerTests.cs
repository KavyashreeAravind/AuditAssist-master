using AuditCheckListService.Controllers;
using AuditCheckListService.Models;
using AuditCheckListService.Providers;
using AuditCheckListService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AuditCheckListServiceTests.Controllers
{
    public class Tests
    {
        public List<QuestionsAndType> questions;
        public List<QuestionsAndType> questions_invalid;

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

            questions_invalid = null;
        }


        [Test]
        public void GetAllChecklistQuestionsListInternalTest()
        {
            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Internal")).Returns(questions.Where(q => q.AuditType == "Internal").ToList);
            var pmock = new Mock<IAuditCheckListProvider>();
            pmock.Setup(r => r.AuditChecklistQuestions("Internal")).Returns(questions.Where(q => q.AuditType == "Internal").ToList);
            var controller = new AuditCheckListController(pmock.Object);
            var data = controller.AuditChecklistQuestions("Internal") as OkObjectResult;
            Assert.AreEqual(200,data.StatusCode);
        }

        [Test]
        public void GetAllChecklistQuestionsListInternalTestFail()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Internal")).Returns(questions_invalid);
            var pmock = new Mock<IAuditCheckListProvider>();
            pmock.Setup(r => r.AuditChecklistQuestions("Internal")).Returns(questions_invalid);
            var controller = new AuditCheckListController(pmock.Object);
            var data = controller.AuditChecklistQuestions("Internal") as NotFoundObjectResult;
            Assert.AreEqual(404, data.StatusCode);
        }



        [Test]
        public void GetAllChecklistQuestionsListSOXTest()
        {
            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("SOX")).Returns(questions.Where(q => q.AuditType == "SOX").ToList);
            var pmock = new Mock<IAuditCheckListProvider>();
            pmock.Setup(r => r.AuditChecklistQuestions("SOX")).Returns(questions.Where(q => q.AuditType == "SOX").ToList);
            var controller = new AuditCheckListController(pmock.Object);
            var data = controller.AuditChecklistQuestions("SOX") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }


        [Test]
        public void GetAllChecklistQuestionsListSOXTestFail()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("SOX")).Returns(questions_invalid);
            var pmock = new Mock<IAuditCheckListProvider>();
            pmock.Setup(r => r.AuditChecklistQuestions("SOX")).Returns(questions_invalid);
            var controller = new AuditCheckListController(pmock.Object);
            var data = controller.AuditChecklistQuestions("SOX") as NotFoundObjectResult;
            Assert.AreEqual(404, data.StatusCode);
        }

        [Test]
        public void GetAllChecklistQuestionsListFinancialTest()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("Financial")).Returns(questions.Where(q => q.AuditType == "Financial").ToList);
            var pmock = new Mock<IAuditCheckListProvider>();
            pmock.Setup(r => r.AuditChecklistQuestions("Financial")).Returns(questions.Where(q => q.AuditType == "Financial").ToList);
            var controller = new AuditCheckListController(pmock.Object);
            var data = controller.AuditChecklistQuestions("Financial") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
            }

        [Test]
        public void GetAllChecklistQuestionsListFinancialTestFail()
        {

                var rmock = new Mock<IAuditChecklistRepos>();
                rmock.Setup(r => r.AuditChecklistQuestions("Financial")).Returns(questions_invalid);
                var pmock = new Mock<IAuditCheckListProvider>();
                pmock.Setup(r => r.AuditChecklistQuestions("Financial")).Returns(questions_invalid);
                var controller = new AuditCheckListController(pmock.Object);
                var data = controller.AuditChecklistQuestions("Financial") as NotFoundObjectResult;
                Assert.AreEqual(404, data.StatusCode);
            }

        [Test]
        public void GetAllChecklistQuestionsListPayRollTest()
        {

            var rmock = new Mock<IAuditChecklistRepos>();
            rmock.Setup(r => r.AuditChecklistQuestions("PayRoll")).Returns(questions.Where(q => q.AuditType == "PayRoll").ToList);
            var pmock = new Mock<IAuditCheckListProvider>();
            pmock.Setup(r => r.AuditChecklistQuestions("PayRoll")).Returns(questions.Where(q => q.AuditType == "PayRoll").ToList);
            var controller = new AuditCheckListController(pmock.Object);
            var data = controller.AuditChecklistQuestions("PayRoll") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
            }

        [Test]
        public void GetAllChecklistQuestionsListPayRollTestFail()
        {

                var rmock = new Mock<IAuditChecklistRepos>();
                rmock.Setup(r => r.AuditChecklistQuestions("PayRoll")).Returns(questions_invalid);
                var pmock = new Mock<IAuditCheckListProvider>();
                pmock.Setup(r => r.AuditChecklistQuestions("PayRoll")).Returns(questions_invalid);
                var controller = new AuditCheckListController(pmock.Object);
                var data = controller.AuditChecklistQuestions("PayRoll") as NotFoundObjectResult;
                Assert.AreEqual(404, data.StatusCode);
            }
    }
}