/*
  Asynchronous (multi - thread)
  Synchronous (chay don luong - chay dong bo - tu tren xuong duoi)
  De chay bat dong bo su dung Task, Task<T>
  Su dung Task.Start() de chay code tren 1 Thread khac
  Su dung Task.Wait() de doi tac vu chay xong moi chay tiep tac vu khac
  Su dung Task.WattAll(t1,t2,t3,...) de doi tat ca cac tac vu 
  1 Task chi duoc dung  Start 1 lan
  Thay vi dung Task.Wait() thi ta co the su dung async / await 
    su khac biet giua 2 thang nay la Task.Wait() phai return Task, con await thi khong can return Task
  Su dung Task<T> de nhan gia tri tra ve. Lay gia tri tra ve bang tu khoa Task.Result;
 */

class Program {
    static void DoSomeThing(int seconds, string message, ConsoleColor color) {
        lock (Console.Out) {
            Console.ForegroundColor = color;
            Console.WriteLine($"Start..... {message} in {seconds}");
            Console.ResetColor();
        }
        for (var i = 1; i <= seconds; i++) {
            lock (Console.Out) {
                Console.ForegroundColor = color;
                Console.WriteLine($"{message} - {i}");
                Console.ResetColor();
            }
            Thread.Sleep(1000);
        }

        lock (Console.Out) {
            Console.ForegroundColor = color;
            Console.WriteLine($"End..... {message} in {seconds}");
            Console.ResetColor();
        }
    }

    static async Task Task2() {
        Task t2 =  new Task( () => DoSomeThing(2,"This is a message", ConsoleColor.Cyan));
        t2.Start();
        await t2;
        Console.WriteLine("T2 da hoan thanh");
        
    }

    static async Task Task3() {
        Task t3 = new Task((object o)=> {
            int seconds = (int)o;
            DoSomeThing(seconds, "This is a message", ConsoleColor.Green);
        },4);
        t3.Start();
        await t3;
        Console.WriteLine("T3 da hoan thanh");
    }
    
    static async Task Main() {
        // Task Task2 =  Program.Task2();
        // Task Task3 = Program.Task3();
        //
        // DoSomeThing(3,"This is a message", ConsoleColor.Red);
        // await Task2;
        // await Task3;
        //
        // Console.WriteLine("End........");
        // Console.ReadKey();
        
        
        //Task<T> tra ve gia tri
        Task<string> Task1 = new Task<string>(() => {
            Console.ForegroundColor = ConsoleColor.Cyan;
            DoSomeThing(4,"t1",ConsoleColor.Blue);
            return "This is message";
        });
        Task<string> Task5 = new Task<string>(
            (object o) => {
                string s = (string)o;
                DoSomeThing(4,s,ConsoleColor.Blue);

                return s;
                
            }, "This is message");
        Task1.Start();
        Task5.Start();
        Task.WaitAll(Task1, Task5);
        Console.WriteLine(Task1.Result + " - " +Task5.Result);
    }
}