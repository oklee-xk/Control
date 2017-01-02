using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace Remote {
    public class ClientKeyStore {
        private Dictionary<string, string> dictionary;
        private const string FILE_NAME = "keys.bin";
        private string ip;
        public ClientKeyStore(string ip) {
            dictionary = deserialize<Dictionary<string, string>>(File.Open(FILE_NAME, FileMode.OpenOrCreate));
            this.ip = ip;
        }

        public string GetClientKey() {
            string value;
            return dictionary.TryGetValue(ip, out value) ? value : null;
        }

        public void SaveClientKey(string key) {
            dictionary.Add(ip, key);
            serialize(dictionary, File.Open(FILE_NAME, FileMode.Open));
        }

        public static void serialize<Object>(Object dictionary, Stream stream) {
            try // try to serialize the collection to a file
            {
                using (stream) {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, dictionary);
                }
            } catch (IOException) {
            }
        }

        public static Object deserialize<Object>(Stream stream) where Object : new() {
            Object ret = createInstance<Object>();
            try {
                using (stream) {
                    if (stream.Length != 0) {
                        BinaryFormatter bin = new BinaryFormatter();
                        ret = (Object)bin.Deserialize(stream);
                    }
                }
            } catch (IOException e) {
                Debug.WriteLine(e.Message);
            }
            return ret;
        }

        // function to create instance of T
        public static Object createInstance<Object>() where Object : new() {
            return (Object)Activator.CreateInstance(typeof(Object));
        }
    }
}
