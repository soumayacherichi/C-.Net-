// Create an empty list of type object
List<object> objList = new List<object>();

// Add values to the list
objList.Add(7);
objList.Add(28);
objList.Add(-1);
objList.Add(true);
objList.Add("chair");

// Loop through the list and print all values
foreach (object obj in objList) {
    Console.WriteLine(obj);
}

// Add all values that are Int type together and output the sum
int sum = 0;
foreach (object obj in objList) {
    if (obj is int) {
        sum += (int)obj;
    }
}
Console.WriteLine("The sum of all integer values in the list is: " + sum);
