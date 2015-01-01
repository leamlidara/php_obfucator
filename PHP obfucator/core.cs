using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PHP_obfucator
{
    class core
    {
        public bool compressString = true, advanceProtect = true, protectVariable = true, protectFunction = true, protectClass = true, isSniffed = false;

        //Key = the unobfucate name
        //value = obfucated name
        private List<string> buildInFn, specialVar;
        private Dictionary<string, string> functions, variables, classes;
        private static string _keycode = "leam_lidara.default.enc.code_168@";
        private Random rnd = new Random();
        public static string Key
        {
            get { return _keycode; }
        }

        public core()
        {
            string a = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcpqrstuvwxyz";
            _keycode = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++) _keycode += a[rnd.Next(0, a.Length - 1)];
            _keycode += DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() +
                DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString();
            functions = new Dictionary<string, string>();
            variables = new Dictionary<string, string>();
            classes = new Dictionary<string, string>();
        }
        
        public void sniff_variables(string directory_name)
        {
            loadResource();
            string[] files = Directory.GetFiles(directory_name, "*.php", SearchOption.AllDirectories);
            string string_ = @"[a-zA-Z_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*";
           
            Action<Dictionary<string, string>, List<string>, string, string> fn =
                new Action<Dictionary<string, string>, List<string>, string, string>(delegate(Dictionary<string, string> storedVariable, List<string> compareExisted, string expression, string content)
            {
                Regex r = new Regex(expression);
                MatchCollection matches = r.Matches(content);
                foreach (Match match in matches)
                {
                    if (compareExisted != null)
                    {
                        if (compareExisted.Contains(match.Value) == false && storedVariable.ContainsKey(match.Value) == false)
                        {
                            storedVariable.Add(match.Value, match.Value.obfucate());
                        }
                    }
                    else
                    {
                        if (storedVariable.ContainsKey(match.Value) == false)
                        {
                            string obfucated = "";
                            if (expression.ToLower().Contains("class") && match.Value.ToLower().Contains("controller")) obfucated = match.Value;
                            else obfucated = match.Value.obfucate();

                            storedVariable.Add(match.Value, obfucated);
                        }
                    }
                }
            });

            Func<Dictionary<string, string>, Dictionary<string, string>> sort =
                new Func<Dictionary<string, string>, Dictionary<string, string>>(delegate(Dictionary<string, string> unsorted)
            {
                List<KeyValuePair<string, string>> list = unsorted.ToList();

                list.Sort((firstPair, nextPair) =>
                {
                    return firstPair.Key.Length.CompareTo(nextPair.Key.Length);
                }
                );

                unsorted = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                return unsorted;
            });

            foreach (string file in files)
            {
                string content = File.ReadAllText(file);
                if (protectFunction == true)
                {
                    fn(functions, buildInFn, @"(?<=function\s+)" + string_ + @"(?=\s*\()", content);
                }
                if (protectClass == true)
                {
                    fn(classes, null, @"(?<=class\s+)" + string_, content);
                }
                if (protectVariable == true)
                {
                    fn(variables, specialVar, @"(?<=\$)" + string_, content);
                }
            }

            sort(functions);
            sort(classes);
            sort(variables);
            buildInFn = null;
            specialVar = null;
            isSniffed = true;
        }

        public void startObfucate(string fileName)
        {
            string s = File.ReadAllText(fileName);
            //s = obfucate(s);
            string result = s;
            MatchCollection matches = Regex.Matches(s, @"(?<=\<\?php)(?s:.*?)(?=\?>)");
            foreach (Match m in matches)
            {
                string a = m.Value;

                if (protectVariable == true)
                    a = a.Replace(a, variableObfucate(a));

                if (protectFunction == true)
                    a = a.Replace(a, functionObfucate(a));

                if (protectClass == true)
                    a = a.Replace(a, classObfucate(a));

                if (advanceProtect == true)
                {
                    if (a.Contains(Environment.NewLine) == true)
                    {
                        a = a.Replace(a, " " + advanceObfucate(a) + " ");
                    }
                }

                result = result.Replace(m.Value, a);
            }
            File.WriteAllText(fileName, result);
        }

        public void copyFiles(string directory_path, string destination_path, string searchPattern = "*.*")
        {
            while (directory_path.EndsWith("/") || directory_path.EndsWith("\\"))
            {
                directory_path = directory_path.Remove(directory_path.Length - 1);
            }

            string[] files = Directory.GetFiles(directory_path, searchPattern, SearchOption.AllDirectories);
            /*string destination_path = directory_path + "_obfucated";
            {
                int i = 0;
                string sub = "";
                while (Directory.Exists(destination_path + " " + sub))
                {
                    i++;
                    sub = "(" + i + ")";
                }
                destination_path += " " + sub;
            }*/

            string currentDirectory = directory_path;
            directory_path = Directory.GetParent(directory_path).FullName;
            destination_path = destination_path.Replace(directory_path, "").Trim();
            directory_path = directory_path + destination_path;
            {
                foreach (string file in files)
                {
                    string dir = Directory.GetParent(file).FullName;
                    dir = dir.Replace(currentDirectory, "").Trim();
                    if (Directory.Exists(directory_path + "\\" + dir) == false) Directory.CreateDirectory(directory_path + "\\" + dir);
                    string fileName = "";
                    if (file.Contains("\\"))
                    {
                        fileName = file.Split('\\').Last();
                    }
                    if (fileName.Contains("/"))
                    {
                        fileName = file.Split('/').Last();
                    }
                    File.Copy(file, directory_path + "\\" + dir + "\\" + fileName);
                }
            }
        }

        private void loadResource()
        {
            if (protectFunction == true)
            {
                string fileName = "bfn.ddb";
                if (File.Exists(fileName))
                {
                    buildInFn = dara_extension.readfile(fileName);
                    if (buildInFn.Count > 0)
                    {
                        if (File.Exists("mysqlfn.ddb"))
                        {
                            List<string> a = dara_extension.readfile("mysqlfn.ddb");
                            int cnt = 0;

                            foreach (string s in a)
                            {
                                buildInFn.Add(s);
                                cnt++;
                            }
                        }
                        else
                        {
                            protectFunction = false;
                        }
                    }
                }
                else protectFunction = false;
            }
            if (protectVariable == true)
            {
                string fileName = "svar.ddb";
                if (File.Exists(fileName))
                {
                    specialVar = dara_extension.readfile(fileName);
                    if (specialVar.Count < 1) protectVariable = false;
                }
                else protectVariable = false;
            }

        }

        private string removeComment(string strContents)
        {
            string singleLineComment = "(?<!(\".*)|('.*))[ ]*(//).*(?!\\n)";
            Regex reg = new Regex(singleLineComment, RegexOptions.Multiline);

            strContents = reg.Replace(strContents, "");

            singleLineComment = "(?<!(\"|'))/\\*(?s:.*?)\\*/";
            reg = new Regex(singleLineComment);
            strContents = reg.Replace(strContents, "");

            {
                string[] s = strContents.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                strContents = "";
                int cnt = s.Length;
                for (int i = 0; i < cnt; i++)
                {
                    string p = s[i].Trim();
                    if (p != "")
                    {
                        if (p.Contains("//"))
                        {

                        }
                        strContents += p;
                    }
                }
            }

            //while (strContents.Contains(Environment.NewLine + Environment.NewLine))
            //    strContents = strContents.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
            return strContents;
        }

        private string _random(int length)
        {
            StringBuilder result = new StringBuilder();
            string a = "ABCDEFGHIJKLMNOPQRSTUvWXYZabcdefghijlkmnopqrstuvwxyz";
            string num = "0123456789_";
            for (int i = 0; i < length; i++)
            {
                if (i == 3) a += num;
                
                int index = rnd.Next(0,a.Length);
                result.Append(a[index]);
            }

            return result.ToString();
        }

        private string variableObfucate(string inputStr)
        {
            if (isSniffed == false) throw new Exception("Sorry you did not sniff variables yet!");
            Action<string, string, string> fn = new Action<string, string, string>(delegate(string old_, string new_, string expression)
            {
                Regex rx = new Regex(expression);
                inputStr = rx.Replace(inputStr, variables[old_]);
            });

            foreach (KeyValuePair<string, string> k in variables)
            {
                fn(k.Key, k.Value, @"(?<=\$)\b" + k.Key + @"\b");
                fn(k.Key, k.Value, @"(?<=\-\>)\b" + k.Key + @"\b");
                fn(k.Key, k.Value, @"(?<=\:\:)\b" + k.Key + @"\b");
            }
            return inputStr;
        }

        private string functionObfucate(string inputStr)
        {
            if (isSniffed == false) throw new Exception("Sorry you did not sniff variables yet!");
            foreach (KeyValuePair<string, string> k in functions)
            {
                inputStr = Regex.Replace(inputStr, @"(?<!\=\s+new\s+)\b" + k.Key + @"\s*\(", k.Value + "(");
            }

            return inputStr;
        }

        private string classObfucate(string inputStr)
        {
            if (isSniffed == false) throw new Exception("Sorry you did not sniff variables yet!");
            foreach (KeyValuePair<string, string> k in classes)
            {
                inputStr = Regex.Replace(inputStr, @"(?<=class\s+)\b" + k.Key + @"\b", k.Value);
                inputStr = Regex.Replace(inputStr, @"(?<=extends\s+)\b" + k.Key + @"\b", k.Value);
                inputStr = Regex.Replace(inputStr, "(?<=class_exists\\s*\\(\\s*\\\")\\b" + k.Key + @"\b", k.Value);
                inputStr = Regex.Replace(inputStr, @"(?<=\=\s+new\s+)\b" + k.Key + @"\b", k.Value);
                inputStr = Regex.Replace(inputStr, @"\b" + k.Key + @"\b(?=\:\:)", k.Value);
            }
            return inputStr;
        }

        private string advanceObfucate(string strContents)
        {
            strContents = this.removeComment(strContents).toBase64();

            string result = "";
            string gzdecode = "";
            string base64_decode = "";
            string base_variable = "";
            List<string> v1 = new List<string>();
            List<string> v2 = new List<string>();
            List<string> allVariables = new List<string>();
            List<string> v3 = new List<string>();
            {
                string a = _random(5);
                string b = _random(6);
                string c = _random(7);
                string d = _random(8);
                string e = _random(9);
                v1.addRang("$" + a + "='g';", "$" + b + "='z';", "$" + c + "='dec';", "$" + d + "='ode';");
                v2.Add("$" + e + "=$" + a + ".$" + b + ".$" + c + ".$" + d + ";");
                allVariables.addRang(a, b, c, d, e);
                gzdecode = "$" + e;

                while (allVariables.Contains(a))
                    a = _random(5);
                while (allVariables.Contains(b))
                    b = _random(6);
                while (allVariables.Contains(c))
                    c = _random(7);
                while (allVariables.Contains(d))
                    d = _random(8);
                while (allVariables.Contains(e))
                    e = _random(9);
                v1.addRang("$" + a + "='bas';", "$" + b + "='e64_';", "$" + c + "='dec';", "$" + d + "='ode';");
                v2.Add("$" + e + "=$" + a + ".$" + b + ".$" + c + ".$" + d + ";");
                base64_decode = "$" + e;
                allVariables.addRang(a, b, c, d, e);
            }

            int index = 0;
            {
                Random r = new Random();
                index = rnd.Next(5, 10);

                for (int i = 0; i < index; i++)
                    strContents = ("eval(" + base64_decode + "(\"" + strContents + "\"));").toBase64();

                strContents = strContents.compress();

                int cnt = strContents.Length;
                if (cnt > 400) index = r.Next(cnt / 20, cnt / 6);
                else index = r.Next(cnt / 9, cnt / 3);
                List<string> s = new List<string>(strContents.Split_(index));

                cnt = s.Count;
                base_variable = _random(10);
                allVariables.Add(base_variable);
                base_variable = "$" + base_variable;
                string totalBaseVariable = base_variable + "=";
                for (int i = 0; i < cnt; i++)
                {
                    string variable = "";
                    while (variable == "" || allVariables.Contains(variable))
                        variable = _random(10);
                    allVariables.Add(variable);

                    if (i % 2 == 0)
                    {
                        v1.Add("$" + variable + "='" + s[i] + "';");
                    }
                    else
                    {
                        v2.Add("$" + variable + "='" + s[i] + "';");
                    }
                    totalBaseVariable += "$" + variable + ".";
                }
                totalBaseVariable = totalBaseVariable.Substring(0, totalBaseVariable.Length - 1) + ";";
                v3.Add(totalBaseVariable);
            }

            v1.Shuffle();
            v2.Shuffle();
            v3.Shuffle();
            allVariables.Shuffle();
            foreach (string a in v1)
            {
                result += a + Environment.NewLine;
            }
            foreach (string a in v2)
            {
                result += a + Environment.NewLine;
            }
            foreach (string a in v3)
            {
                result += a + Environment.NewLine;
            }

            //result += "eval(" + base64_decode + "(\"" + base_variable + "\"));" + Environment.NewLine;

            //result += "echo " + base64_decode+ "(" + gzdecode + "(" + base64_decode + "(\"" + base_variable + "\")));";
            result += "eval(" + base64_decode + "(" + gzdecode + "(" + base64_decode + "(\"" + base_variable + "\"))));" + Environment.NewLine;
            result += "unset(";
            foreach (string str in allVariables)
            {
                result += "$" + str + ",";
            }
            result = result.Substring(0, result.Length - 1) + ");";

            for (int i = 0; i < 5; i++)
            {
                result = result.compress();
                result = "eval(gzdecode(base64_decode(\"" + result + "\")));";
            }

            return result;
        }
    }
}
