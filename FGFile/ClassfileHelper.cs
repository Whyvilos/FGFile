using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace FGFile
{
    public class ClassfileHelper
    {




        public Boolean WriteGFile(List<string> Text, string Path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, false, Encoding.Default))
                {
                    foreach (string x in Text)
                    {

                        sw.WriteLine(x);
                    }
                    //MessageBox.Show("Запись успешно выполнена");
                }
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ошибка записи");
                //Console.WriteLine("Error writing");
                return false;
            }
        }

        public Boolean ReadFFile(ref List<string> Text, string Path)
        {
            //List<String> Text = new List<String>();
            try
            {
                string line = "";
                using (StreamReader sr = new StreamReader(Path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Length < 20)
                        {
                            Text.Add(line);
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ошибка чтения");
                //Console.WriteLine("Error reading");
                return false;
            }
        }





    }
}
