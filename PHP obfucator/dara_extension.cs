using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PHP_obfucator
{
    internal static class dara_extension
    {

        public static IEnumerable<string> Split_(this string str, int chunkSize)
        {
           System.Collections.Generic.IEnumerable<string> e = Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
           List<string> s = e.ToList();
           int a = 0;
           int.TryParse((str.Length / chunkSize).ToString().Split('.')[0], out a);
           str = str.Substring(a * chunkSize, str.Length - (a * chunkSize));
           s.Add(str);
           return s;
        }

        public static string convertToKhmer(this int str)
        {
            string s = str.ToString();
            string a = "";
            foreach (char c in s)
            {
                switch (c)
                {
                    case '1':
                        a += "១";
                        break;
                    case '2':
                        a += "២";
                        break;
                    case '3':
                        a += "៣";
                        break;
                    case '4':
                        a += "៤";
                        break;
                    case '5':
                        a += "៥";
                        break;
                    case '6':
                        a += "៦";
                        break;
                    case '7':
                        a += "៧";
                        break;
                    case '8':
                        a += "៨";
                        break;
                    case '9':
                        a += "៩";
                        break;
                    case '0':
                        a += "០";
                        break;
                }
            }

            return a;
        }

        public static string toBase64(this string str)
        {
            byte[] b = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(b);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void addRang<T>(this List<T> list, params T[] items)
        {
            foreach (T t in items)
            {
                list.Add(t);
            }
        }

        public static string compress(this string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);

            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            return Convert.ToBase64String(compressedData);
        }

        public static List<string> readfile(string filename)
        {
            string str = File.ReadAllText(filename);
            str = Security.DecryptStringAES(str, "Leamlidara@168!amb*");
            try
            {
                string[] s = str.Split(',');
                List<string> a = new List<string>();
                foreach (string b in s) { if (a.Contains(b) == false) a.Add(b); }
                return a;
            }
            catch
            {
                return new List<string>();
            }
        }

        public static string obfucate(this string str)
        {
            string result = "";
            string key = core.Key;
            byte[] b = Encoding.UTF8.GetBytes(str + "@168_leamlidara");
            byte[] key_byte = Encoding.UTF8.GetBytes(key);
            byte[] rrr = new byte[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                try
                {
                    rrr[i] = (byte)(b[i] ^ key_byte[i % key_byte.Length]);
                }
                catch { rrr[i] = 66; }
            }
            result = Utilities.Base32.ToBase32String(b);
            result = result.Replace("/", "1");
            result = result.Replace("+", "8");
            result = result.Replace("=", "9");
            return result;
        }
    }
}
