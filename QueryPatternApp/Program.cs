// See https://aka.ms/new-console-template for more information
using QueryPatternApp;

Console.WriteLine("Hello, World!");


Query<Product> query = new(p=> new
{
    p.Id,
    p.Name
},"Product");

query.Add(Criteria<Product>.GreaterThan("Id", 10));

string _query = query.GenerateWhereClause();

Console.WriteLine(_query);
Console.ReadKey();

