//question 1 

for (int i  = 0 ;i<256;i++)
{
    Console.WriteLine(i);
}
// question 2
for (int i  = 0 ;i<101;i++)
{
    if ((i % 5==0)||(i % 3==0))
    {
         Console.WriteLine(i);
    }
}
//question 3
for (int i  = 0 ;i<101;i++)
{
    if ((i % 5==0)||(i % 3==0))
    {
        if(i % 5==0){
             Console.WriteLine("Fizz");
        }
        else if(i % 3==0){
             Console.WriteLine("Buzz");
        }
        else if ((i % 5==0)&&(i % 3==0))
         Console.WriteLine("Fizzbuzz");
    }
}

//question 4






