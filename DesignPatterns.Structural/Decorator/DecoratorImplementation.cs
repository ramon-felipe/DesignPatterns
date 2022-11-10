using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    /// <summary>
    /// Component: Defines the interface for objects that can have responsibilities added to them dynamically.
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }

    /// <summary>
    /// Concrete component: Defines an object to which additional responsibilities can be attached.
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Sending email with message '{message}' via {nameof(CloudMailService)}");

            return true;
        }
    }

    /// <summary>
    /// Concrete component: Defines an object to which additional responsibilities can be attached.
    /// </summary>
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Sending email with message '{message}' via {nameof(OnPremiseMailService)}");

            return true;
        }
    }

    /// <summary>
    /// Decorator
    /// It intercepts, if you want, the component methods. Allowing us to extend the functionality of the object.
    /// It maintains a reference to a component object and defines an interface that conforms to the component's interface.
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    /// <summary>
    /// Concrete decorator
    /// They are responsible for adding responsibilities to the component.
    /// </summary>
    public class MailStatisticsDecorator : MailServiceDecoratorBase
    {        
        public MailStatisticsDecorator(IMailService mailService) : base(mailService) { }

        public override bool SendMail(string message)
        {
            // do some stuffs...
            Console.WriteLine($"Collecting statistics in {nameof(MailStatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    /// <summary>
    /// Concrete decorator
    /// They are responsible for adding responsibilities to the component.
    /// </summary>
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public IList<string> SentMessages { get; } = new List<string>();

        public MessageDatabaseDecorator(IMailService mailService) : base(mailService) { }

        public override bool SendMail(string message)
        {
            this.SentMessages.Add(message);

            return base.SendMail(message);
        }
    }
}
