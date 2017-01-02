using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Remote {
    class Connection {
        public delegate void messageResponseHandler(string response);
        public event messageResponseHandler onRecieveMessage;

        private MessageWebSocket message;
        private DataWriter writer;
        private Uri uri;
        private bool connected;

        public Connection(Uri uri) {
            this.uri = uri;

            message = new MessageWebSocket();
            message.Control.MessageType = SocketMessageType.Utf8;
            message.MessageReceived += defaultMessageRecievedHandler;
            message.Closed += onClosed;

            writer = new DataWriter(message.OutputStream);
        }

        public bool isEstablished {
            get {
                return connected;
            }
        }

        public void close() {
            connected = false;
            message?.Close(1000, "");
            message?.Dispose();
            Debug.WriteLine("Connection closed");
        }

        public async Task<bool> connect() {
            try {
                Debug.WriteLine("Start Connecting");
                await message.ConnectAsync(uri);
                Debug.WriteLine("Connected!");
                connected = true;
            } catch(Exception e) {
                connected = false;
                switch (SocketError.GetStatus(e.HResult)) {
                    case SocketErrorStatus.HostNotFound:
                        Debug.WriteLine("Host not found");
                        break;
                    default:
                        Debug.WriteLine(e.Message);
                        break;
                }
            }

            return connected;
        }

        public async void sendMessage(string message) {
            writer.WriteString(message);
            await writer.StoreAsync();
        }

        private void defaultMessageRecievedHandler(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args) {
            using (DataReader reader = args.GetDataReader()) {
                reader.UnicodeEncoding = UnicodeEncoding.Utf8;
                string result = reader.ReadString(reader.UnconsumedBufferLength);
                onRecieveMessage?.Invoke(result);
            }
        }

        private void onClosed(IWebSocket sender, WebSocketClosedEventArgs args) {
            MessageWebSocket webSocket = Interlocked.Exchange(ref message, null);
            webSocket?.Dispose();
        }
    }
}
