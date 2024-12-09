/*
    Lambda - Anonymous function
     - Cach 1: 
        (tham_so) => bieu_thuc;
     - Cach 2:
        (tham_so) => {
            bieu_thuc;
            return gia_tri;
        } 
    Thuong duoc su dung de gan cho bien, delegate(phai phu hop voi delegate khai bao), 1 so thu vien
 */    


class Program {
    static void Main() {
        Action<string> action1 = (string s) => Console.WriteLine(s);
        Func<int,int,int> func1 =  (int a, int b) => {
            int kq = a + b;
            return kq;
        };
        
        action1?.Invoke("This is message");
        Console.WriteLine(func1?.Invoke(1, 3));

        int[] array = { 1, 2, 3, 4, 5 };
        var newArray = array.Where(x => x % 2 != 0);
        foreach (var i in newArray) {
            Console.Write(i + " ");
        }
    }
}