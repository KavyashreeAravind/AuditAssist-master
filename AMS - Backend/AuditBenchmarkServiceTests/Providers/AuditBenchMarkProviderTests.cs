using AuditBenchmarkService.Providers;
using AuditBenchmarkService.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AuditBenchmarkServiceTests.Providers
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
            auditDict_invalid = new Dictionary<string, int>();
        }

        [Test]
        public void GetNoCountPass()
        {
            var rmock = new Mock<IBenchMarkRepo>();
            rmock.Setup(r => r.GetAuditNoCount("Internal")).Returns(auditDict_valid);
            var provider = new BenchMarkProvider(rmock.Object);
            var data = provider.GetAuditNoCount("Internal");
            Assert.AreEqual(data, auditDict_valid);
        }

        [Test]
        public void GetNoCountFail()
        {
            var rmock = new Mock<IBenchMarkRepo>();
            rmock.Setup(r => r.GetAuditNoCount(null)).Returns(auditDict_invalid);
            var provider = new BenchMarkProvider(rmock.Object);
            var data = provider.GetAuditNoCount(null);
            Assert.AreEqual(data, auditDict_invalid);
        }
    }
}