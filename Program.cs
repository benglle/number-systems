using System;

class Program
{
    public static void Main(string[] args){
        // interface
        int it = 1;
        while (true){
            if (it == 1){Console.WriteLine("Number system translator\nEnter:\n'1': Den -> Hex\n'2': Den -> Bin\n'3': Bin -> Hex");}
            char option = (Console.ReadLine())[0]; 
            switch (option){
                case '1': Console.WriteLine($"{denHex(Convert.ToInt64(Console.ReadLine()))}\n"); break;
                case '2': Console.WriteLine($"{denBin(Convert.ToInt64(Console.ReadLine()))}\n"); break;
                case '3': Console.WriteLine($"{binHex(Console.ReadLine())}\n"); break;
                default: Console.WriteLine("Invalid input! Please retry.\n"); break;
            }
            it++; Console.WriteLine($"<{it}> Again? y/n"); if ((Console.ReadLine())[0]!='y'){break;}
        }
        
    }
    public static string denBin(long n){
        string z = "";
        while (n!=0){
            z += n % 2; n /= 2;
        }
        char[] c = z.ToCharArray();
        Array.Reverse(c); return new string(c);
    }

    public static string denHex(long n){
        string inb = denBin(n);
        return binHex(inb);
    }

    public static string binHex(string raw){
        int j = raw.Length; byte k = (byte)(4-(j % 4));
        if (k==4){k=0;}
        byte[] spl = new byte[j+k];
        for (int i = 0; i < j; i++){
            switch (raw[i]){
                case '1': spl[i+k] = 1; break;
                case '0': spl[i+k] = 0; break; 
                default: return "Invalid input";
            }}
        for (int i = 0; i < k; i++){
            spl[i] = 0;}
        char[] hex = new char[(k+j)/4];
        for (int c = 0; c < (k+j); c+=4){
            hex[c/4]=hexMap(Convert.ToByte((spl[c]*8)+(spl[c+1]*4)+(spl[c+2]*2)+(spl[c+3])));
        }
        string str = new string(hex); string r = "0x"+str;
        return r;
    }
    public static char hexMap(byte b){
        if (b <= 9){return b.ToString()[0];} //how to directly convert int to char!
        else{
        switch (b){
            case 10: return 'A'; case 11: return 'B';
            case 12: return 'C'; case 13: return 'D'; 
            case 14: return 'E'; case 15: return 'F'; 
            default: return 'X';
        }
        }
    }
}
