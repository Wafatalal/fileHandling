using System;
using System.IO;

namespace Rainbow_School
    {
    class Teacher
    {
        public int ID;
        public string Name;
        public string Class;
        public string Section;
  

        public void WriteData()
        {
            FileStream fs = new FileStream(
                "C:\\Users\\samer\\Desktop\\file\\test.txt",
                FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your Id : ");
            this.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter your Name : ");
            this.Name = Console.ReadLine();
            Console.Write("Enter your Class : ");
            this.Class = Console.ReadLine();
            Console.Write("Enter your Section : ");
            this.Section = Console.ReadLine();
            Console.WriteLine("-----------------------------");

            sw.WriteLine(ID);
            sw.WriteLine(Name);
            sw.WriteLine(Class);
            sw.WriteLine(Section);
            Console.WriteLine("The Content written to the file successfully.");
            sw.Close();
            fs.Close();
        }
        public void AppendData()
        {
            try
            {
                using (FileStream fs = new FileStream("C:\\Users\\samer\\Desktop\\file\\test.txt",
                    FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        Console.WriteLine("-----------------------------");
                        Console.Write("Enter your Id : ");
                        this.ID = int.Parse(Console.ReadLine());
                        Console.Write("Enter your Name : ");
                        this.Name = Console.ReadLine();
                        Console.Write("Enter your Class : ");
                        this.Class = Console.ReadLine();
                        Console.Write("Enter your Section : ");
                        this.Section = Console.ReadLine();
                        Console.WriteLine("-----------------------------");
                        sw.WriteLine(ID);
                        sw.WriteLine(Name);
                        sw.WriteLine(Class);
                        sw.WriteLine(Section);

                        Console.WriteLine("The Content append to the file successfully.");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ReadData()
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("C:\\Users\\samer\\Desktop\\file\\test.txt",
                FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                while (str != null)
                {
                    Console.WriteLine(str);
                    str = sr.ReadLine();

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char opt;
            do
            {
                Console.WriteLine("1 - Write your data");
                Console.WriteLine("2 - Append your data");
                Console.WriteLine("3 -Read your data ");
                Console.Write("Select the Operation : ");
                Teacher T = new Teacher();
                int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                       
                        T.WriteData();

                        break;

                case 2:
                        T.AppendData();

                        break;

                case 3:
                        T.ReadData();
                    break;

                default:
                    Console.WriteLine("Invalid Operation Type!!");
                    break;
            }
            Console.Write("Do you wish to Continue?(yes/No) : ");
           opt = char.Parse(Console.ReadLine());
            } while (opt == 'y' || opt == 'Y');
            Console.ReadKey();
        }
    }
}
