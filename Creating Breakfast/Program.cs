using System;
using System.Threading.Tasks;

namespace cockingAsyncBreakfast
{
    class Program
    {
        internal class Coffee { }
        internal class Egg { }
        internal class Bacon { }
        internal class Toast { }
        internal class Juice { }

        static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready !!!");

            Egg eggs = FryEgg(2);
            Console.WriteLine("Eggs are ready !!!");

            Bacon bcons = FryBacon(3);
            Console.WriteLine("Bacons are ready !!!");

            Toast toast = ToastingBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toasts are ready!!!");

            Juice glass = PourJuice();
            Console.WriteLine("Juice is ready!!!");

            Console.WriteLine("Your breakfast is ready !!!");
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Your Coffe is pouring into the cup");
            Task.Delay(500).Wait();
            return new Coffee();
        }

        private static Egg FryEgg(int eggs)
        {
            Console.WriteLine("Warming The Pan");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Crack {eggs} eggs into the pan");
            Task.Delay(1000).Wait();
            Console.WriteLine("cooking the eggs");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put fried eggs on the plate");

            return new Egg();
        }

        private static Bacon FryBacon(int bacons)
        {
            Console.WriteLine("Warming the pan");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Putting {bacons} bacons into the pan");
            Task.Delay(1000).Wait();
            Console.WriteLine("Cooking the first side of the bacons");
            Task.Delay(3000).Wait();

            for (int baconSlice = 0; baconSlice < bacons; baconSlice++)
            {
                Console.WriteLine("flipping a slice of bacon");
                Task.Delay(1000).Wait();
            }

            Console.WriteLine("Cooking the second side of the bacons");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put fried bacons on the plate");

            return new Bacon();
        }

        private static Toast ToastingBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("putting slice of bread into the toaster");
                Task.Delay(300).Wait();
            }

            Console.WriteLine("Start Toasting");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put Toasted Slices on the Plate");

            return new Toast();
        }

        private static void ApplyButter(Toast tost) =>
            Console.WriteLine("Apply butter on the slices");

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Apply jam on the slices");

        private static Juice PourJuice()
        {
            Console.WriteLine("Pouring orange juice into the glass");
            Task.Delay(500).Wait();
            return new Juice();
        }
    }
}