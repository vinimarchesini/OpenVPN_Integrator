using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using System.Text;
using System.Threading.Tasks;

namespace ovpnADM
{

    class Program
    {

        class Options
        {
            [Option('f', "file", Required = true,
  HelpText = "Coloque o caminho do exe do OpenVPN.")]
            public string pathfile { get; set; }

            [Option('c', "config", Required = true,
  HelpText = "Coloque o caminho do config do OpenVPN.")]
            public string config { get; set; }

            [Option('l', "log", Required = true,
  HelpText = "Coloque o caminho do log do OpenVPN.")]
            public string log { get; set; }

            [Option('u', "username", Required = true,
  HelpText = "Coloque o usuario do OpenVPN.")]
            public string username { get; set; }

            [Option('p', "password", Required = true,
  HelpText = "Coloque a senha do OpenVPN.")]
            public string password { get; set; }


        }

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
              .WithParsed(RunOptions)
              .WithNotParsed(HandleParseError);
            //Console.ReadKey();
        }
        static void RunOptions(Options opts)
        {
            //handle options
            StartOVPN sovpn = new StartOVPN();
            sovpn.InitSetup(opts.pathfile, opts.config, opts.log, opts.username, opts.password);
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
        }
    }

}
