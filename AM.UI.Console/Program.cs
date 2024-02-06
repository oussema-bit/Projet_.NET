// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");
Plane p = new Plane();
p.Capacity = 100;

Console.WriteLine(p);

//initialiser avec l'initialiseur d'objet

Flight flight=new Flight(){Departure = "Tunis"};

Console.WriteLine(flight);