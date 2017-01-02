using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using static Remote.Constants;

namespace Remote {
    class LGTV {
        private bool isPromptVisibleProperty;
        private bool isPairedProperty;
        private JObject commands;
        private static Uri webSocketUri;
        private Connection connection;
        private ClientKeyStore key;

        public LGTV(String ip) {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.OnApplicationExit);

            webSocketUri = new Uri("ws://" + ip + ":3000");
            connection = new Connection(webSocketUri);
            connection.onRecieveMessage += manageMessages;
            key = new ClientKeyStore(ip);

            commands = JObject.Parse(Control.Properties.Resources.MESSAGES);
            isPromptVisibleProperty = false;
            isPairedProperty = false;
        }

        public void pair() {
            JObject handShake = JObject.Parse(Control.Properties.Resources.HAND_SHAKE);
            if (isRegistered) handShake["payload"]["client-key"] = key.GetClientKey();
            connection.sendMessage(handShake.ToString());
        }
        
        public void off() {
            connection.sendMessage(createCommand(MSG_IDS.turn_off));
        }

        public void volumeUp() {
            connection.sendMessage(createCommand(MSG_IDS.volume_up));
        }

        public void volumeDown() {
            connection.sendMessage(createCommand(MSG_IDS.volume_down));
        }

        public void channelUp() {
            connection.sendMessage(createCommand(MSG_IDS.channel_up));
        }

        public void channelDown() {
            connection.sendMessage(createCommand(MSG_IDS.channel_down));
        }

        public void registerMessages(JObject payload, string type) {
            switch (type) {
                case "registered":
                    string k = payload["client-key"].ToString();
                    if (!isRegistered) key.SaveClientKey(k);
                    isPromptVisibleProperty = false;
                    isPairedProperty = true;
                    break;
                case "response":
                    isPromptVisibleProperty =
                        payload["pairingType"].ToString() == "PROMPT" && (bool)payload["returnValue"];
                    break;
                case "error":
                    isPromptVisibleProperty = false;
                    Debug.WriteLine("User decline registration");
                    break;
            }
        }

        public void manageMessages(string response) {
            Debug.WriteLine(response);
            JObject json = JObject.Parse(response);
            JObject payload = (JObject)json["payload"];

            MSG_IDS id = (MSG_IDS) Enum.Parse(typeof(MSG_IDS), json["id"].ToString(), true);
            string type = json["type"].ToString();

            switch (id) {
                case MSG_IDS.register:
                    registerMessages(payload, type);
                    break;
                case MSG_IDS.turn_off:
                    if ((bool) payload["returnValue"]) connection.close();
                    break;
            }
        }

        public Connection getConnection() {
            return connection;
        }

        public bool isConnected {
            get {
                return connection.isEstablished;
            }
        }

        public bool isRegistered {
            get {
                return key.GetClientKey() != null;
            }
        }

        public bool isPaired {
            get {
                return isPairedProperty;
            }
        }

        public bool isPromptVisible {
            get {
                return isPromptVisibleProperty;
            }
        }

        private string createCommand(MSG_IDS id) {
            JToken name;
            string idStr = id.ToString();
            if (commands.TryGetValue(idStr, out name)) {
                JObject command = new JObject();
                command["id"] = idStr;
                command["type"] = name["type"];
                command["uri"] = name["uri"];
                return command.ToString();
            }

            return null;
        }

        private void OnApplicationExit(object sender, EventArgs e) {
            connection.close();
        }
    }
}
