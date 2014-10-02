using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpNeat.Core;
using SharpNeat.Phenomes;

namespace SharpNeat.Domains.AndOrModular
{
    public class AndOrModularEvaluator : IPhenomeEvaluator<IBlackBox>
    {
        private ulong _evalCount;
        private bool _stopConditionSatisfied;

        #region IPhenomeEvaluator<IBlackBox> Members

        public ulong EvaluationCount
        {
            get { return _evalCount; }
        }

        public bool StopConditionSatisfied
        {
            get { return _stopConditionSatisfied; }
        }

        public FitnessInfo Evaluate(IBlackBox box)
        {
            // This takes a lot of inspiration from SharpNeatDomains/Xor/XorBlackBoxEvaluator.cs
            // These variables are used to determine fitness and adjust for error that occurs from using double values and binary operators
            double fitness = 0.0;
            double pass = 1.0;
            
            // Input 1 and 2 are numbers that will AND or OR together
            // Input 3 specifies which operation to use (0 = AND; 1 = OR)
            // Output is the result of the operation
            ISignalArray input = box.InputSignalArray;
            ISignalArray output = box.OutputSignalArray;

    // ---- Testing AND ----

            // 1 & 1 = 1
            box.ResetState();
            input[0] = 1.0;
            input[1] = 1.0;
            input[2] = 0.0; // AND
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - ((1.0 - output[0]) * (1.0 - output[0]));
            if (output[0] <= 0.5)
            {
                pass = 0.0;
            }

            // 1 & 0 = 0
            box.ResetState();
            input[0] = 1.0;
            input[1] = 0.0;
            input[2] = 0.0; // AND
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - (output[0] * output[0]);
            if (output[0] > 0.5)
            {
                pass = 0.0;
            }

            // 0 & 1 = 0
            box.ResetState();
            input[0] = 0.0;
            input[1] = 1.0;
            input[2] = 0.0; // AND
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - (output[0] * output[0]);
            if (output[0] > 0.5)
            {
                pass = 0.0;
            }

            // 0 & 0 = 0
            box.ResetState();
            input[0] = 0.0;
            input[1] = 0.0;
            input[2] = 0.0; // AND
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - (output[0] * output[0]);
            if (output[0] > 0.5)
            {
                pass = 0.0;
            }

    // ---- Testing OR ----

            // 1 | 1 = 1
            box.ResetState();
            input[0] = 1.0;
            input[1] = 1.0;
            input[2] = 1.0; // OR
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - ((1.0 - output[0]) * (1.0 - output[0]));
            if (output[0] <= 0.5)
            {
                pass = 0.0;
            }

            // 1 | 0 = 1
            box.ResetState();
            input[0] = 1.0;
            input[1] = 0.0;
            input[2] = 1.0; // OR
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - ((1.0 - output[0]) * (1.0 - output[0]));
            if (output[0] <= 0.5)
            {
                pass = 0.0;
            }

            // 0 | 1 = 1
            box.ResetState();
            input[0] = 0.0;
            input[1] = 1.0;
            input[2] = 1.0; // OR
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - ((1.0 - output[0]) * (1.0 - output[0]));
            if (output[0] <= 0.5)
            {
                pass = 0.0;
            }

            // 0 | 0 = 0
            box.ResetState();
            input[0] = 0.0;
            input[1] = 0.0;
            input[2] = 1.0; // OR
            box.Activate();
            if (!box.IsStateValid)
            {
                return FitnessInfo.Zero;
            }
            fitness += 1.0 - (output[0] * output[0]);
            if (output[0] > 0.5)
            {
                pass = 0.0;
            }

            // If all 8 situations were on the correct side of the threshold level, add 10.0 onto the fitness
            fitness += pass * 10.0;

            // Update the evaluation counter.
            _evalCount++;

            // Stop evaluating if the highest fitness was reached.
            if (fitness >= 18.0)
                _stopConditionSatisfied = true;

            // Return the fitness score
            return new FitnessInfo(fitness, fitness);
        }

        /// <summary>
        /// Reset the internal state of the evaluation scheme if any exists.
        /// </summary>
        public void Reset()
        {
        }
        #endregion
    }
}
