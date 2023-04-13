﻿Buffet myBuffet = new Buffet();
SweetTooth Seba = new SweetTooth();
SpiceHound Maxi = new SpiceHound();
Console.WriteLine("Seba's Food:");
while (Seba.IsFull != true)
{
    Seba.Consume(myBuffet.Serve());
}
Console.WriteLine("Maxi's Food:");
while (Maxi.IsFull != true)
{
    Maxi.Consume(myBuffet.Serve());
}