using AuditSeverityService.Models;
using AuditSeverityService.Models.ViewModels;
using AuditSeverityService.Providers;
using AuditSeverityService.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuditSeverityServiceTests.Providers
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
        public void SetStatusAndActionPass()
        {
            Mock<IAuditSeverityRepos> repo = new Mock<IAuditSeverityRepos>();
            repo.Setup(r => r.GetCountOfNosAllowed(item)).Returns(benchmark);
            var provider = new AuditSeverityProvider(repo.Object);
            var data = provider.SetStatusAndAction(item);
            Assert.IsNotNull(data);
        }

        [Test]
        public void SetStatusAndActionFail()
        {
            Mock<IAuditSeverityRepos> repo = new Mock<IAuditSeverityRepos>();
            repo.Setup(r => r.GetCountOfNosAllowed(null)).Returns(benchmark_invalid);
            var provider = new AuditSeverityProvider(repo.Object);
            Assert.Throws<NullReferenceException>(() => provider.SetStatusAndAction(item));
        }
    }
}