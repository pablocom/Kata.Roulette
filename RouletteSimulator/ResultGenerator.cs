using System;

namespace RouletteSimulator
{
    public class ResultGenerator : IResultGenerator
    {
        public int GenerateRandomResult() => new Random().Next(0, 36);
    }
}