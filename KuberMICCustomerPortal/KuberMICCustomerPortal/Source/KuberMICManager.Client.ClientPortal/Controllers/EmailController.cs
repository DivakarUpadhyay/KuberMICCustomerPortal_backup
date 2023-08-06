using KuberMICManager.Core.Domain.Entities.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KuberMICManager.Client.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmailController : Controller
    {
        private EmailSettings _emailSettings;
        private IWebHostEnvironment _hostingEnvironment;

        public EmailController(IOptions<EmailSettings> settings, IWebHostEnvironment hostingEnvironment)
        {
            _emailSettings = settings.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Send an email.
        /// </summary>
        /// <returns>SUCCESS or FAILURE message</returns>
        [HttpPost]
        public async Task<string> SendQuote()
        {
            string emailTo = "test@localhost";

            if (string.IsNullOrEmpty(emailTo))
                return "The send-to email address is blank.";

            string webRoot = _hostingEnvironment.WebRootPath;

            LinkedResource imgSignature;

            string logoPath = System.IO.Path.Combine(webRoot, "imag/logo", "kuber-logo-black.svg");

            imgSignature = new LinkedResource(logoPath, "image/png");

            string subject = "Send Mail";

            string body = BuildEmailBody();

            var response = "";
            
            await SendMailAsync(emailTo, null, subject, body, imgSignature);

            return response;
        }

        /// <summary>
        /// Send a email
        /// </summary>
        /// <param name="emailTo"></param>
        /// <param name="emailCC"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="imgSignature"></param>
        /// <returns></returns>
        private async Task<string> SendMailAsync(string emailTo, string emailCC, string subject, String body, LinkedResource imgSignature)
        {
            string response = string.Empty;

            try
            {
                var smtp = new SmtpClient
                {
                    Host = _emailSettings.EmailHost,
                    Port = _emailSettings.EmailPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSettings.FromEmail, _emailSettings.FromPassword)
                };

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var alternateView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

                // add the signature image
                if (imgSignature != null)
                    alternateView.LinkedResources.Add(imgSignature);

                using (var message = new MailMessage() { Subject = subject, AlternateViews = { alternateView } })
                {
                    message.From = new MailAddress(_emailSettings.FromEmail);

                    if (emailTo.Contains(",") == true)
                    {
                        string[] emails = emailTo.Split(",".ToCharArray());
                        foreach (string s in emails)
                        {
                            message.To.Add(s);
                        }
                    }
                    else
                    {
                        message.To.Add(emailTo);
                    }

                    if (string.IsNullOrEmpty(emailCC) == false)
                    {
                        string[] emails = emailCC.Split(",".ToCharArray());
                        foreach (string s in emails)
                        {
                            message.CC.Add(s);
                        }
                    }

                    message.IsBodyHtml = true;
                    await smtp.SendMailAsync(message);
                }

                response = "SUCCESS";
            }
            catch (Exception ex1)
            {
                response = "FAILURE:: emailTo::" + emailTo + " Reason::" + ex1.Message;
            }

            return response;
        }

        /// <summary>
        /// Generate the Email Body
        /// </summary>
        /// <param name="selectedItinerary"></param>
        /// <returns></returns>
        private string BuildEmailBody()
        {
            StringBuilder htmlBody = new StringBuilder();

            htmlBody.Append("<table style='width:650px;border:1px solid;' align='center'>");
            htmlBody.Append("<tr><td>");

            htmlBody.Append("<table style='width:100%;font-size: 15px;border-top:1px solid #e6e6e6;margin-top:15px;' align='center'> ");
            htmlBody.Append("  <tr> ");
            htmlBody.Append("     <td><div>&nbsp;</div></td><td><div>&nbsp;</div></td> ");
            htmlBody.Append("  </tr> ");
            htmlBody.Append("  <tr> ");
            htmlBody.Append("    <td style='font-weight: bold;'> ");
            htmlBody.Append("	 </td> ");
            htmlBody.Append("	</tr> ");

            htmlBody.Append("</table> ");

            htmlBody.Append("</td></tr>");
            htmlBody.Append("</table>");

            return htmlBody.ToString();
        }
    }
}