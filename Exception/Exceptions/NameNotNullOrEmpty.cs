namespace Exception.Exceptions;

public class NameNotNullOrEmpty : System.Exception{
    public NameNotNullOrEmpty() : base("Your name is not empty") { }
}

public class AgeException : System.Exception {
    private int _age;

    public AgeException(int age) : base("Age is not valid") {
        _age = age;
    }

    public void DetailError() {
        Console.WriteLine($"{_age} is in [0 - 100]");
    }
}