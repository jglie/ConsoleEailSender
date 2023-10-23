using System;

namespace ConsoleAppEailSender
{
    using ConfigServices;
    using LogServices;
    using MailServices;
    using Microsoft.Extensions.DependencyInjection;
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection service = new ServiceCollection();
            //service.AddScoped<ILogProvider, ConsoleLogProvider>();
            service.AddConsoleLog();
            //service.AddScoped<IConfigService, EnvVarConfigService>();
            service.AddScoped(typeof(IConfigService), x => new IniFileConfigService() { FilePath = "mail.ini" });

            service.AddScoped<IMailService, MailService>();
            using (var sp = service.BuildServiceProvider())
            {
                // 第一个根对象只能用ServiceLocator
                //IMailService mail =  sp.GetService<IMailService>();
                var mail = sp.GetRequiredService<IMailService>();
                mail.Send("国庆放假通知", "xiaoming@yahu.com", "国庆中秋来来就大幅度发的烦都烦死懂法守法");
            }
            Console.Read();
        }
    }
}
