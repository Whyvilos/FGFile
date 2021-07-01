using FGFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ReadFFile_success()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> Text = new List<string>();
            string Path = @"G:\f.txt";
            bool flag = cfh.ReadFFile(ref Text, Path);
            Assert.AreEqual(true, flag, "Файл успешно прочитан");
        }


        [TestMethod]
        public void Test_ReadFFile_error()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> Text = new List<string>();
            string Path = @"";
            bool flag = cfh.ReadFFile(ref Text, Path);
            Assert.AreEqual(false, flag, "Файл был не прочитан");
        }

        [TestMethod]
        public void Test_check_list_text()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> Text = new List<string>();
            List<string> ExText = new List<string>();

            ExText.Add("предпосылки ");
            ExText.Add("качественно новых ");
            ExText.Add("планируемого ");
            ExText.Add("обновления. ");
            ExText.Add("IT влечет за собой");
            ExText.Add("соответствующей");
            ExText.Add("Не следует, однако,");
            ExText.Add("обеспечение нашей");

            string Path = @"G:\f.txt";
            bool flag = cfh.ReadFFile(ref Text, Path);

            for(int i = 0; i<8; i++)
            {
                Assert.AreEqual(ExText[i], Text[i], "Сравнивание " + (i+1) + " строки");
            }
        }

        [TestMethod]
        public void Test_WriteGFile_success()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> ExText = new List<string>();
            ExText.Add("предпосылки ");
            ExText.Add("качественно новых ");
            ExText.Add("планируемого ");
            ExText.Add("обновления. ");
            ExText.Add("IT влечет за собой");
            ExText.Add("соответствующей");
            ExText.Add("Не следует, однако,");
            ExText.Add("обеспечение нашей");
            string Path = @"G:\g.txt";
            bool flag = cfh.WriteGFile(ExText, Path);
            Assert.AreEqual(true, flag, "Файл успешно записан");
        }


        [TestMethod]
        public void Test_WriteGFile_error()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> ExText = new List<string>();
            ExText.Add("предпосылки ");
            ExText.Add("качественно новых ");
            ExText.Add("планируемого ");
            ExText.Add("обновления. ");
            ExText.Add("IT влечет за собой");
            ExText.Add("соответствующей");
            ExText.Add("Не следует, однако,");
            ExText.Add("обеспечение нашей");
            string Path = @"";
            bool flag = cfh.WriteGFile(ExText, Path);
            Assert.AreEqual(false, flag, "Путь файла указан не верно");
        }


    }

    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void Test_reader_and_writer()
        {
            

            ClassfileHelper cfh = new ClassfileHelper();
            List<string> Text = new List<string>();
            List<string> ExText = new List<string>();

            ExText.Add("предпосылки ");
            ExText.Add("качественно новых ");
            ExText.Add("планируемого ");
            ExText.Add("обновления. ");
            ExText.Add("IT влечет за собой");
            ExText.Add("соответствующей");
            ExText.Add("Не следует, однако,");
            ExText.Add("обеспечение нашей");

            string PathF = @"G:\f.txt";
            string PathG = @"G:\g.txt";
            bool flagF = cfh.ReadFFile(ref Text, PathF);


            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(ExText[i], Text[i], "Сравнивание " + (i + 1) + " строки");
            }

            bool flagG = cfh.WriteGFile(Text, PathG);
            

            Assert.AreEqual(true, flagG && flagF, "Запись файла");
        }


    }

}
