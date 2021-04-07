using System;

namespace RoshamboMark2
{
    enum Roshambo
    {
        rock,
        paper,
        scissors
    }

    abstract class Player
    {
        public string playerName;
        public Roshambo choice;

        public virtual Roshambo GenerateRoshambo(string input)
        {

            return Roshambo.paper;
        }
    }

    class RockAndRollBaby : Player
    {
        public override Roshambo GenerateRoshambo(string input)
        {
            choice = Roshambo.rock;
            return choice;
        }
    }

    class Wildcard : Player
    {
        public static Random rand = new Random();

        public override Roshambo GenerateRoshambo(string input)
        {
            int temp = rand.Next(0, 3);

            choice = (Roshambo)temp;   //casting int temp into roshambo

            return choice;
        }

    }

    class FleshBag : Player
    {
        public override Roshambo GenerateRoshambo(string input)
        {
            if (input == "r" || input == "rock")
            {
                choice = Roshambo.rock;

            }
            else if (input == "p" || input == "paper")
            {
                choice = Roshambo.paper;
            }
            else
            {
                choice = Roshambo.scissors;
            }
            return choice;
        }
    }
    class Program
    {
        public static FleshBag Human = new FleshBag();
        public static Roshambo HumanChoice;
        public static RockAndRollBaby SadRock = new RockAndRollBaby();
        Roshambo SadRockChoice = SadRock.GenerateRoshambo("hello");
        
        public static Wildcard CrazyBilly = new Wildcard();
        Roshambo CrazyBillyChoice = CrazyBilly.GenerateRoshambo("nice day");
        public static int humanScore;
        public static int sadRockScore;
        public static int crazyBillyScore;
        public static int tie;
        
        static void Main(string[] args)
        {
            bool loop = true;
            int against;


            Console.WindowHeight = 46;
            SadRock.playerName = "Sad Rock";
            CrazyBilly.playerName = "Crazy Billy";

            //Console.WriteLine(SadRockChoice);

            //Console.WriteLine(CrazyBillyChoice);


            //Match(SadRock, CrazyBilly);

            Console.WriteLine("Welcome to ROSHAMBO!\n\n");

            userNameInput();

            do
            {
                against = PlayWho();

                HumanDecision();

                Opponent(against);

                DisplayScore();

                loop = ContinueYN();
                Console.Clear();
            } while (loop);
        }

        static void DisplayScore()
        {
            Console.Write($"Current score:\n{Human.playerName}: {humanScore} points\nSad Rock: {sadRockScore} points\nCrazy Billy: {crazyBillyScore} points\n{tie} ties");
        }

        static void HumanDecision()
        {
            bool invalid = true;
            string input;

            do
            {
                Console.Write("\n\nPlay Rock, Paper, or Scissors? (r/p/s): ");
                input = Console.ReadLine().ToLower();

                if (input != "r" && input != "p" && input != "s" && input != "rock" && input != "paper" && input != "scissor" && input != "scissors")
                {
                    invalid = true;
                    InvalidMessages(3);
                }
                else
                {
                    invalid = false;
                }
               

            } while (invalid);

            HumanChoice = Human.GenerateRoshambo(input);
        }

        static void Opponent(int whichOpponent)
        {
            switch (whichOpponent)
            {
                case 1:
                    sadRockScore = sadRockScore + Match(Human, SadRock);

                    break;

                default:
                    crazyBillyScore = crazyBillyScore + Match(Human, CrazyBilly);
                    break;
            }
        }

        static int PlayWho()
        {
            string vs;
            bool invalid = true;
            int compPlayer = 1;

            do
            {

                Console.Write("\nWould you like to play against Sad Rock or Crazy Billy? (s/c): ");
                vs = Console.ReadLine().ToLower();

                if (vs != "s" && vs != "c" && vs != "sad" && vs != "sad rock" && vs != "rock" && vs != "crazy" && vs != "billy" && vs != "crazy billy")
                {
                    InvalidMessages(2);
                    invalid = true;
                }
                else if (vs == "s" || vs == "sad" || vs == "sad rock" || vs == "rock")
                {
                    invalid = false;
                    compPlayer = 1;

                }
                else
                {
                    invalid = false;
                    compPlayer = 2;
                }

            } while (invalid);

            return compPlayer;
        }
        static void InvalidMessages(int error)
        {
            switch (error)
            {
                case 1:
                    Console.Write($"\n\nThat was not a valid answer. Please enter either y or n. \n\n");

                    break;

                case 2:
                    Console.Write("\n\nThat was not a valid answer. Please enter either s or c.\n\n");

                    break;

                case 3:
                    Console.Write("\n\nThat was not a valid answer. Please enter either r or p or s.\n\n");
                    break;


            }
        }
        static bool ContinueYN()
        {
            bool loopAgain = true;

            string input;

            bool notvalid = true;

            do
            {
                Console.Write($"\n\nPlay Again? (y/n): ");
                input = Console.ReadLine().ToLower();

                if (input != "y" && input != "n")
                {
                    InvalidMessages(1);
                }
                else
                {
                    notvalid = false;

                    if (input == "n")
                    {
                        loopAgain = false;
                    }
                }
            } while (notvalid);

            return loopAgain;

        }

        static void userNameInput()
        {
            string input;

            Console.Write("Enter your name: ");
            input = Console.ReadLine();
            Human.playerName = input;


        }

        static int Match(Player alpha, Player beta)
        {
            int computerScore = 0;

            Console.Clear();
            Console.WriteLine($"{alpha.playerName} plays:");
            switch (alpha.choice)
            {
                case Roshambo.rock:
                    Rock();
                    break;
                case Roshambo.paper:
                    Paper();
                    break;
                case Roshambo.scissors:
                    Scissors();
                    break;
            }
            Console.WriteLine("\n");
            Console.Write("\t\t\t                ______\n");
            Console.Write("\t\t\t \\      /      /      \\\n");
            Console.Write("\t\t\t  \\    /       \\______\n");
            Console.Write("\t\t\t   \\  /               \\\n");
            Console.Write("\t\t\t    \\/         \\______/\n");
            Console.WriteLine("\n");

            Console.WriteLine($"{beta.playerName} plays:");
            switch (beta.choice)
            {
                case Roshambo.rock:
                    Rock();
                    break;
                case Roshambo.paper:
                    Paper();
                    break;
                case Roshambo.scissors:
                    Scissors();
                    break;
            }

            if (alpha.choice == beta.choice)    //both play the same thing
            {
                Console.WriteLine("\n\nTIE! No Winner!");
                tie += 1;
            }
            else if (alpha.choice == Roshambo.rock)    // alpha is rock
            {
                if (beta.choice == Roshambo.paper)       //beta is paper
                {
                    Console.WriteLine($"\n\n{beta.playerName} Wins!");
                    computerScore += 1;
                }
                else                                   //beta is scissors
                {
                    Console.WriteLine($"\n\n{alpha.playerName} Wins!");
                    humanScore += 1;
                }
            }
            else if (alpha.choice == Roshambo.paper)     //alpha is paper
            {
                if (beta.choice == Roshambo.rock)         //beta is rock
                {
                    Console.WriteLine($"\n\n{alpha.playerName} Wins!");
                    humanScore += 1;
                }
                else                                       //beta is scissors
                {
                    Console.WriteLine($"\n\n{beta.playerName} Wins!");
                    computerScore += 1;
                }
            }
            else                                          //alpha is scissors
            {
                if (beta.choice == Roshambo.paper)         //beta is paper
                {
                    Console.WriteLine($"\n\n{alpha.playerName} Wins!");
                    humanScore += 1;
                }
                else                                        //beta is rock
                {
                    Console.WriteLine($"\n\n{beta.playerName} Wins!");
                    computerScore += 1; 
                }
            }
            return computerScore;
        }

        static void Rock()
        {
            Console.WriteLine();
            Console.WriteLine(" RRRRRRRR         RRRR          RRRR      RR     RR   ");
            Console.WriteLine(" RRRRRRRRR      RRRRRRRR      RRRRRRRR    RR    RR");
            Console.WriteLine(" RR     RRR    RRR    RRR    RRR    RRR   RR   RR");
            Console.WriteLine(" RR      RR   RRR      RRR  RRR           RR  RR");
            Console.WriteLine(" RR     RRR   RR        RR  RR            RR RR");
            Console.WriteLine(" RRR   RRR    RR        RR  RR            RRRR");
            Console.WriteLine(" RRRRRRRRR    RR        RR  RR            RRRRR");
            Console.WriteLine(" RR     RRR   RRR      RRR  RRR           RR  RR");
            Console.WriteLine(" RR      RR    RRR    RRR    RRR    RRR   RR   RR");
            Console.WriteLine(" RR      RRR    RRRRRRRR      RRRRRRRR    RR    RR");
            Console.WriteLine(" RR       RR      RRRR          RRRR      RR     RR");
        }
        static void Paper()
        {
            Console.WriteLine();
            Console.WriteLine(" PPPPPPPP       P        PPPPPPP     PPPPPPPPPP  PPPPPPPP");
            Console.WriteLine(" PPPPPPPPP     PPP       PPPPPPPPP   PPPPPPPPPP  PPPPPPPPP");
            Console.WriteLine(" PP     PPP   PP PP      PP     PPP  PP          PP     PPP");
            Console.WriteLine(" PP      PP   PP PP      PP      PP  PP          PP      PP");
            Console.WriteLine(" PP     PPP  PP   PP     PP     PPP  PPPPP       PP     PPP");
            Console.WriteLine(" PPP   PPP   PP   PP     PPP   PPP   PPPPP       PPP   PPP");
            Console.WriteLine(" PPPPPPP    PPPPPPPPP    PPPPPPP     PP          PPPPPPPPP");
            Console.WriteLine(" PPPPP      PPPPPPPPP    PPPPP       PP          PP     PPP");
            Console.WriteLine(" PP        PPP     PPP   PP          PP          PP      PP");
            Console.WriteLine(" PP       PPP       PPP  PP          PPPPPPPPPP  PP      PPP");
            Console.WriteLine(" PP       PP         PP  PP          PPPPPPPPPP  PP       PP");
        }
        static void Scissors()
        {
            Console.WriteLine();
            Console.WriteLine("     SSSS          SSSS     SSSSSSSS     SSSS         SSSS          SSSS      SSSSSSSS        SSSS    ");
            Console.WriteLine("   SSS  SSS      SSSSSSSS   SSSSSSSS   SSS  SSS     SSS  SSS      SSSSSSSS    SSSSSSSSS     SSS  SSS  ");
            Console.WriteLine("  SSS    SSS    SSS    SSS     SS     SSS    SSS   SSS    SSS    SSS    SSS   SS     SSS   SSS    SSS  ");
            Console.WriteLine("  SSSS         SSS             SS     SSSS         SSSS         SSS      SSS  SS      SS   SSSS        ");
            Console.WriteLine("   SSSSSSS     SS              SS      SSSSSSS      SSSSSSS     SS        SS  SS     SSS    SSSSSSS    ");
            Console.WriteLine("    SSSSSSSS   SS              SS       SSSSSSSS     SSSSSSSS   SS        SS  SSS   SSS      SSSSSSSS  ");
            Console.WriteLine("         SSSS  SS              SS            SSSS         SSSS  SS        SS  SSSSSSSSS           SSSS ");
            Console.WriteLine("          SSS  SSS             SS             SSS          SSS  SSS      SSS  SS     SSS           SSS ");
            Console.WriteLine("  SSS    SSS    SSS    SSS     SS     SSS    SSS   SSS    SSS    SSS    SSS   SS      SS   SSS    SSS   ");
            Console.WriteLine("   SSS  SSS      SSSSSSSS   SSSSSSSS   SSS  SSS     SSS  SSS      SSSSSSSS    SS      SSS   SSS  SSS   ");
            Console.WriteLine("     SSSS          SSSS     SSSSSSSS     SSSS         SSSS          SSSS      SS       SS     SSSS      ");
        }

    }
}
