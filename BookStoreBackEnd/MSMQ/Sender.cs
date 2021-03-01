using Experimental.System.Messaging;
using System;

namespace MSMQ
{
    public class Sender
    {
        /// <summary>
        /// Send To Que Mail.
        /// </summary>

        public void MailSender(string sendData)
        {
            MessageQueue msgQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msgQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msgQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }
            Message message = new Message
            {
                Formatter = new BinaryMessageFormatter(),
                Body = sendData
            };
            msgQueue.Label = "E-Mails";
            msgQueue.Send(message);
        }
    }
}
