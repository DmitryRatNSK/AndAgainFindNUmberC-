using System;

class programm 
{
    static int input_range() {
        while (true)
        {
            Console.Write("You must to choose any positive range:");
            if (Int32.TryParse(Console.ReadLine(), out int range))
                return range;
            else
                Console.WriteLine("Validation ERROR, try again");
        }
    }


    static int input_trying(int try_number)
    {
        while (true)
        {
            Console.Write($"{try_number}th try: ");
            if (Int32.TryParse(Console.ReadLine(), out int trying))
                return trying;
            else
                Console.WriteLine("Validation ERROR, try again");
        }
    }

    static string input_hint() {
        while (true) 
        {
            Console.Write("Do you want a hint?(y/n): ");
            string hint_y_or_n = Console.ReadLine();
            if (hint_y_or_n != "y" && hint_y_or_n != "n")
            {
                Console.WriteLine("Validation ERROR, try again");
            }
            else return hint_y_or_n;
        }
    }

    static void more_or_less(int trying, int answer) {
        if (trying < answer)
        {
            Console.WriteLine($"answer more than {trying}");
        }
        else if (trying > answer){
            Console.WriteLine($"answer less than {trying}");
        }
    }

    static void Main() 
    {
        Random random_function = new Random();
        Console.WriteLine("Hello, this is the game THE FIND NUMBER");
        int range = input_range();
        int answer = random_function.Next() % range;
        int try_number = 1, hint_number = 1, half_range = range / 2;
        while (true) {
            int trying = input_trying(try_number);
            more_or_less(trying,answer);
            if ((try_number % 5) == 0 && answer != trying) {
                string hint_y_or_n = input_hint();
                if (hint_y_or_n == "y") {
                    switch (hint_number)
                    {
                        case 1:
                            if ((answer % 2) == 1)
                            {
                                Console.WriteLine("Answer is not even");
                            }
                            else { 
                                Console.WriteLine("Answer is even");
                            }
                            hint_number++;
                            break;
                        case 2:
                            Console.WriteLine($"Answer have {answer / 10} tens");
                            hint_number++;
                            break;
                        case 3:
                            Console.WriteLine($"Answer have {answer % 10} ones");
                            hint_number++;
                            break;
                    }
                }

            }
            if (trying == answer) {
                break;
            }
            try_number++;
        }
        Console.WriteLine($"You are won with {try_number}th trying");
    }

}
