    
static class ArrayExtension {
    public static int[] FindOldInArray(this int[] array) {
        int[] temp = [];
        foreach (var i in array) {
            if (i % 2 != 0) continue;
            Array.Resize(ref temp, temp.Length + 1);
            temp[^1] = i;
        }
        return temp;
    }

    public static void ListInArray(this int[] array) {
        foreach (var i in array) {
            Console.Write(i + "  ");
        }
    }
}

class Program {
    //Extension su dung static va tu khoa this de mo rong cac phuong thuc cho doi tuong
    static void Main() {
        int[] array = { 1, 2, 3, 4, 5 };
        int[] oldArray = array.FindOldInArray();
        oldArray.ListInArray();
    }
}