using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DesignAlgos
{
    class InMemoryFileSystem
    {
        Dictionary<string, string> fileContents = new Dictionary<string, string>();
        Dictionary<string, SortedSet<string>> directories = new Dictionary<string, SortedSet<string>>();

        public InMemoryFileSystem()
        {
            Mkdir("/");
        }

        public IList<string> Ls(string path)
        {
            List<string> result = new List<string>();
            if (fileContents.ContainsKey(path))
            {
                int index = path.LastIndexOf('/');
                result.Add(path.Substring(index + 1));
                return result;
            }
            SortedSet<string> items = directories[path];
            foreach (string item in items)
            {
                result.Add(item);
            }
            return result;
        }

        public void Mkdir(string path)
        {
            string[] chunks = path.Split('/');
            StringBuilder sb = new StringBuilder();
            //sb.Append('/');

            void TryAddSbDir(string s)
            {
                if (s == "") return;
                //Console.WriteLine($"Mkdir {path} {s}");
                if (!directories.ContainsKey(s))
                {
                    directories[s] = new SortedSet<string>();
                }
            }

            //TryAddSbDir();
            string prevS = "/";
            for (int i = 0; i < chunks.Length; i++)
            {
                string chunk = chunks[i];
                if (i != 0) sb.Append('/');
                sb.Append(chunk);
                string s = sb.ToString();
                if (s == "") continue;
                TryAddSbDir(s);
                if (prevS != null && prevS != s)
                {
                    directories[prevS].Add(chunk);
                }
                prevS = s;
            }
        }

        public void AddContentToFile(string filePath, string content)
        {
            if (fileContents.TryGetValue(filePath, out string oldContent))
            {
                fileContents[filePath] = oldContent + content;
            }
            else
            {
                fileContents[filePath] = content;
                int lastSlash = filePath.LastIndexOf('/');
                string name = filePath.Substring(lastSlash + 1);
                string dir = filePath.Substring(0, lastSlash);
                if (dir == "") dir = "/";
                if (lastSlash != 0)
                {
                    Mkdir(dir);
                }
                directories[dir].Add(name);
            }
        }

        public string ReadContentFromFile(string filePath)
        {
            return fileContents[filePath];
        }
    }

    /**
     * Your FileSystem object will be instantiated and called as such:
     * FileSystem obj = new FileSystem();
     * IList<string> param_1 = obj.Ls(path);
     * obj.Mkdir(path);
     * obj.AddContentToFile(filePath,content);
     * string param_4 = obj.ReadContentFromFile(filePath);
     */
}
