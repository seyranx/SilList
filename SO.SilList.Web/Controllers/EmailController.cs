using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Web.Controllers
{
    public class EmailController : Controller
    {
        private EmailManager emailManager = new EmailManager();
        private JobManager jobManager = new JobManager();
        private MemberManager memberManager = new MemberManager();

        //
        // GET: /EMail/
        public ActionResult SendEmail()
        {
            EmailVm email = new EmailVm();
            return PartialView(email);
        }

        [HttpPost]
        public ActionResult SendEmail(EmailVm input)
        {
            emailManager.sendMail(input);
            return Redirect(input.redirectTo);
        }

        
        public ActionResult applyToJob(Guid jobId)
        {
            

            EmailVm email = new EmailVm();
            JobVo job = jobManager.get(jobId);
            email.sendTo = job.email;
            MemberVo submitedBy = null;

            if(job.createdBy != null)
                submitedBy = memberManager.get((int)job.createdBy);
            
            if (submitedBy != null)
            {
                email.sendTo = submitedBy.email;
                email.cc = job.email;
            }
            if (!CurrentMember.isAuthenticated)
                return PartialView(email);
            email.sender = CurrentMember.member.email;
            email.subject = "Applying to " + job.title;
            email.header = "job Id: " + job.jobId + System.Environment.NewLine;
            email.header += "Link: " + Request.Url.AbsoluteUri + System.Environment.NewLine;
            email.header += "Name : " + CurrentMember.member.fullName + System.Environment.NewLine;
            email.header += "Email : " + CurrentMember.member.email + System.Environment.NewLine;
            email.header += "Contact Number: " + CurrentMember.member.phone + System.Environment.NewLine;
            if(CurrentMember.member.cityType != null)
                email.header += "Location: " + CurrentMember.member.cityType.name + ", " + CurrentMember.member.stateType.stateCode + System.Environment.NewLine;
            email.header += "---------------------------------------------------------------" + System.Environment.NewLine;
            email.redirectTo = Request.Url.AbsoluteUri;
            email.confirmation = true;
            return PartialView(email);
        }
        [HttpPost]
        public ActionResult applyToJob(EmailVm input)
        {
            if (emailManager.sendMail(input))
                return Redirect(input.redirectTo + "?applyied=true");
            return Redirect(input.redirectTo);
        }

        public ActionResult ShareLink(string shareEmail,bool toMyself,string link)
        {
            var email = new EmailVm();
            email.sender = CurrentMember.member.email;
            email.sendTo = shareEmail;
            if (toMyself)
                email.cc = CurrentMember.member.email;
            email.subject = CurrentMember.member.firstName + " shared a link with you";
            email.header = CurrentMember.member.fullName +" sent this link to you from HyeList.com\n please click on the link below to redirect to the shared webpage!";
            email.body = "Link: " + link;
            emailManager.sendMail(email);
            return Redirect(link);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
