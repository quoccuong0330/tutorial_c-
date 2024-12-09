

/*
 * publisher -> class - phat su kien
 * subsriber -> class - nhan su kien 
 */
public delegate void EnterKeyEvent(string? x);

class UserInput {
    //Khi khai bao "event" thi khong duoc gan thay vao do su dung +=, -= ( += de them su kien, -= de huy su kien)
    // public event EnterKeyEvent EnterKeyEvent;
    public event EventHandler EnterKeyEvent; 
    // ~ delegate void KIEU(object? sender, EventArgs args)
    public void Input() {
        do {
            Console.WriteLine(" ");
            Console.WriteLine("List of key: c, r, u, d");
            Console.WriteLine("Enter any key: ");
            string? s = Console.ReadLine();
            //Phat su kien
            //Do su dung EventHandler nen sender co the la null hoac this, args phai ke thua tu class EventArgs
            EnterKeyEvent?.Invoke(this, new DataInput(s));
        } while (true);
    }
}

class DataInput : EventArgs {
    public string data { get; set; }
    public  DataInput(string x) => data = x;
}

class UserAction {
    public void Sub(UserInput userInput) {
        userInput.EnterKeyEvent += PrintKey;
        userInput.EnterKeyEvent += PrintAction;
        
        //Bieu thuc lambda
        userInput.EnterKeyEvent += (object? o, EventArgs e) => {
            DataInput dataInput = (DataInput)e;
            string s = dataInput.data;
            Console.WriteLine("Press X to exit");
        };
    }
    
    
    // Ham phai co dang ~ delegate void KIEU(object? sender, EventArgs args)

    public void PrintAction(object? sender, EventArgs e) {
        DataInput dataInput = (DataInput)e;
        string s = dataInput.data;
        switch (s) {
            case "s":
                Console.WriteLine("Save successful");
                break;
            case "d":
                Console.WriteLine("Delete successful");
                break;
            case "u":
                Console.WriteLine("Update successful");
                break;
            case "c":
                Console.WriteLine("Create successful");
                break;
            default:
                Console.WriteLine("Press again!!!");
                break;
        }

    }

    public void PrintKey(object? sender, EventArgs e) {
        DataInput dataInput = (DataInput)e;
        string s = dataInput.data;
        Console.WriteLine($"Key vua nhap : {s}");
    }
}

class Program {
    static void Main() {
        //HandleEventCancel
        Console.CancelKeyPress += (sender, args) => {
            Console.WriteLine(" ");
            Console.WriteLine("Exit program");
        };
        //Publisher
        UserInput userInput = new UserInput();
        UserAction userAction = new UserAction();
        //Subcriber
        userAction.Sub(userInput);
        userInput.Input();
    }
}