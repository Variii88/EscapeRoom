using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_2.GameHelpers
{
    /// <summary>
    ///המחלקה אחראית לגילוי השרת בתהליך איתור השרת ברשת המקומית באמצעות UDP Broadcast
    /// </summary>
    public class UDPDiscovery
    {
        private const int UDPPort = 5999;
        private const string BroadcastMessage = "ESCAPE ROOM SERVER";

        /// <summary>
        ///הפעולה מאזינה להודעות UDP ברשת,
        ///מחכה להודעת Broadcast מהשרת
        ///ואם מתקבלת ההודעה המתאימה מחזירה את כתובת ה IP שלו
        ///אם השרת לא נמצא מחזירה null
        /// </summary>
        public static async Task<string> FindServerAsync(int timeoutMs = 5000)
        {
            using (UdpClient udpClient = new UdpClient())
            {
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, UDPPort));

                var receiveTask = udpClient.ReceiveAsync();
                var timeoutTask = Task.Delay(timeoutMs);

                if (await Task.WhenAny(receiveTask, timeoutTask) == receiveTask)
                {
                    string message = Encoding.UTF8.GetString(receiveTask.Result.Buffer);
                    if (message == BroadcastMessage)
                        return receiveTask.Result.RemoteEndPoint.Address.ToString();
                }
                return null;
            }
        }
    }
}
