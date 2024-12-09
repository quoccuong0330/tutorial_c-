/*
  Su dung Exception de ngan chan chuong trinh dung lai 1 cach dot ngot
  Su dung try, catch de bat loi
 */

using Exception.Exceptions;

class Program {
    static void Main() {
        int a = 1;
        int b = 1;
        try {
            var c = a / b;
            // Console.WriteLine(c);
        }
        //Xu ly 1 exception cu the
        catch (DivideByZeroException d) {
            Console.WriteLine("Khong chia cho 0");
        }
        //Xu ly tong quat exception
        catch (System.Exception e) {
            //In ra ten loi
            Console.WriteLine(e.Message);
            //In ra noi bi loi
            Console.WriteLine(e.StackTrace);
            //In ra ten class cua loi
            // ~DivideByZeroException ~co the thay doi Exception thanh DivideByZeroException
            Console.WriteLine(e.GetType().Name);
        }

        try {
            Register("Cuong", 10);
        }
        catch (NameNotNullOrEmpty e) {
            Console.WriteLine(e.Message);
        }
        catch (AgeException e) {
            e.DetailError();
        }
        catch (System.Exception e) {
            Console.WriteLine(e.Message);
        }
        
    }

    static void Register(string name, int age) {
        //Tao exception thong qua class
        if (string.IsNullOrEmpty(name)) {
            throw new NameNotNullOrEmpty();
        }
        //Tao exception thong qua class
        if (age < 18 || age > 100) {
            throw new AgeException(age);
        }
        //Tu tao ngoai le ma khong dung ke thua tu class Exception
        if (age <= 0) {
            System.Exception e = new System.Exception("Your age is not valid");
            throw e;
        }
       
        Console.WriteLine($"Your name is {name}, {age} years old.");
    }
}