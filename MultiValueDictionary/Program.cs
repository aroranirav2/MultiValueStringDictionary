using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultiStringValuesDictionary multiStringValuesDictionary = new MultiStringValuesDictionary();
            Console.WriteLine("Welcome to multi value dictionary application!");
            Console.WriteLine("List of the options as follows: \nKeys\nMembers\nAdd\nRemove\nRemoveAll\nClear\nKeyExists\nMemberExists\nAllMembers\nItems\nExit");
            Console.WriteLine("Options are not case-sensitive\n");
            try
            {
                InputListener(multiStringValuesDictionary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void InputListener(MultiStringValuesDictionary multiStringValuesDictionary)
        {
            while (true)
            {
                Console.Write("> ");
                var userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    try
                    {
                        var commandItems = userInput.Split(' ');
                        switch (commandItems[0].ToUpper())
                        {
                            case "KEYS":
                                MultiValuesDictionaryHelper.PrintCollections(multiStringValuesDictionary.Keys);
                                break;

                            case "MEMBERS":
                                MultiValuesDictionaryHelper.PrintCollections(multiStringValuesDictionary.Members(commandItems[1]));
                                break;

                            case "ADD":
                                multiStringValuesDictionary.Add(commandItems[1], commandItems[2]);
                                Console.WriteLine(") Added");
                                break;

                            case "REMOVE":
                                MultiValuesDictionaryHelper.Remove(commandItems, multiStringValuesDictionary);
                                break;

                            case "REMOVEALL":
                                multiStringValuesDictionary.Remove(commandItems[1]);
                                Console.WriteLine(") Removed");
                                break;

                            case "CLEAR":
                                multiStringValuesDictionary.Clear();
                                Console.WriteLine(") Cleared");
                                break;

                            case "KEYEXISTS":
                                Console.WriteLine($") {multiStringValuesDictionary.KeyExists(commandItems[1]).ToString().ToLower()}");
                                break;

                            case "MEMBEREXISTS":
                                Console.WriteLine($") {multiStringValuesDictionary.MemberExists(commandItems[1], commandItems[2]).ToString().ToLower()}");
                                break;

                            case "ALLMEMBERS":
                                MultiValuesDictionaryHelper.PrintCollectionsOfCollections(multiStringValuesDictionary.AllMembers());
                                break;

                            case "ITEMS":
                                MultiValuesDictionaryHelper.PrintPairedValueCollections(multiStringValuesDictionary.Items());
                                break;

                            case "EXIT":
                                Exit();
                                break;

                            default:
                                Console.WriteLine("Invalid command.");
                                break;
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
            }
        }
        private static void Exit()
        {
            Console.Write("Are you sure, you want to exit the application? (y/n): ");
            var userInput = Console.ReadLine();
            if (userInput.ToUpper() == "Y" || userInput.ToUpper() == "YES")
                Environment.Exit(0);
            else if (userInput.ToUpper() == "N" || userInput.ToUpper() == "NO")
                return;
            else
                Exit();
        }
    }
}
