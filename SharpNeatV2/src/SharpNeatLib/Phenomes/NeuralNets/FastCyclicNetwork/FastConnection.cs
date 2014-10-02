/* ***************************************************************************
 * This file is part of SharpNEAT - Evolution of Neural Networks.
 * 
 * Copyright 2004-2006, 2009-2010 Colin Green (sharpneat@gmail.com)
 *
 * SharpNEAT is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SharpNEAT is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SharpNEAT.  If not, see <http://www.gnu.org/licenses/>.
 */

// Disable missing comment warnings.
#pragma warning disable 1591

namespace SharpNeat.Phenomes.NeuralNets
{
    /// <summary>
    /// Working data struct for use in FastCyclicNetwork and sub-classes.
    /// Represents a single connection - its weigth and source/target neurons.
    /// </summary>
    public struct FastConnection
    {
        public int _srcNeuronIdx;
        public int _tgtNeuronIdx;
        public double _weight;

        #region Runtime Weight Extension Instance Fields

        // Jason Palacios - 2014 - Runtime Weight Extension - jason.palacios@utexas.edu
        // This signifies that the connection targets a runtime weight
        public bool _rwTgtFlag;
        // This is the index of the target connection that contains the target runtime weight
        public int _tgtConnectionIdx;
 
        // A normal FastConnection struct with a target neuron index of 10, a source neuron index of 9, and a weight of 1.0 would contain the following values for its members
        // _srcNeuronIdx = 9; <--- normal...
        // _tgtNeuronIdx = 10; <--- normal...
        // _weight = 1.0; <--- normal...
        // _rwTgtFlag = false; <--- the connection does not target a runtime weight
        // _tgtConnectionIdx = -1; <--- the connection targets an invalid ID which basically means that it doesn't target anything... truthfully, this value is ignored when _rwTgtFlag is false so it really doesn't matter what we put here

        // A FastConnection struct which targets a runtime weight on a target connection with at the array of 100, the target connection's target neuron index of 10, a source neuron index of 9, and a weight of 1.0 would contain the following values for its members
        // _srcNeuronIdx = 9 <--- normal...
        // _tgtNeuronIdx = 10 <--- the connection to the runtime weight needs to affect the depth level of the target connection's target neuron, so we say that there is a pathway from this connection to said neuron (we're interested in the target connection which targets it, really) which may potentially lead to a longer path than encountered... thus affecting the depth level of said neuron
        // _weight = 1.0 <--- normal
        // _rwTgtFlag = true <--- the connection targets a runtime weight
        // _tgtConnectionIdx = 100 <--- the connection targets the runtime weight contained on the connection with the ID of 100

        #endregion

        #region Instance Fields Utilized in Decoding with Runtime Weights

        public uint _connectionId;
        public uint _tgtConnectionId;

        #endregion
    }
}
