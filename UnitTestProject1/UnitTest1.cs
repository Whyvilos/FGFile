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
            Assert.AreEqual(true, flag, "���� ������� ��������");
        }


        [TestMethod]
        public void Test_ReadFFile_error()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> Text = new List<string>();
            string Path = @"";
            bool flag = cfh.ReadFFile(ref Text, Path);
            Assert.AreEqual(false, flag, "���� ��� �� ��������");
        }

        [TestMethod]
        public void Test_check_list_text()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> Text = new List<string>();
            List<string> ExText = new List<string>();

            ExText.Add("����������� ");
            ExText.Add("����������� ����� ");
            ExText.Add("������������ ");
            ExText.Add("����������. ");
            ExText.Add("IT ������ �� �����");
            ExText.Add("���������������");
            ExText.Add("�� �������, ������,");
            ExText.Add("����������� �����");

            string Path = @"G:\f.txt";
            bool flag = cfh.ReadFFile(ref Text, Path);

            for(int i = 0; i<8; i++)
            {
                Assert.AreEqual(ExText[i], Text[i], "����������� " + (i+1) + " ������");
            }
        }

        [TestMethod]
        public void Test_WriteGFile_success()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> ExText = new List<string>();
            ExText.Add("����������� ");
            ExText.Add("����������� ����� ");
            ExText.Add("������������ ");
            ExText.Add("����������. ");
            ExText.Add("IT ������ �� �����");
            ExText.Add("���������������");
            ExText.Add("�� �������, ������,");
            ExText.Add("����������� �����");
            string Path = @"G:\g.txt";
            bool flag = cfh.WriteGFile(ExText, Path);
            Assert.AreEqual(true, flag, "���� ������� �������");
        }


        [TestMethod]
        public void Test_WriteGFile_error()
        {
            ClassfileHelper cfh = new ClassfileHelper();
            List<string> ExText = new List<string>();
            ExText.Add("����������� ");
            ExText.Add("����������� ����� ");
            ExText.Add("������������ ");
            ExText.Add("����������. ");
            ExText.Add("IT ������ �� �����");
            ExText.Add("���������������");
            ExText.Add("�� �������, ������,");
            ExText.Add("����������� �����");
            string Path = @"";
            bool flag = cfh.WriteGFile(ExText, Path);
            Assert.AreEqual(false, flag, "���� ����� ������ �� �����");
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

            ExText.Add("����������� ");
            ExText.Add("����������� ����� ");
            ExText.Add("������������ ");
            ExText.Add("����������. ");
            ExText.Add("IT ������ �� �����");
            ExText.Add("���������������");
            ExText.Add("�� �������, ������,");
            ExText.Add("����������� �����");

            string PathF = @"G:\f.txt";
            string PathG = @"G:\g.txt";
            bool flagF = cfh.ReadFFile(ref Text, PathF);


            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(ExText[i], Text[i], "����������� " + (i + 1) + " ������");
            }

            bool flagG = cfh.WriteGFile(Text, PathG);
            

            Assert.AreEqual(true, flagG && flagF, "������ �����");
        }


    }

}
