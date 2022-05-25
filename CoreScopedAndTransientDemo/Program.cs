// See https://aka.ms/new-console-template for more information
using CoreScopedAndTransientDemo;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


var collection = new ServiceCollection();


//Same
collection.AddScoped<ScopedClass>();

//Every time new
collection.AddTransient<TransientClass>();

//ScopedClass scopedClass = new ScopedClass();    
//TransientClass transientClass   = new TransientClass();

var builder = collection.BuildServiceProvider();

Console.Clear();

Parallel.For(1, 10, i =>
{
    Console.WriteLine($"Trancent Instance ID ={ builder.GetService<TransientClass>().GetHashCode().ToString()}");

    Console.WriteLine($"Spoed Instance ID ={ builder.GetService<ScopedClass>().GetHashCode().ToString()}");
});



Console.ReadKey();