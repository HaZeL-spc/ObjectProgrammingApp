using lab2.commands;
using lab2.eigth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using zadanie.second;

namespace zadanie
{
    public class Program
    {
        static Double Eval(String expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty));
        }
        public static void WriteObj(IGame[] obj)
        {
            foreach (var game in obj)
            {
                var listReviews = game.Reviews;

                if (listReviews != null)
                {
                    int average = 0;
                    int howMany = 0;

                    foreach (var review in listReviews)
                    {
                        average += review.Rating;
                        howMany++;
                    }

                    if (howMany != 0 && average / howMany >= 10)
                    {
                        Console.WriteLine($"nazwa: {game.Name}, gatunek: {game.Genre}, srednia ocen: {average / howMany}, recenzje:");
                        foreach (var review in listReviews)
                        {
                            Console.WriteLine($"- {review.Text}");
                        }

                        Console.WriteLine();
                    }
                }

            }
        }

        public static void Main(string[] args)
        {
            Game[] games =
            {
                new Game("Garbage Collector", "simulation", new List<int>{ }, new List<int> {}, new List<int>{1}, "PC" ),
                new Game("Universe of Technology", "4X", new List<int>{}, new List<int>{3}, new List<int>{1, 3}, "bitnix" ),
                new Game("Moo, rogue-like", "rogue-like", new List<int>{2}, new List<int>{2, 4}, new List<int>{1,2,3}, "bitstation" ),
                new Game("Tickets Please", "platformer", new List<int>{1}, new List<int>{1}, new List<int>{1,3,4}, "bitbox" ),
                new Game("Cosmic", "MOBA", new List<int>{5}, new List<int>{5}, new List<int>{1,5}, "cross platform" )
            };

            User[] users =
            {
                new User("Szredor", new List<int>{1,2,3,4,5}),
                new User("Driver", new List<int>{1,2,3,4,5}),
                new User("Pek", new List<int>{1,2,3,4,5}),
                new User("Commander Shepard", new List<int>{1,2,4}),
                new User("MLG", new List<int>{1,5}),
                new User("Rondo", new List<int>{1}),
                new User("lemon", new List<int>{3,4}),
                new User("Bonet", new List<int>{2})
            };

            Review[] reviews =
            {
                new Review("I’m Commander Shepard and this is my favorite game on Smoke", 10, 4),
                new Review("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, 2),
                new Review("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.",15, 7 ),
                new Review("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, 8),
                new Review("I've played this game for years nonstop. Over 8k hours logged (not even joking). And I'm gonna tell you: at this point, the game's just not worth playing anymore. I think it hasn't been worth playing for a year or two now, but I'm only just starting to realize it. It breaks my heart to say that, but that's just the truth of the matter.", 5, 1)
            };

            Mod[] mods =
            {
                new Mod("Clouds", "Super clouds", new List<int>{3}, new List<int>{2,3,4,5}),
                new Mod("T-pose", "Cow are now T-posing", new List<int>{6}, new List<int>{1,3}),
                new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new List<int>{4}, new List<int>{1,2,4}),
                new Mod("BTM", "You can now play in BTM’s trains and bytebuses", new List<int>{7,8}, new List<int>{1,3}),
                new Mod("Cosmic - black hole edition", "Adds REALISTIC black holes", new List<int>{2}, new List<int>{1})
            };

            TextGame[] gamesText =
            {
                new TextGame("Garbage Collector", "simulation", new List<string>{ }, new List<int> {}, new List<string>{"Clouds"}, "PC"),
                new TextGame("Universe of Technology", "4X", new List<string>{}, new List<int>{103}, new List<string>{"Clouds", "Commander Shepard"}, "bitnix" ),
                new TextGame("Moo", "rogue-like", new List<string>{"Driver"}, new List<int>{102, 104}, new List<string>{"Clouds", "T-pose","Commander Shepard"}, "bitstation"),
                new TextGame("Tickets Please", "platformer", new List<string>{"Szredor"}, new List<int>{101}, new List<string>{"Clouds", "Commander Shepard", "BTM"}, "bitbox"),
                new TextGame("Cosmic", "MOBA", new List<string>{"MLG"}, new List<int>{105}, new List<string>{"Clouds","Cosmic - black hole edition"}, "cross platform")
            };

            TextUser[] usersText =
            {
                new TextUser("Szredor", new List<string>{"Garbage Collector", "Universe of Technology", "Moo", "Tickets Please", "Cosmic"}),
                new TextUser("Driver", new List<string>{"Garbage Collector", "Universe of Technology", "Moo", "Tickets Please", "Cosmic"}),
                new TextUser("Pek", new List<string>{"Garbage Collector", "Universe of Technology", "Moo", "Tickets Please", "Cosmic"}),
                new TextUser("Commander Shepard", new List<string>{"Garbage Collector", "Universe of Technology", "Tickets Please"}),
                new TextUser("MLG", new List<string>{"Garbage Collector", "Cosmic"}),
                new TextUser("Rondo", new List<string>{"Garbage Collector"}),
                new TextUser("lemon", new List<string>{"Moo", "Tickets Please"}),
                new TextUser("Bonet", new List<string>{"Universe of Technology"})
            };

            TextReview[] reviewsText =
            {
                new TextReview("I’m Commander Shepard and this is my favorite game on Smoke", 10, "Commander Shepard"),
                new TextReview("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, "Driver"),
                new TextReview("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.",15, "lemon" ),
                new TextReview("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, "Bonet"),
                new TextReview("I've played this game for years nonstop. Over 8k hours logged (not even joking). And I'm gonna tell you: at this point, the game's just not worth playing anymore. I think it hasn't been worth playing for a year or two now, but I'm only just starting to realize it. It breaks my heart to say that, but that's just the truth of the matter.", 5, "Szredor")
            };

            TextMod[] modsText =
            {
                new TextMod("Clouds", "Super clouds", new List<string>{"Pek"}, new List<string>{"T-pose", "Commander Shepard", "BTM", "Cosmic - black hole edition"}),
                new TextMod("T-pose", "Cow are now T-posing", new List<string>{"Rondo"}, new List<string>{"Clouds", "Commander Shepard"}),
                new TextMod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new List<string>{"Commander Shepard"}, new List<string>{"Clouds", "T-pose", "BTM"}),
                new TextMod("BTM", "You can now play in BTM’s trains and bytebuses", new List<string>{"lemon","Bonet"}, new List<string> { "Clouds", "Commander Shepard" }),
                new TextMod("Cosmic - black hole edition", "Adds REALISTIC black holes", new List<string>{"Driver"}, new List<string>{})
            };

            //var info = Tuple.Create(1, TupleGameAdapter.ChangeToStack("Garbage Collector", "simulation", new List<int> { }, new List<int> { }, new List<int> { 201 }, "PC"));

            TupleGame[] gamesTuple =
            {
                new TupleGame("Garbage Collector", "simulation", new List<int> { }, new List<int> { }, new List<int> { 201 }, "PC", 1),
                new TupleGame("Universe of Technology", "4X", new List<int>{}, new List<int>{203}, new List<int>{201, 204}, "bitnix",2 ),
                new TupleGame("Moo", "rogue-like", new List<int>{202}, new List<int>{202, 204}, new List<int>{201, 202, 203}, "bitstation",3 ),
                new TupleGame("Tickets Please", "platformer", new List<int>{201}, new List<int>{201}, new List<int>{201, 203, 204}, "bitbox",4 ),
                new TupleGame("Cosmic", "MOBA", new List<int>{205}, new List<int>{205}, new List<int>{201,205}, "cross platform",5)
            };

            TupleUser[] usersTuple = {
                new TupleUser("Szredor", new List<int>{201,202,203,204,205},1),
                new TupleUser("Driver", new List<int>{201,202,203,204,205},2),
                new TupleUser("Pek", new List<int>{201,202,203,204,205},3),
                new TupleUser("Commander Shepard", new List<int>{201,202,204},4),
                new TupleUser("MLG", new List<int>{201,205},5),
                new TupleUser("Rondo", new List<int>{201},6),
                new TupleUser("lemon", new List<int>{203,204},7),
                new TupleUser("Bonet", new List<int>{202},8)
            };

            TupleReview[] reviewsTuple =
            {
                new TupleReview("I’m Commander Shepard and this is my favorite game on Smoke", 10, 204,1),
                new TupleReview("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, 202,2),
                new TupleReview("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.",15, 207,3 ),
                new TupleReview("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, 208,4),
                new TupleReview("I've played this game for years nonstop. Over 8k hours logged (not even joking). And I'm gonna tell you: at this point, the game's just not worth playing anymore. I think it hasn't been worth playing for a year or two now, but I'm only just starting to realize it. It breaks my heart to say that, but that's just the truth of the matter.", 5, 201,5)
            };

            TupleMod[] modsTuple =
{
                new TupleMod("Clouds", "Super clouds", new List<int>{203}, new List<int>{202,203,204,205},1),
                new TupleMod("T-pose", "Cow are now T-posing", new List<int>{206}, new List<int>{201,203},2),
                new TupleMod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new List<int>{204}, new List<int>{201,202,204},3),
                new TupleMod("BTM", "You can now play in BTM’s trains and bytebuses", new List<int>{207,208}, new List<int>{201, 203},4),
                new TupleMod("Cosmic - black hole edition", "Adds REALISTIC black holes", new List<int>{202}, new List<int>{201},5)
            };


            for (int i = 0; i < games.Length; i++)
            {
                GlobalDictionaries.games.Add(i + 1, games[i]);
                GlobalDictionaries.games.Add(101 + i, new TextGameAdapter(gamesText[i]));
                GlobalDictionaries.games.Add(201 + i, new TupleGameAdapter(gamesTuple[i]));
            }

            for (int i = 0; i < users.Length; i++)
            {
                GlobalDictionaries.users.Add(i + 1, users[i]);
                GlobalDictionaries.users.Add(101 + i, new TextUserAdapter(usersText[i]));
                GlobalDictionaries.users.Add(201 + i, new TupleUserAdapter(usersTuple[i]));
            }

            for (int i = 0; i < reviews.Length; i++)
            {
                GlobalDictionaries.reviews.Add(i + 1, reviews[i]);
                GlobalDictionaries.reviews.Add(101 + i, new TextReviewAdapter(reviewsText[i]));
                GlobalDictionaries.reviews.Add(201 + i, new TupleReviewAdapter(reviewsTuple[i]));
            }

            for (int i = 0; i < mods.Length; i++)
            {
                GlobalDictionaries.mods.Add(i + 1, mods[i]);
                GlobalDictionaries.mods.Add(101 + i, new TextModAdapter(modsText[i]));
                GlobalDictionaries.mods.Add(201 + i, new TupleModAdapter(modsTuple[i]));
            }




            //WriteObj(games);
            //Console.WriteLine("---------------------------- TEXT --------------------------------");

            ////
            //// 
            //IGame[] gamesTextI = new IGame[] { GlobalDictionaries.games[101], GlobalDictionaries.games[102], GlobalDictionaries.games[103], GlobalDictionaries.games[104], GlobalDictionaries.games[105] };

            //WriteObj(gamesTextI);

            //Console.WriteLine("---------------------------- TUPLE --------------------------------");


            //IGame[] gamesTupleI = new IGame[] { GlobalDictionaries.games[201], GlobalDictionaries.games[202], GlobalDictionaries.games[203], GlobalDictionaries.games[204], GlobalDictionaries.games[205] };
            //WriteObj(gamesTupleI);

            //for (int i = 0; i < 5; i++)
            //{
            //    var element = GlobalDictionaries.mods[101 + i].Authors;
            //    Console.WriteLine(element.Count);
            //}


            // Create a dictionary that maps strings to binary trees
            //Dictionary<string, BinaryTree<object>> treeDict = new Dictionary<string, BinaryTree<object>>();
            //Dictionary<string, BinaryTree<object>> treeDictTuple = new Dictionary<string, BinaryTree<object>>();
            GlobalDictionaries.treeDict["review"] = new BinaryTree<object>();
            GlobalDictionaries.treeDictTuple["review"] = new BinaryTree<object>();
            for (int i = 0; i < 5; i++)
            {
                GlobalDictionaries.treeDict["review"].Insert(GlobalDictionaries.reviews[1 + i]);
                GlobalDictionaries.treeDictTuple["review"].Insert(GlobalDictionaries.reviews[101 + i]);
            }
            GlobalDictionaries.treeDict["game"] = new BinaryTree<object>();
            GlobalDictionaries.treeDictTuple["game"] = new BinaryTree<object>();
            for (int i = 0; i < 5; i++)
            {
                GlobalDictionaries.treeDict["game"].Insert(GlobalDictionaries.games[1 + i]);
                GlobalDictionaries.treeDictTuple["game"].Insert(GlobalDictionaries.games[101 + i]);
            }
            GlobalDictionaries.treeDict["mod"] = new BinaryTree<object>();
            GlobalDictionaries.treeDictTuple["mod"] = new BinaryTree<object>();
            for (int i = 0; i < 5; i++)
            {
                GlobalDictionaries.treeDict["mod"].Insert(GlobalDictionaries.mods[1 + i]);
                GlobalDictionaries.treeDictTuple["mod"].Insert(GlobalDictionaries.mods[101 + i]);
            }

            GlobalDictionaries.treeDict["user"] = new BinaryTree<object>();
            GlobalDictionaries.treeDictTuple["user"] = new BinaryTree<object>();
            for (int i = 0; i < 8; i++)
            {
                GlobalDictionaries.treeDict["user"].Insert(GlobalDictionaries.users[1 + i]);
                GlobalDictionaries.treeDictTuple["user"].Insert(GlobalDictionaries.users[101 + i]);
            }

            GlobalDictionaries.TypesBinaryTree["base"] = GlobalDictionaries.treeDict;
            GlobalDictionaries.TypesBinaryTree["secondary"] = GlobalDictionaries.treeDictTuple;

            GlobalDictionaries.communications["game"] = "[Available fields: 'name, genre, devices']";
            GlobalDictionaries.communications["mod"] = "[Available fields: 'name, description']";
            GlobalDictionaries.communications["review"] = "[Available fields: 'text, rating']";
            GlobalDictionaries.communications["user"] = "[Available fields: 'nickname']";

            GlobalDictionaries.defaultGame["Name"] = "unknown";
            GlobalDictionaries.defaultGame["Genre"] = "unknown";
            GlobalDictionaries.defaultGame["Devices"] = "PC";

            GlobalDictionaries.defaultReview["Text"] = "unknown";
            GlobalDictionaries.defaultReview["Rating"] = 0;

            GlobalDictionaries.defaultMod["Name"] = "unknown";
            GlobalDictionaries.defaultMod["Description"] = "unknown";

            GlobalDictionaries.defaultUser["Nickname"] = "unknown";

            GlobalDictionaries.defaultValues["game"] = GlobalDictionaries.defaultGame;
            GlobalDictionaries.defaultValues["mod"] = GlobalDictionaries.defaultMod;
            GlobalDictionaries.defaultValues["review"] = GlobalDictionaries.defaultReview;
            GlobalDictionaries.defaultValues["user"] = GlobalDictionaries.defaultUser;

            CommandCustom commandsList = new CommandCustom();


            while (true)
            {
                string input = Console.ReadLine();
                string[] substrings = input.Split(' ');

                if (substrings[0] == "list")
                {
                    ICommandCustom listEl = new ListCommand(substrings[1]);

                    commandsList.AddData(listEl, "list");
                    //commandsList.Execute();
                }
                else if (substrings[0] == "find")
                {
                    ICommandCustom findEl = new FindCommand(substrings);
                    commandsList.AddData(findEl, "find");
                    //commandsList.Execute();

                    //var result = Eval.Execute();

                } else if (substrings[0] == "add")
                {
                    ICommandCustom addEl = new AddCommand(substrings);

                    commandsList.AddData(addEl, "add");
                    //commandsList.Execute();


                } else if (substrings[0] == "edit")
                {
                    //var obj = GlobalDictionaries.treeDict[substrings[1]];

                    //for (int i = 2; i < substrings.Length; i = i++)
                    //{

                    //}
                    ICommandCustom editEl = new EditCommand(substrings);
                    commandsList.AddData(editEl, "edit");
                    //commandsList.Execute();
                
                } else if (substrings[0] == "delete")
                {
                    ICommandCustom deleteEl = new DeleteCommand(substrings);
                    commandsList.AddData(deleteEl, "delete");
                    

                } else if (substrings[0] + " " + substrings[1] == "queue print")
                {
                    commandsList.PrintData();
                } else if (substrings[0] + " " + substrings[1] == "queue commit")
                {
                    commandsList.Execute();
                    commandsList.Clear();
                } else if (substrings[0] + " " + substrings[1] == "queue dismiss")
                {
                    commandsList.Clear();
                } else if (substrings[0] + " " + substrings[1] == "queue export")
                {
                    commandsList.Export(substrings[2], substrings[3]);
                }
                else if (substrings[0] == "exit")
                {
                    break;
                }
            }

            //treeGamesText.Delete(GlobalDictionaries.reviews[103]);
            ////treeGamesText.Delete(GlobalDictionaries.reviews[101]);

            //Console.WriteLine("\n-------------------------------------------\n");

            //foreach (var el in treeGamesText.GetEnumerator())
            //{
            //    Console.WriteLine($"name: {el.Rating}, genre: {el.Text}");
            //}
            //Console.WriteLine("\n-------------------------------------------\n");

            //treeGamesText.Delete(GlobalDictionaries.reviews[104]);
            //treeGamesText.Delete(GlobalDictionaries.reviews[102]);

            //foreach (var el in treeGamesText.GetEnumerator())
            //{
            //    Console.WriteLine($"name: {el.Rating}, genre: {el.Text}");
            //}

            //Console.WriteLine("\n-------------------------------------------\n");

            //foreach (var el in treeGamesText.GetReverseEnumerator())
            //{
            //    Console.WriteLine($"name: {el.Rating}, genre: {el.Text}, rating: {el.Rating}");
            //}

            //Console.WriteLine("\n-------------------------------------------\n");

            //foreach (var element in  treeDict["game"].GetEnumerator())
            //{
            //    IGame mmm = (IGame)element;
                
            //}

            //var result = BinaryTreeExtensions.Find(treeDict["game"].GetEnumerator(), x => x.Rating == 10);
            //Console.WriteLine();
            //if (result != null)
            //    Console.WriteLine($"name: {result.Rating}, genre: {result.Text}, rating: {result.Rating}\n");

            //Console.WriteLine();
            //Console.WriteLine("\n-------------------------------------------\n");
            //BinaryTreeExtensions.ForEach(treeGamesText.GetEnumerator(), x => Console.WriteLine($"moj text to {x.Text}"));


            //Console.WriteLine("\n-------------------------------------------\n");
            //int count = BinaryTreeExtensions.CountIf(treeGamesText.GetEnumerator(), x => x.Rating == 10);
            //Console.WriteLine($"znajduje sie {count} elementow o ratingu 10\n");
            //BinaryTreeExtensions.Print(treeGamesText.GetEnumerator(), x => x.Rating >= 10);


            //BinaryTree<IGame> treeGamesText = new BinaryTree<IGame> { };
            //treeGamesText.Insert(GlobalDictionaries.games[201]);
            //treeGamesText.Insert(GlobalDictionaries.games[202]);
            //treeGamesText.Insert(GlobalDictionaries.games[203]);
            //treeGamesText.Insert(GlobalDictionaries.games[204]);

            //foreach (var el in treeGamesText.GetReverseEnumerator())
            //{
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            //foreach (var el in treeGamesText.GetEnumerator())
            //{
            //    Console.WriteLine(el.Name);
            //}

            //var result = BinaryTreeExtensions.Find(treeGamesText.GetEnumerator(), x => x.Reviews.Count == 0);
            //Console.WriteLine();
            //if (result != null)
            //    Console.WriteLine(result.Name);
        }
    }
}
