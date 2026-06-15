using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Escape_Room_2.ServerER
{
    /// <summary>
    ///המחלקה אחראית על שידור הודעת ה UDP Broadcast
    ///ברשת המקומית כדי שלקוחות יוכלו לאתר את השרת ולהתחבר אליו
    /// </summary>
    public class UDPBroadcaster
    {
        public const int UDPPort = 5999;
        private const string BroadcastMessage = "ESCAPE ROOM SERVER";
        private CancellationTokenSource cnclKey;

        /// <summary>
        ///מפעילה תהליך ברקע שמתחיל לשדר את ההודעה ברשת כל שנייה
        /// </summary>
        public void StartBroadcasting()
        {
            cnclKey = new CancellationTokenSource();
            Task.Run(() => BroadcastLoop(cnclKey.Token));
        }

        /// <summary>
        ///עוצרת את שידור ה UDP של השרת
        /// </summary>
        public void StopBroadcasting()
        {
            cnclKey?.Cancel();
        }

        /// <summary>
        ///מבצעת שידור חוזר של הודעת השרת ברשת כל שנייה עד לעצירה
        /// </summary>
        private async Task BroadcastLoop(CancellationToken token)
        {
            using (UdpClient udpClient = new UdpClient())
            {
                udpClient.EnableBroadcast = true;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, UDPPort);
                byte[] data = Encoding.UTF8.GetBytes(BroadcastMessage);

                while (!token.IsCancellationRequested)
                {
                    udpClient.Send(data, data.Length, endPoint);
                    await Task.Delay(1000);
                }
            }
        }
    }
}
