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

namespace SharpNeat.Network
{
    /// <summary>
    /// Concrete implementation of INetworkConnection.
    /// </summary>
    public class NetworkConnection : INetworkConnection
    {
        readonly uint _sourceNodeId;
        readonly uint _targetNodeId;
        readonly double _weight;

        #region Runtime Weights Extension Instance Fields

        // Jason Palacios - 2014 - Runtime Weight Extension - jason.palacios@utexas.edu
        bool _rwSrcFlag;
        bool _rwTgtFlag;
        uint _srcConnectionId;
        uint _tgtConnectionId;
        readonly uint _innovationId;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs with the provided source and target node IDs and weight.
        /// </summary>
        public NetworkConnection(uint sourceNodeId, uint targetNodeId, double weight) : this(sourceNodeId, targetNodeId, weight, false, false, uint.MaxValue, uint.MaxValue, 0)
        {
            // Slightly changed this to call the new constructor
        }

        /// <summary>
        /// Constructs with the provided source and target node IDs and weight and other things related to runtime weights.
        /// </summary>
        public NetworkConnection(uint sourceNodeId, uint targetNodeId, double weight, bool rwSrcFlag, bool rwTgtFlag, uint srcConnectionId, uint tgtConnectionId, uint innovationId)
        {
            _sourceNodeId = sourceNodeId;
            _targetNodeId = targetNodeId;
            _weight = weight;
            _rwSrcFlag = rwSrcFlag;
            _rwTgtFlag = rwTgtFlag;
            _srcConnectionId = srcConnectionId;
            _tgtConnectionId = tgtConnectionId;
            _innovationId = innovationId;
        }

        #endregion

        #region Properties

        // [CONTINUE] Colin Green's original code for SharpNEAT v2.0
        /// <summary>
        /// Gets the ID of the connection's source node.
        /// </summary>
        public uint SourceNodeId
        {
            get { return _sourceNodeId; }
        }

        /// <summary>
        /// Gets the ID of the connection's target node.
        /// </summary>
        public uint TargetNodeId
        {
            get { return _targetNodeId; }
        }

        /// <summary>
        /// Gets the connection's weight.
        /// </summary>
        public double Weight
        {
            get { return _weight; }
        }

        #endregion

        #region Runtime Weight Extension Properties

        // Jason Palacios - 2014 - Runtime Weight Extension - jason.palacios@utexas.edu
        /// <summary>
        /// Gets the connection's flag that indicates whether or not it contains a runtime weight.
        /// </summary>
        public bool RuntimeWeightSourceFlag 
        {
            get { return _rwSrcFlag; }
            set { _rwSrcFlag = value; }
        }

        /// <summary>
        /// Gets the connection's flag that indicates whether or not it targets a runtime weight
        /// </summary>
        public bool RuntimeWeightTargetFlag
        {
            get { return _rwTgtFlag; }
            set { _rwTgtFlag = value; }
        }

        /// <summary>
        /// Gets the ID of the connection's runtime weight's source connection.
        /// </summary>
        public uint SourceConnectionId 
        {
            get { return _srcConnectionId; }
            set { _srcConnectionId = value; }
        }

        /// <summary>
        /// Gets the ID of the connection's target connection.
        /// </summary>
        public uint TargetConnectionId
        {
            get { return _tgtConnectionId; }
            set { _tgtConnectionId = value; }
        }

        /// <summary>
        /// Gets the ID of the connection.
        /// </summary>
        public uint InnovationId
        {
            get { return _innovationId; }
        }

        #endregion
    }
}
