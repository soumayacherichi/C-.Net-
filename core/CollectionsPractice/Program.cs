// An array to hold integer values 0 through 9
int[] numArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// An array of names
string[] nameArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };

// An array of length 10 that alternates between true and false values, starting with true
bool[] boolArray = new bool[10];
for (int i = 0; i < boolArray.Length; i++) {
    boolArray[i] = (i % 2 == 0);
}


// Create a list of ice cream flavors
List<string> iceCreamFlavors = new List<string>();
iceCreamFlavors.Add("Chocolate");
iceCreamFlavors.Add("Vanilla");
iceCreamFlavors.Add("Strawberry");
iceCreamFlavors.Add("Mint Chocolate Chip");
iceCreamFlavors.Add("Rocky Road");

// Output the length of the list
Console.WriteLine("The length of the ice cream flavors list is: " + iceCreamFlavors.Count);

// Output the third flavor in the list, then remove it
string thirdFlavor = iceCreamFlavors[2];
iceCreamFlavors.RemoveAt(2);
Console.WriteLine("The third ice cream flavor in the list was " + thirdFlavor);

// Output the new length of the list
Console.WriteLine("The new length of the ice cream flavors list is: " + iceCreamFlavors.Count);


// Create a dictionary to store string keys and values
Dictionary<string, string> iceCreamDict = new Dictionary<string, string>();

// Add key/value pairs to the dictionary
Random rand = new Random();
for (int i = 0; i < nameArray.Length; i++) {
    int randIndex = rand.Next(iceCreamFlavors.Count);
    iceCreamDict.Add(nameArray[i], iceCreamFlavors[randIndex]);
}

// Loop through the dictionary and print out each user's name and their associated ice cream flavor
foreach (KeyValuePair<string, string> entry in iceCreamDict) {
    Console.WriteLine(entry.Key + " likes " + entry.Value + " ice cream.");
}
