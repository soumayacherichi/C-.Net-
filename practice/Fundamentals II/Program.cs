static void PrintNumbers() {
    // Print all of the integers from 1 to 255.
    for (int i = 1; i <= 255; i++) {
        Console.WriteLine(i);
    }
}


static void PrintOdds() {
    // Print all of the odd integers from 1 to 255.
    for (int i = 1; i <= 255; i += 2) {
        Console.WriteLine(i);
    }
}


static void PrintSum() {
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go.
    int sum = 0;
    for (int i = 0; i <= 255; i++) {
        sum += i;
        Console.WriteLine("New number: {0} Sum: {1}", i, sum);
    }
}


static void LoopArray(int[] numbers) {
    // Write a function that would iterate through each item of the given integer array and 
    // print each value to the console. 
    foreach (int number in numbers) {
        Console.WriteLine(number);
    }
}
static int FindMax(int[] numbers) {
    // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.
    int max = numbers[0]; // assume first element as maximum
    foreach (int number in numbers) {
        if (number > max) {
            max = number; // update max if current element is greater
        }
    }
    return max; // return the maximum value
}
static void Main(string[] args) {
    int[] numbers = {5, 2, 8, 1, 6};
    int max = FindMax(numbers);
    Console.WriteLine("The maximum value in the array is: " + max);
}

static void GetAverage(int[] numbers)
{
    int sum = 0;
    foreach (int number in numbers)
    {
        sum += number;
    }
    double average = (double)sum / numbers.Length;
    Console.WriteLine("The average of the array is: " + average);
}


static List<int> OddList()
{
    List<int> oddNumbers = new List<int>();
    for (int i = 1; i <= 255; i += 2)
    {
        oddNumbers.Add(i);
    }
    return oddNumbers;
}
