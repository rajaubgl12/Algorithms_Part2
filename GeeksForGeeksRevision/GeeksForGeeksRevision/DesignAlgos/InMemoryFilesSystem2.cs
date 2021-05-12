using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DesignAlgos
{
    class InMemoryFilesSystem2
    {
        Dictionary<string, string> fileContents = new Dictionary<string, string>();
        Dictionary<string, SortedSet<string>> directories = new Dictionary<string, SortedSet<string>>();

        public InMemoryFilesSystem2()
        {

        }

        public IList<string> Ls(string path)
        {
            IList<string> res = new List<string>();
            if(fileContents.ContainsKey(path))
            {
                int lastIndex = path.LastIndexOf('/');
                res.Add(path.Substring(lastIndex+1));
                return res;
            }
            SortedSet<string> items = directories[path];
            foreach(string file in items)
            {
                res.Add(file);
            }
            return res;
        }

        public void Mkdir(string path)
        {
            string[] chunks = path.Split('/');
            StringBuilder sb = new StringBuilder();
            string prevSub = "/";
            for (int i=0;i<chunks.Length;i++)
            {
                string chunk = chunks[i];
                if (i != 0) sb.Append("/");
                sb.Append(chunk);
                string sDir = sb.ToString();
                if (sDir == "") continue;
                AddSubDirectory(sDir);

                if(prevSub != null&& prevSub != sDir)
                {
                    directories[prevSub].Add(chunk);
                }
                prevSub = sDir;
            }
        }

        private void AddSubDirectory(string s)
        {
            if (s == "") return;
            if(!directories.ContainsKey(s))
            {
                directories[s] = new SortedSet<string>();
            }
        }

        public void AddContentToFile(string filePath, string content)
        {
            if(fileContents.ContainsKey(filePath))
            {
                fileContents[filePath] += content;
            }
            else
            {
                fileContents[filePath]= content;
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
}
