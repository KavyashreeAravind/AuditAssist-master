using AuditBenchmarkService.Controllers;
using AuditBenchmarkService.Providers;
using AuditBenchmarkService.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AuditBenchmarkServiceTests.Controllers
{
    public class Tests
    {
        int count_valid;
        int count_invalid;
        Dictionary<string, int> auditDict_valid;
        Dictionary<string, int> auditDict_invalid;
        [SetUp]
        public void Setup()
        {
            count_valid = 3;
            count_invalid = 4;
            auditDict_valid = new Dictionary<string, int>{
                {"internal",3 },
                {"SOX",2 },
                {"Financial",2 },
                {"PayRoll",3 }
            };
            auditDict_invalid = null;
        }

        [Test]
        public void GetNoCountPass()
        {
            var rmock = new Mock<IBenchMarkRepo>();
            rmock.Setup(r => r.GetAuditNoCount("Internal")).Returns(auditDict_valid);
            var pmock = new Mock<IBenchMarkProvider>();
            pmock.Setup(r => r.GetAuditNoCount("Internal")).Returns(auditDict_valid);
            var controller = new AuditBenchMarkController(pmock.Object);
            var data = controller.GetAuditNoCount("Internal") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }

        [Test]
        public void GetNoCountFail()
        {
            var rmock = new Mock<IBenchMarkRepo>();
            rmock.Setup(r => r.GetAuditNoCount(null)).Returns(auditDict_invalid);
            var pmock = new Mock<IBenchMarkProvider>();
            pmock.Setup(r => r.GetAuditNoCount(null)).Returns(auditDict_invalid);
            var controller = new AuditBenchMarkController(pmock.Object);
            var data = controller.GetAuditNoCount(null) as NotFoundObjectResult;
            Assert.AreEqual(404, data.StatusCode);
        }
    }
}