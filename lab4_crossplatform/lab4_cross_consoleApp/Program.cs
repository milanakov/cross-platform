using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;

namespace lab4_cross_consoleApp
{
    class Program
    {
        private const string ENV_VAR_NAME = "LAB_PATH";

        static int Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.Command("version", cmd =>
            {
                cmd.OnExecute(() =>
                {
                    Console.WriteLine("Author: Milana Koval");
                    Console.WriteLine("Version: 1.0.0");
                    return 0;
                });
            });

            app.Command("run", cmd =>
            {
                var labArgument = cmd.Argument("<LAB>", "Which lab to run: lab1, lab2, lab3");
                var inputOption = cmd.Option("-i|--input <INPUT_FILE>", "Path to the input file", CommandOptionType.SingleValue);
                var outputOption = cmd.Option("-o|--output <OUTPUT_FILE>", "Path to the output file", CommandOptionType.SingleValue);

                cmd.OnExecute(() =>
                {
                    var labValue = labArgument.Value;
                    var inputFilePath = DetermineFilePath(inputOption.Value());
                    var outputFilePath = DetermineFilePath(outputOption.Value(), false);

                    if (string.IsNullOrEmpty(inputFilePath))
                    {
                        Console.WriteLine("Error: Input file not found.");
                        return 1;
                    }

                    switch (labValue)
                    {
                        case "lab1":
                            // Call Lab1 method from LabLibrary
                            lab4_cross_library.Lab1.RunLab1(inputFilePath, outputFilePath);
                            break;
                        case "lab2":
                            // Call Lab2 method from LabLibrary
                            lab4_cross_library.Lab2.RunLab2(inputFilePath, outputFilePath);
                            break;
                        case "lab3":
                            // Call Lab3 method from LabLibrary
                            lab4_cross_library.Lab3.RunLab3(inputFilePath, outputFilePath);
                            break;
                        default:
                            Console.WriteLine("Invalid lab specified.");
                            break;
                    }
                    return 0;
                });
            });

            app.Command("set-path", cmd =>
            {
                var pathOption = cmd.Option("-p|--path <PATH>", "Path to the folder with input and output files", CommandOptionType.SingleValue);

                cmd.OnExecute(() =>
                {
                    if (pathOption.HasValue())
                    {
                        Environment.SetEnvironmentVariable(ENV_VAR_NAME, pathOption.Value(), EnvironmentVariableTarget.User);
                        Console.WriteLine($"Environment variable {ENV_VAR_NAME} set to {pathOption.Value()}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Path not provided.");
                    }
                    return 0;
                });
            });


            return app.Execute(args);
        }

        private static string DetermineFilePath(string providedPath, bool isInput = true)
        {
            if (!string.IsNullOrEmpty(providedPath))
            {
                return providedPath;
            }

            var envPath = Environment.GetEnvironmentVariable(ENV_VAR_NAME);
            if (!string.IsNullOrEmpty(envPath))
            {
                var filePath = Path.Combine(envPath, isInput ? "input.txt" : "output.txt");
                if (isInput && File.Exists(filePath) || !isInput)
                {
                    return filePath;
                }
            }

            var homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var homeFilePath = Path.Combine(homeDirectory, isInput ? "input.txt" : "output.txt");
            if (isInput && File.Exists(homeFilePath) || !isInput)
            {
                return homeFilePath;
            }

            return null;
        }

    }
}
