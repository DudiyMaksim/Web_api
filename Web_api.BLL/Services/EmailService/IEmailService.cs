using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_api.BLL.Services.EmailService
{
    public interface IEmailService
    {
        Task SendMessageAsync(string to, string subject, string body, bool isHtml = false);
    }
}
