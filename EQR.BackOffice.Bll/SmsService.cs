using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Cqrs;
using EQR.BackOffice.DAL.Repositories;
using MongoDB.Bson;

namespace EQR.BackOffice.Bll
{
    public sealed class SmsService :
        IAfterCommandHandler<CreateAdmissionCommand>
    {
        private readonly IVisitorsRepository _visitorsRepository;

        public SmsService(IVisitorsRepository visitorsRepository)
        {
            _visitorsRepository = visitorsRepository;
        }

        public async Task AfterExecute(CreateAdmissionCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var visitor = await _visitorsRepository.GetById(new ObjectId(cmd.VisitorId));

            var msg = $"Уважаемый(-ая) {visitor.FirstName}, будем рады видеть Вас в нашем офисе";

            using (var client = new HttpClient())
            {
                var r = await client.GetAsync($"https://smsc.ru/sys/send.php?login=movchinnikov&psw=qwerty&phones={visitor.PhoneNumber}&mes={msg}");
            }
        }
    }
}