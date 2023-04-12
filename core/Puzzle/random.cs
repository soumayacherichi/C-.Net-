public class random {
    static int[] RandomArray()
{
    Random random = new Random();
    int[] arr = new int[10];
    
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = random.Next(5, 26);
    }
    
    int min = arr[0];
    int max = arr[0];
    int sum = 0;
    
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < min)
        {
            min = arr[i];
        }
        if (arr[i] > max)
        {
            max = arr[i];
        }
        
        sum += arr[i];
    }
    
    Console.WriteLine("Min value: " + min);
    Console.WriteLine("Max value: " + max);
    Console.WriteLine("Sum of values: " + sum);
    
    return arr;
}
}