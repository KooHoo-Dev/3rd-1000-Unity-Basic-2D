using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Study.CsharpAdv.FileIO
{
    public class StreamReaderAndWriter : MonoBehaviour
    {
        public string FilePath;

        private void Start()
        {
            // StreamWriter writer = new StreamWriter(FilePath);
            // writer.WriteLine("첫 번째 줄");
            // writer.WriteLine("두 번째 줄");
            // writer.WriteLine("세 번째 줄");
            // writer.WriteLine("네 번째 줄");
            // writer.Close();
            
            StreamReader reader = new StreamReader(FilePath);
            List<string> lines = new List<string>();
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                if (line == null) break;
                lines.Add(line);
            }
            for (int i = 0; i < lines.Count; i++)
            {
                Debug.Log("Line: " + lines[i]);
            }
        }
    }
}