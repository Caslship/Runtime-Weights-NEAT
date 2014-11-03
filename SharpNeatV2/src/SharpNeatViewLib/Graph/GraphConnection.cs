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
namespace SharpNeat.View.Graph
{
    /// <summary>
    /// Represents a connection in a graph.
    /// </summary>
    public class GraphConnection
    {
        GraphNode _sourceNode;
        GraphNode _targetNode;
        float _weight;

        #region Runtime Weights Extension - Instance Fields

        // Jason Palacios - 2014 - Runtime Weight Extension - jason.palacios@utexas.edu
        bool _rwTgtFlag;
        GraphConnection _tgtConnection;

        #endregion

        #region Constructor

        // [CONTINUE] Colin Green's original code for SharpNEAT v2.0
        /// <summary>
        /// Constructs a connection between the specified source and target nodes and of the specified weight.
        /// </summary>
        public GraphConnection(GraphNode sourceNode, GraphNode targetNode, float weight) 
        {
            _sourceNode = sourceNode;
            _targetNode = targetNode;
            _weight = weight;
            _rwTgtFlag = false;
            _tgtConnection = null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the connection's source node.
        /// </summary>
        public GraphNode SourceNode
        {
            get { return _sourceNode; }
            set { _sourceNode = value; }
        }

        /// <summary>
        /// Gets or sets the connection's target node.
        /// </summary>
        public GraphNode TargetNode
        {
            get { return _targetNode; }
            set { _targetNode = value; }
        }

        /// <summary>
        /// Gets or sets the connection's weight.
        /// </summary>
        public float Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        #endregion

        #region Runtime Weights Extension - Properties

        // Jason Palacios - 2014 - Runtime Weight Extension - jason.palacios@utexas.edu
        /// <summary>
        /// Flag that indicates whether or not the connection targets a runtime weight
        /// </summary>
        public bool RuntimeWeightTargetFlag
        {
            get { return _rwTgtFlag; }
            set { _rwTgtFlag = value; }
        }

        /// <summary>
        /// GraphConnection whose weight is the target of this conneciton
        /// </summary>
        public GraphConnection TargetConnection
        {
            get { return _tgtConnection; }
            set { _tgtConnection = value; }
        }

        #endregion
    }
}
