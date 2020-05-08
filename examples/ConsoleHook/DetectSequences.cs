// This code is distributed under MIT license.
// Copyright (c) 2010-2018 George Mamaladze
// See license.txt or https://mit-license.org/

using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleHook
{
    internal class DetectSequences
    {
        public static void Do(Action quit)
        {
            Action writeLine = () => Console.WriteLine("Control+Z,B序列快捷");
            var map = new Dictionary<Sequence, Action>
            {
                {Sequence.FromString("Control+Z,B"), new Action(() =>
                            Console.WriteLine("Control+Z,B序列快捷"))},
                {Sequence.FromString("Control+Z,Z"), new Action(() =>
                            Console.WriteLine("Control+Z,Z序列快捷"))},
                {Sequence.FromString("Escape,Escape,Escape"), quit}
            };

            Console.WriteLine("Detecting following combinations:");
            foreach (var sequence in map.Keys)
            {
                Console.WriteLine("\t{0}", sequence);
            }

            Console.WriteLine("Press 3 x ESC (three times) to exit.");

            //Actual loop
            Hook.GlobalEvents().OnSequence(map);
        }
    }
}