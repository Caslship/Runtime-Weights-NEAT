using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using log4net.Config;
using SharpNeat.Core;
using SharpNeat.Domains.AndOrModular;
using SharpNeat.EvolutionAlgorithms;
using SharpNeat.Genomes.Neat;

namespace ModularBehavior
{
    class Program
    {
        static NeatEvolutionAlgorithm<NeatGenome> _ea;

        static void Main(string[] args)
        {
            // Initialise log4net (log to console).
            XmlConfigurator.Configure(new FileInfo("log4net.properties"));

            // Create a "AND-OR Modular Behavior" experiment.
            AndOrModularExperiment experiment = new AndOrModularExperiment();

            // Load config XML and initialize experiment with Runtime Weights Extension enabled.
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load("andormodular.config.xml");
            experiment.Initialize("And-Or-Modular", xmlConfig.DocumentElement/*, true*/);

            // Create evolution algorithm.
            _ea = experiment.CreateEvolutionAlgorithm();
            _ea.UpdateEvent += new EventHandler(ea_UpdateEvent);

            // Start algorithm (it will run on a background thread).
            _ea.StartContinue();

            // Hit return to quit.
            Console.ReadLine();
        }

        static void ea_UpdateEvent(object sender, EventArgs e)
        {
            // Indicate whether the champ genome contains runtime weights
            ConnectionGeneList ChampGenomeConnections = _ea.CurrentChampGenome.ConnectionGeneList;
            foreach (ConnectionGene connection in ChampGenomeConnections)
            {
                if (connection.RuntimeWeightSourceFlag || connection.RuntimeWeightTargetFlag)
                {
                    Console.WriteLine("Champ genome is using runtime weights!!");
                    break;
                }
            }
            // Write the current generation and the best fitness to the console
            Console.WriteLine(string.Format("gen={0:N0} bestFitness={1:N6}", _ea.CurrentGeneration, _ea.Statistics._maxFitness));
        }
    }
}
