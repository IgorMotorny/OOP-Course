using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GasStation {
    [Serializable()]

    public class FileManager {
        private string _path { get; } = "C:\\GasStation";
        public static string Path { get; } = "C:\\GasStation";
        public string FilePath { get; }
        public FileManager() {
            CreateMainDir();
        }

        public delegate ArrayList fileReader();
        public void WriteBin<T>(T data, string fileName) {
            Stream stream = null;
            BinaryFormatter writer;

            try {
                stream = File.Open(_path + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new BinaryFormatter();
                writer.Serialize(stream, data);
            }  finally {
                if (stream != null)
                    stream.Close();
            }
        }

        public T ReadBin<T>(string fileName) {
            Stream stream = null;
            T result;
            try {
                stream = File.Open(_path + "\\" + fileName, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();

                result = (T)bFormatter.Deserialize(stream);
                return result;

            } catch {} finally {
                if (stream != null) {
                    stream.Close();
                }
            }
            return default(T);
        }

        public List<Operator> ReadOpertorsList(string fileName) {
            StreamReader reader = null;
            List<Operator> result = null;

            string name, surname, birthday;
            try {
                reader = File.OpenText(_path + "\\" + fileName);
                result = new List<Operator>();

                while (reader.Peek() != -1) {
                    surname = reader.ReadLine();
                    name = reader.ReadLine();
                    birthday = reader.ReadLine();
                    reader.ReadLine();
                    try {
                        result.Add(new Operator(name, surname, new Date(birthday)));
                    } catch { }
                }
            } catch { } finally {
                if (reader != null) {
                    reader.Close();
                }
            }

            return result;
         }

        public void WriteText<T>(string fileName, List<T> data) {
            StreamWriter writer = null;
            try {
                writer = new StreamWriter(_path + "\\" + fileName);
                foreach (T item in data) {
                    writer.WriteLine(item.ToString());
                }
            } catch { } finally {
                if (writer != null)
                    writer.Close();
            }
        }

        private void CreateMainDir() {
            System.IO.Directory.CreateDirectory(Path);
            System.IO.Directory.CreateDirectory(Path + "\\Balance");
        }


    }
}
