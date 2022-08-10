using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : GenericServiceManager<Message>, IMessageService
    {
        private readonly IRepository<Message> _manager;
        public MessageManager(IRepository<Message> manager) : base(manager)
        {
            _manager = manager;
        }

        public Message GetByID(int id)
        {
            return _manager.Get(m => m.MessageID == id);
        }

        public List<Message> GetReceiverMessage()
        {
            return _manager.List(m => m.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetSenderMessage()
        {
            return _manager.List(m => m.SenderMail == "admin@gmail.com");
        }
    }
}
