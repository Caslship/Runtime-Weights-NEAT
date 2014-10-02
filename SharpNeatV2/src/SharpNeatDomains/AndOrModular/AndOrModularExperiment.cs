using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpNeat.Domains;
using SharpNeat.Phenomes;
using SharpNeat.Core;

namespace SharpNeat.Domains.AndOrModular
{
    public class AndOrModularExperiment : SimpleNeatExperiment
    {
        public override IPhenomeEvaluator<IBlackBox> PhenomeEvaluator
        {
            get { return new AndOrModularEvaluator(); }
        }

        public override int InputCount
        {
            get { return 3; }
        }

        public override int OutputCount
        {
            get { return 1; }
        }

        public override bool EvaluateParents
        {
            get { return false; }
        }

        public override AbstractGenomeView CreateGenomeView()
        {
            return new NeatGenomeView();
        }
    }
}
