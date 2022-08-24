using AuditSeverityService.Controllers;
using AuditSeverityService.Models;
using AuditSeverityService.Models.ViewModels;
using AuditSeverityService.Providers;
using AuditSeverityService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityServiceTests.Controllers
{
    public class Tests
    {
        List<Audit> auditdetails = new List<Audit>();

        IQueryable<Audit> auditdetailsData;

        Mock<DbSet<Audit>> mockSet;

        Mock<AuditManagementSystemContext> auditManagementSystemContext;

        Dictionary<string, int> benchmark = new Dictionary<string, int>();
        Dictionary<string, int> benchmark_invalid = new Dictionary<string, int>();

        AuditDetails item;
        AuditDetails item_invalid = null;

        [SetUp]
        public void Setup()
        {
            auditdetails = new List<Audit>()
           {
               new Audit{Auditid=101,ProjectName="Face Detection",ProjectManagerName="Manali",ApplicationOwnerName="Python Labs",AuditType="SOX",AuditDate=DateTime.Now,ProjectExecutionStatus="Green",RemedialActionDuration="No action needed",Userid=1}
           };

            item = new AuditDetails() { Auditid = 102, ProjectName = "Face Detection", ProjectManagerName = "Manali", ApplicationOwnerName = "Python Labs", AuditType = "SOX", CountOfNos = 3, AuditDate = DateTime.Now, ProjectExecutionStatus = "Red", RemedialActionDuration = "Action to be taken in 1 week", Userid = 2 };

            if (!benchmark.ContainsKey("Internal"))
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
        public async Task PostAuditPass()
        {
            Mock<IAuditSeverityRepos> repo = new Mock<IAuditSeverityRepos>();
            repo.Setup(r => r.GetCountOfNosAllowed(item)).Returns(benchmark);
            Mock<IAuditSeverityProvider> pro = new Mock<IAuditSeverityProvider>();
            pro.Setup(p => p.SetStatusAndAction(item)).Returns(item);
            var s = new AuditSeverityController(pro.Object);
            var data = await s.PostAudit(item) as OkObjectResult;
            Assert.AreEqual(data.StatusCode, 200);
        }

        [Test]
        public async Task PostAuditFail()
        {
            Mock<IAuditSeverityRepos> repo = new Mock<IAuditSeverityRepos>();
            repo.Setup(r => r.GetCountOfNosAllowed(null)).Returns(benchmark_invalid);
            Mock<IAuditSeverityProvider> pro = new Mock<IAuditSeverityProvider>();
            pro.Setup(p => p.SetStatusAndAction(null)).Returns(item_invalid);
            var s = new AuditSeverityController(pro.Object);
            var data = await s.PostAudit(item_invalid) as BadRequestObjectResult;
            Assert.AreEqual(400, data.StatusCode);
        }
    }
}