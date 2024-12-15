using System;
using System.IO;
using System.Text;
//simple. isnt it?
class Program
{
    public static string progVer = "1.0";
    public static void Main(string[] args)
    {
        if(args.Length != 0)
        {
            string fullPath = args[0];
            Console.WriteLine("Are you sure you want to do this? The file will be ruined forever! (Y/N)");
            string responser = Console.ReadLine() + "";
            if (responser.ToLower() == "y")
            {
                Ruin(fullPath);
                Console.WriteLine("File RUINED!!!!!!!!!\nPress any key to exit..");
                string end = Console.ReadLine();
                Environment.Exit(0);
            }
            else if (responser.ToLower() == "n")
            {
                Console.WriteLine("Good choice.\nPress any key to exit.");
                string end = Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("You didn't press neither Y or N, so try again later.\nPress any key to exit..");
                string end = Console.ReadLine();
                Environment.Exit(0);
            }
       
        }
        Console.WriteLine("Welcome to the File Ruiner v"+ progVer + "!!\nBe careful with this thing.\nBy greensoupdev.\n");
        Console.Write("Enter the path of your file: ");
        string fileUrl = Console.ReadLine() + "";
        Console.WriteLine("Ok. So, are you sure you want to do this? The file will be ruined forever! (Y/N)");
        string response = Console.ReadLine() + "";
        if (response.ToLower() == "y")
        {
            Ruin(fileUrl);
            Console.WriteLine("File RUINED!!!!!!!!!\nPress any key to exit..");
            string end = Console.ReadLine();
            Environment.Exit(0);
        }
        else if (response.ToLower() == "n")
        {
            Console.WriteLine("Good choice.\nPress any key to exit.");
            string end = Console.ReadLine();
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("You didn't press neither Y or N, so try again later.\nPress any key to exit..");
            string end = Console.ReadLine();
            Environment.Exit(0);
        }
        
    }
    
    public static void Ruin(string fileUrl)
    {
        //ruin process started
        Console.WriteLine("Ruining...");
        //encode
        byte[] encodedProg = Encoding.UTF8.GetBytes(File.ReadAllText(fileUrl));
        //convert to unicode hex
        string encodedProgString = ByteArrayToString(encodedProg);

        //decode part of the planet destroyer
        string teext = encodedProgString;
        byte[] finalBytes = FromHex(teext);
        //done
        File.WriteAllBytes(fileUrl, finalBytes);
    }
    //convert hex to byte array (destroyer!)
    public static byte[] FromHex(string hex)
    {
        byte[] raw = new byte[hex.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return raw;
    }
    //byte array to hex
    public static string ByteArrayToString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

}
