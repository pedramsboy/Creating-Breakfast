﻿using System;
using System.Diagnostics;
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

        static async Task Main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1; i++)
            {
                Coffee cup = PourCoffee();
                Console.WriteLine("Coffee is ready !!!");

                Task<Egg> eggsTask = FryEggAsync(2);
                Task<Bacon> baconsTask = FryBaconAsync(3);
                Task<Toast> toastTask = ToastingBreadWithButterAndJamAsync(2);

                var breakfastTasks = new List<Task> { eggsTask, baconsTask, toastTask };
                while (breakfastTasks.Count > 0)
                {
                    Task finishedTask = await Task.WhenAny(breakfastTasks);
                    if (finishedTask == eggsTask)
                        Console.WriteLine("Eggs are ready !!!");
                    else if (finishedTask == baconsTask)
                        Console.WriteLine("Bacons are ready !!!");
                    else if (finishedTask == toastTask)
                        Console.WriteLine("Toasts are ready!!!");
                    await finishedTask;
                    breakfastTasks.Remove(finishedTask);
                }

                Juice glass = PourJuice();
                Console.WriteLine("Juice is ready!!!");

                Egg eggs = await eggsTask;
                Console.WriteLine("Eggs are ready !!!");

                Bacon bcons = await baconsTask;
                Console.WriteLine("Bacons are ready !!!");

                Toast toasts = await toastTask;
                Console.WriteLine("Toasts are ready!!!");

                Console.WriteLine("Your breakfast is ready !!!");
            }

            watch.Stop();

            Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms");
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Your Coffe is pouring into the cup");
            Task.Delay(500).Wait();
            return new Coffee();
        }

        private static async Task<Egg> FryEggAsync(int eggs)
        {
            Console.WriteLine("Warming The Pan");
            await Task.Delay(3000);
            Console.WriteLine($"Crack {eggs} eggs into the pan");
            await Task.Delay(1000);
            Console.WriteLine("cooking the eggs");
            await Task.Delay(3000);
            Console.WriteLine("Put fried eggs on the plate");

            return new Egg();
        }

        private static async Task<Bacon> FryBaconAsync(int bacons)
        {
            Console.WriteLine("Warming the pan");
            await Task.Delay(3000);
            Console.WriteLine($"Putting {bacons} bacons into the pan");
            await Task.Delay(1000);
            Console.WriteLine("Cooking the first side of the bacons");
            await Task.Delay(3000);

            for (int baconSlice = 0; baconSlice < bacons; baconSlice++)
            {
                Console.WriteLine("flipping a slice of bacon");
                await Task.Delay(1000);
            }

            Console.WriteLine("Cooking the second side of the bacons");
            await Task.Delay(3000);
            Console.WriteLine("Put fried bacons on the plate");

            return new Bacon();
        }

        private static async Task<Toast> ToastingBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("putting slice of bread into the toaster");
                await Task.Delay(300);
            }

            Console.WriteLine("Start Toasting");
            await Task.Delay(3000);
            Console.WriteLine("Put Toasted Slices on the Plate");

            return new Toast();
        }

        private static async Task<Toast> ToastingBreadWithButterAndJamAsync(int slices)
        {
            Toast toast = await ToastingBreadAsync(slices);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
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