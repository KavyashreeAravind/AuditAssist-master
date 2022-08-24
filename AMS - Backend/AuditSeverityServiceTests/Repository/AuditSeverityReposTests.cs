using AuditSeverityService.Models;
using AuditSeverityService.Models.ViewModels;
using AuditSeverityService.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SoloX.CodeQuality.Test.Helpers.Http;
using System.Net.Http.Json;

namespace AuditSeverityServiceTests.Repository
{
    public class Tests
    {
        List<Audit> auditdetails = new List<Audit>();

        IQueryable<Audit> auditdetailsData;

        Mock<DbSet<Audit>> mockSet;

        Mock<AuditManagementSystemContext> auditManagementSystemContext;

        Dictionary<string, int> benchmark = new Dictionary<string, int>();

        AuditDetails item;

        [SetUp]
        public void Setup()
        {
            auditdetails = new List<Audit>()
           {
               new Audit{Auditid=101,ProjectName="Face Detection",ProjectManagerName="Manali",ApplicationOwnerName="Python Labs",AuditType="SOX",AuditDate=DateTime.Now,ProjectExecutionStatus="Green",RemedialActionDuration="No action needed",Userid=1}
           };

            item = new AuditDetails() { Auditid = 102, ProjectName = "Face Detection", ProjectManagerName = "Manali", ApplicationOwnerName = "Python Labs", AuditType = "SOX", CountOfNos = 3, AuditDate = DateTime.Now, ProjectExecutionStatus = "Red", RemedialActionDuration = "Action to be taken in 1 week", Userid = 2 };

            if(!benchmark.ContainsKey("Internal"))
                benchmark.Add("Internal", 3);
            if (!benchmark.ContainsKey("SOX"))
                benchmark.Add("SOX", 1);
            if (!benchmark.ContainsKey("PayRoll"))
                benchmark.Add("PayRoll", 3);
            if (!benchmark.ContainsKey("Financial"))
                benchmark.Add("Financial", 2);
            auditdetailsData = auditdetails.AsQueryable();

            mockSet = new Mock<DbSet<Audit>>();

            mockSet.As<IQueryable<Audit>>().Setup(m => m.Provider).Returns(auditdetailsData.Provider);
            mockSet.As<IQueryable<Audit>>().Setup(m => m.Expression).Returns(auditdetailsData.Expression);
            mockSet.As<IQueryable<Audit>>().Setup(m => m.ElementType).Returns(auditdetailsData.ElementType);
            mockSet.As<IQueryable<Audit>>().Setup(m => m.GetEnumerator()).Returns(auditdetailsData.GetEnumerator());

            var p = new DbContextOptions<AuditManagementSystemContext>();
            auditManagementSystemContext = new Mock<AuditManagementSystemContext>(p);
            auditManagementSystemContext.Setup(x => x.Audit).Returns(mockSet.Object);
        }

        [Test]
        public void PostAuditTest()
        {
            var authRepo = new AuditSeverityRepos(auditManagementSystemContext.Object);
            var compObj = authRepo.PostAudit(new AuditDetails() { Auditid = 101, ProjectName = "Face Detection", ProjectManagerName = "Manali", ApplicationOwnerName = "Python Labs", AuditType = "SOX", CountOfNos = 3, AuditDate = DateTime.Now, ProjectExecutionStatus = "Red", RemedialActionDuration = "Action to be taken in 1 week", Userid = 1 });

            Assert.IsNotNull(compObj);
        }

        [Test]
        public void PostAuditTestFail()
        {
            var authRepo = new AuditSeverityRepos(auditManagementSystemContext.Object);
            var compObj = authRepo.PostAudit(null);

            Assert.Throws<AggregateException>(() => authRepo.PostAudit(null).Wait());
        }

        [Test]
        public void CheckBenchmarkTestPass()
        {
            Mock<IAuditSeverityRepos> repo = new Mock<IAuditSeverityRepos>();
            repo.Setup(r => r.GetCountOfNosAllowed(item)).Returns(benchmark);
            Assert.AreEqual(1, benchmark["SOX"]);
        }

        [Test]
        public void CheckBenchmarkTestFail()
        {
            var repo = new AuditSeverityRepos(auditManagementSystemContext.Object);
            var response = repo.GetCountOfNosAllowed(null);
            Assert.IsNull(response);
        }


    }
    
}