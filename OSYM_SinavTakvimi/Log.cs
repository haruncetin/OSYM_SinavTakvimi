using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLog
{
    public class Log
    {
        public static void i(string mesaj, bool dosyaya_yaz = false)
        {
            string log = String.Format("{0} - {1}: {2}",DateTime.Now, "INFO", mesaj);
            Console.WriteLine(log);
            if (dosyaya_yaz)
            {
                StreamWriter sw = new StreamWriter(new FileStream("app.log", FileMode.Append));
                sw.WriteLine(log);
                sw.Close();
            }
        }
        public static void d(string mesaj, bool dosyaya_yaz = false)
        {
            string log = String.Format("{0} - {1}: {2}", DateTime.Now, "DEBUG", mesaj);
            Console.WriteLine(log);
            if (dosyaya_yaz)
            {
                StreamWriter sw = new StreamWriter(new FileStream("app.log", FileMode.Append));
                sw.WriteLine(log);
                sw.Close();
            }
        }
        public static void e(string mesaj, bool dosyaya_yaz = true)
        {
            string log = String.Format("{0} - {1}: {2}", DateTime.Now, "ERROR", mesaj);
            Console.WriteLine(log);
            if (dosyaya_yaz)
            {
                StreamWriter sw = new StreamWriter(new FileStream("app.log", FileMode.Append));
                sw.WriteLine(log);
                sw.Close();
            }
        }
    }
}
