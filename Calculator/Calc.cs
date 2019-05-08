using System;

namespace Calculator
{
    public class Calc
    {
        /// <summary>
        /// Calculate chance of occurrence.
        /// </summary>
        /// <param name="maxProbability">Max possibility of occurrence.</param>
        /// <param name="minProbability">Floor chance of victory</param>
        /// <param name="priorWinCount">Count of prior wins.</param>
        /// <param name="maxRewards">Max rewards before min value is permanent</param>
        /// <returns></returns>
        public double StraightLineWithCeilingAndFloor(double maxProbability, double minProbability, int priorWinCount, int maxRewards)
        {
            // Find total range
            var range = maxProbability - minProbability;
            double sizeOfChunk = range / maxRewards;

            double p = minProbability + (sizeOfChunk * (1 - (priorWinCount / maxRewards)));

            return p;
        }

        /// <summary>
        /// Implements the algorithm y = <paramref name="width"/>(x ^ <paramref name="power"/>) + <paramref name="maxProbability"/>,
        /// where x will be the progress from 0 <paramref name="priorWinCount"/> to <paramref name="maxRewards"/>
        /// with a ceiling of <paramref name="maxProbability"/> and a floor of <paramref name="minProbability"/>
        /// </summary>
        /// <param name="maxProbability"></param>
        /// <param name="minProbability"></param>
        /// <param name="priorWinCount"></param>
        /// <param name="maxRewards"></param>
        /// <param name="width"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public double JasonAlg(double maxProbability, double minProbability, double priorWinCount, double maxRewards)
        {
            double percentUsed = Math.Min(1, (priorWinCount / maxRewards));
            double xAtFloor = this.findXAtFloor(maxProbability, minProbability);

            double x = percentUsed * xAtFloor;
            double result = -.01 * (Math.Pow(x, 2)) + (maxProbability * (1 - percentUsed));          

            var minPinched = Math.Max(minProbability, result);
            var maxPinched = Math.Min(maxProbability, minPinched);
            return maxPinched;
        }

        private double findXAtFloor(double maxProbability, double minProbability)
        {
            double middleResult = (minProbability - maxProbability) / (-1);
            return Math.Pow(middleResult, (double)(1d / 2));
        }     
    }
}