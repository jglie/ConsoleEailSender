using ConfigServices;
using LogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServices
{
    /// <summary>
    /// Mailkit
    /// </summary>
    public class MailService : IMailService
    {
        private readonly ILogProvider log;
        private readonly IConfigService config;

        public MailService(ILogProvider log, IConfigService config) 
        {
            this.log = log;
            this.config = config;
        }
        public void Send(string title, string to, string body)
        {
            this.log.LogInfo("准备发送邮件。。。。");
            var smtpServer = this.config.GetValue("MailServer");
            var userName = this.config.GetValue("UserName");
            var passWord = this.config.GetValue("PassWord");
            Console.WriteLine($"邮件服务器：{smtpServer},用户名{userName},密码:{passWord}");
            Console.WriteLine($"真的发邮件了{title}{to}");
            this.log.LogInfo("准备发送成功。。。。");
            
        }
    }
}
