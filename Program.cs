using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Security.Cryptography;

namespace RandomGuid
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand("A simple command-line tool for generating secure random GUIDs");

            rootCommand.Handler = CommandHandler.Create(() =>
            {
                using var rng = new RNGCryptoServiceProvider();
                byte[] data = new byte[16];
                rng.GetBytes(data);

                Console.WriteLine(new System.Guid(data));
            });

            // Parses the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).GetAwaiter().GetResult();
        }
    }
}