using AuditBenchmarkService.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace AuditBenchmarkServiceTests.Repository
{
    public class Tests
    {
        Dictionary<string, int> auditDict = new Dictionary<string, int>();
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetInternalCount()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("Internal");
            int internalnocount = compDict["Internal"];
            Assert.AreEqual(3, internalnocount);
        }

        [Test]
        public void GetInternalCountFail()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("Internal");
            int internalnocount = compDict["Internal"];
            Assert.AreNotEqual(5, internalnocount);
        }

        [Test]
        public void GetSOXCount()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("SOX");
            int soxnocount = compDict["SOX"];
            Assert.AreEqual(2, soxnocount);
        }

        [Test]
        public void GetSOXCountFail()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("SOX");
            int soxnocount = compDict["SOX"];
            Assert.AreNotEqual(4, soxnocount);
        }

        [Test]
        public void GetFinancialCount()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("Financial");
            int fcount = compDict["Financial"];
            Assert.AreEqual(2, fcount);
        }

        [Test]
        public void GetFinancialCountFail()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("Financial");
            int fcount = compDict["Financial"];
            Assert.AreNotEqual(5, fcount);
        }

        [Test]
        public void GetPayrollCount()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("PayRoll");
            int pcount = compDict["PayRoll"];
            Assert.AreEqual(3, pcount);
        }

        [Test]
        public void GetPayrollCountFail()
        {

            var compRepo = new BenchMarkRepo(auditDict);
            var compDict = compRepo.GetAuditNoCount("PayRoll");
            int pcount = compDict["PayRoll"];
            Assert.AreNotEqual(5, pcount);
        }
    }
}