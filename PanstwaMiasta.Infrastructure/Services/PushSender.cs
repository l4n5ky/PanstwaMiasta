using FirebaseNet.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public class PushSender : IPushSender
    {
        private readonly FCMClient fcmClient;

        public PushSender()
        { 
            fcmClient = new FCMClient("AAAAhm-YdPc:APA91bFzKwj7pHcCSCkS3LuwYTTqWwfT37mN92VtT-Z5vvRhATwWDowHv-w_yqoONkjZjqrkn5kzPsy553vYiL8p1aIo8_sk4wd_cA5RwWhAbowMfOpc9RKVuNJzB9o-E3z6E80n8i25");
        }

        public async Task SendToAllRoomMembersAsync(string[] ids, string message)
        {
            var info = new Message()
            {
                RegistrationIds = ids,
                Data = new Dictionary<string, string>
                {
                        {"Message", $"{message}" }
                }
            };

            var result = await fcmClient.SendMessageAsync(info);
        }
    }
}
