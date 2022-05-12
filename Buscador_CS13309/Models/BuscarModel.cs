using System.Diagnostics;

namespace Buscador_CS13309.Models
{
    public class BuscarModel
    {
        public string Palabra { get; set; }
        public List<string> Resultado()
        {
            string e = @"C:\CS13309\Scripts\CS13309_SearchTool.exe";
            string a = "retrieve " + Palabra;

            ProcessStartInfo process = new ProcessStartInfo(e);
            process.Arguments = a;
            process.RedirectStandardOutput = true;
            process.WindowStyle = ProcessWindowStyle.Hidden;
            process.UseShellExecute = false;

            Process proc = Process.Start(process);
            //proc.WaitForExit();
            StreamReader sr = proc.StandardOutput;
            List<string> op = new List<string>();
            while (proc.HasExited == false)
            {
                op.Add(sr.ReadLine());
            }

            sr.Close();
            proc.Close();

            op.RemoveAt((op.Count - 1));
            op.RemoveAt((op.Count - 1));
            op.RemoveAt(0);

            for (int i = 0; i < op.Count; i++)
            {
                string t = op[i];
                string[] s = new string[] { ".- " };
                string[] r = t.Split(s, 2, StringSplitOptions.RemoveEmptyEntries);
                op[i] = r[r.Length - 1];
            }

            return op;
        }

    }
}
