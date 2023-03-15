using Microsoft.VisualBasic.FileIO;
using System;

class Program
{
    public static void Main(string[] args)
    {
        // interface
        int it = 1; bool lockb = false; bool prompt = false; bool eff = false; char option; string? input = "x";
        while (true)
        {
            if (it == 1)
            {
                Console.WriteLine("Number system translator\nEnter:\n'1': Den -> Hex\n'2': Den -> Bin\n'3': Bin -> Hex\n'4': Hex -> Den\n'5': Hex -> Bin");
                Console.WriteLine("Type x after your choice to lock it. Type xy to lock it and avoid 'again?' prompts."); input = Console.ReadLine();
            }
            if (lockb == false && it != 1) { input = Console.ReadLine(); } 
            if (input != null)
                {
                    option = (input)[0];
                    if (!(eff))
                    {
                        try
                        {
                            if (input[1] == 'x')
                            {
                                lockb = true; eff = true;
                            }
                            if (input[2] == 'y')
                            {
                                prompt = true; eff = true;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    switch (option)
                    {
                        case '1':
                            Console.WriteLine("\nEnter denary number below: "); string? x = Console.ReadLine(); if (x != null)
                            {
                                try { Console.WriteLine($"\n-> 0x{denHex(Convert.ToInt64(x))}\n"); }
                                catch (System.FormatException) { break; }
                                break;
                            }
                            break;
                        case '2':
                            Console.WriteLine("\nEnter denary number below: "); string? xy = Console.ReadLine(); if (xy != null)
                            {
                                try { Console.WriteLine($"\n-> 0b{denBin(Convert.ToInt64(xy))}\n"); }
                                catch (System.FormatException) { break; }
                                break;
                            }
                            break;
                        case '3':
                            Console.WriteLine("\nEnter binary string below: "); string? xyz = Console.ReadLine(); if (xyz != null)
                            {
                                try { Console.WriteLine($"\n-> 0x{binHex(xyz)}\n"); }
                                catch (FormatException) { break; }
                                break;
                            }
                            break;
                        default: Console.WriteLine("Invalid input! Please retry.\n"); break;
                    }
                    it++; if (!(prompt)) { Console.WriteLine($"<{it}> Again? y/n"); string? res = Console.ReadLine(); if (res == null || res[0] != 'y') { break; } }
            }
        }

    }
    public static string denBin(long n)
    {
        string z = "";
        while (n != 0)
        {
            z += n % 2; n /= 2;
        }
        char[] c = z.ToCharArray();
        Array.Reverse(c); return new string(c);
    }

    public static string denHex(long n)
    {
        string inb = denBin(n);
        return binHex(inb);
    }

    public static string binHex(string raw)
    {
        int j = raw.Length; byte k = (byte)(4 - (j % 4));
        if (k == 4) { k = 0; }
        byte[] spl = new byte[j + k];
        for (int i = 0; i < j; i++)
        {
            switch (raw[i])
            {
                case '1': spl[i + k] = 1; break;
                case '0': spl[i + k] = 0; break;
                default: return "Invalid input";
            }
        }
        for (int i = 0; i < k; i++)
        {
            spl[i] = 0;
        }
        char[] hex = new char[(k + j) / 4];
        for (int c = 0; c < (k + j); c += 4)
        {
            hex[c / 4] = hexMap(Convert.ToByte((spl[c] * 8) + (spl[c + 1] * 4) + (spl[c + 2] * 2) + (spl[c + 3])));
        }
        return new string(hex);
    }
    public static char hexMap(byte b)
    {
        if (b <= 9) { return b.ToString()[0]; } //how to directly convert int to char!
        else
        {
            switch (b)
            {
                case 10: return 'A'; case 11: return 'B';
                case 12: return 'C'; case 13: return 'D';
                case 14: return 'E'; case 15: return 'F';
                default: return 'X';
            }
        }
    }
}
