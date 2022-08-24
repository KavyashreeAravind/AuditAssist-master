using AuditCheckListService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditCheckListService.Repositories
{

    public class AuditChecklistRepos : IAuditChecklistRepos
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistRepos));

        static List<QuestionsAndType> questionsAndTypes = new List<QuestionsAndType>()
        {
            new QuestionsAndType(){ Questions = "1. Have all Change requests followed SDLC before PROD move?" , AuditType = "Internal"},
            new QuestionsAndType() { Questions = "2. Have all Change requests been approved by the application owner?", AuditType = "Internal" },
            new QuestionsAndType() { Questions = "3. Are all artifacts like CR document, Unit test cases available?", AuditType = "Internal" },
            new QuestionsAndType() { Questions = "4. Is the SIT and UAT sign-off available?", AuditType = "Internal" },
            new QuestionsAndType() { Questions = "5. Is data deletion from the system done with application owner approval?", AuditType = "Internal" },
            new QuestionsAndType() { Questions = "1. Does operating management update all process and control documentation promptly throughout the year and not just when testing starts?", AuditType = "SOX" },
            new QuestionsAndType() { Questions = "2. Is there an effective change management process in place, including the timely assessment of process changes for their potential impact on key controls?", AuditType = "SOX" },
            new QuestionsAndType() { Questions = "3. Is operating management committed to assess and remediate all control deficiencies promptly?", AuditType = "SOX" },
            new QuestionsAndType() { Questions = "4. Has a top-down, risk-based approach been used to identify the key controls?", AuditType = "SOX" },
            new QuestionsAndType() { Questions = "5. Has overall staffing been optimized, reducing reliance on more expensive external consultants and testers?", AuditType = "SOX" },
            new QuestionsAndType() { Questions = "1. How are rates of pay for overtime and penalty rates handled? Is this in line with Fair Work requirements?", AuditType = "PayRoll" },
            new QuestionsAndType() { Questions = "2. Do you pay allowances as a separate or included in a flat rate? E.g.: Car, uniform, first aid, tool", AuditType = "PayRoll" },
            new QuestionsAndType() { Questions = "3. Do you audit your salaries against time worked for your salary staff on an annual basis?", AuditType = "PayRoll" },
            new QuestionsAndType() { Questions = "4. Do you give a copy of the Fair Work Statement out to new staff members as required by legislation?", AuditType = "PayRoll" },
            new QuestionsAndType() { Questions = "5. Do contracts have the correct termination information as per Fair Work?", AuditType = "PayRoll" },
            new QuestionsAndType() { Questions = "1. Does the organisation pay its creditors on or before their due dates? ", AuditType = "Financial" },
            new QuestionsAndType() { Questions = "2. Does the organisation comply with the terms of loan agreements?", AuditType = "Financial" },
            new QuestionsAndType() { Questions = "3. Has the organisation restructured debt during the period?", AuditType = "Financial" },
            new QuestionsAndType() { Questions = "4. Has the organisation undertaken new financing methods or disposed of substantial assets?", AuditType = "Financial" },
            new QuestionsAndType() { Questions = "5. Does the organisation have sufficient resources and/or appropriate structures in place to ensure any fixed-term borrowings approaching maturity have realistic prospects of renewal or repayment ? ", AuditType = "Financial" }
        };


        public AuditChecklistRepos(List<QuestionsAndType> questionsAndTypeslist)
        {
            questionsAndTypes = questionsAndTypeslist;
        }

        public AuditChecklistRepos()
        {

        }
        public List<QuestionsAndType> AuditChecklistQuestions(string auditType)
        {
            _log4net.Info("AuditCheckList questions method of AuditCheckRepos called");
            return questionsAndTypes.Where(questions => questions.AuditType == auditType).ToList();
        }

        

    }


}
