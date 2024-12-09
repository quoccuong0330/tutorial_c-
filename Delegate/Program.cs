/*
 Delegate cach khai bao
  - delegate kieuTraVe tenHam = phuong thuc
  - trong C# dinh nghia 2 delegate ~ generic: Func, Action
        - Action action; 
            ~ delegate void tenHam(); 
            ~ Action<string,int,...> action; 
            ~ Action action(string,int,...);
        - Func func; 
            ~ Func<int> f1; ~ delegate int f1;
            ~ Func<double,double,int> func1; ~ delegate int func1(double,double)
 */


public delegate void PrintKey(string s);

public delegate double PrintInt(int i);

class Program {
     static void Info(string s) {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(s);
    }
    static void Warning(string s) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(s);
    }

    static double BinhPhuong(int i) {
        return i*i;
    }
    
    static double CanBac2(int i) {
        return Math.Sqrt(i);
    }

    
    
    static void Main(string[] args) {
        string s = "This is a message";
        // PrintKey printKey = null;
        
        // Khai bao co ban
         // printKey = Info;
         // printKey.Invoke(s);
        //
        // printKey = Warning;
        // printKey.Invoke(s);
        
        //Khai bao 1 chuoi delegate su dung +=
        // printKey += Info;
        // printKey += Warning;
        // printKey?.Invoke(s);
        
        // Action<string> PrintKey1 = null;
        // PrintKey1 += Info;
        // PrintKey1 += Warning;
        // PrintKey1?.Invoke(s);

        int i = 9;
        PrintInt printInt = null;
        Func<int, double> printIntFunc = null;
        // printInt += BinhPhuong;
        // Console.WriteLine(printInt?.Invoke(i));
        // printInt += CanBac2;
        // Console.WriteLine(printInt?.Invoke(i));
        printIntFunc += BinhPhuong;
        Console.WriteLine(printIntFunc?.Invoke(i));
        printIntFunc += CanBac2;
        Console.WriteLine(printIntFunc?.Invoke(i));

    }
}