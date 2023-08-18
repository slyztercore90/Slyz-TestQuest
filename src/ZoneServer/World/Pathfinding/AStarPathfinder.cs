using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.World;
using Melia.Zone.World.Maps;

namespace Melia.Zone.World.Pathfinding
{
	public class Node
	{
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
		public Node Parent { get; set; }
		public float G { get; set; }
		public float H { get; set; }
		public float F => this.G + this.H;

		public Node(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public Position ToPosition() => new Position(this.X, this.Y, this.Z);
	}

	public class AStarPathfinder
	{
		private Ground _ground;

		public AStarPathfinder(Ground ground)
		{
			_ground = ground;
		}

		private List<Node> GetNeighbours(Node node)
		{
			var neighbours = new List<Node>();
			// Add possible adjacent nodes as neighbors (up, down, left, right, front, back)
			int[] dx = { 1, -1, 0, 0, 0, 0 };
			int[] dz = { 0, 0, 0, 0, 1, -1 };

			for (var i = 0; i < 6; i++)
			{
				var nx = ((int)node.X) + dx[i];
				var nz = ((int)node.Z) + dz[i];

				// Check if the neighbor is within the grid bounds and is walkable
				var nodeCheck = new Node(nx, -1, nz);
				var position = nodeCheck.ToPosition();
				if (_ground.IsValidPosition(position))
				{
					nodeCheck.Y = _ground.GetHeightAt(position);
					neighbours.Add(nodeCheck);
				}
			}

			return neighbours;
		}

		private float CalculateHeuristic(Node fromPosition, Node toPosition)
		{
			// Calculate the Manhattan distance heuristic (L1-norm) between two nodes
			return Math.Abs(fromPosition.X - toPosition.X) +
				   Math.Abs(fromPosition.Y - toPosition.Y) +
				   Math.Abs(fromPosition.Z - toPosition.Z);
		}

		public List<Node> FindPath(Node startPosition, Node goalPosition)
		{
			var openList = new List<Node>();
			var closedList = new List<Node>();

			openList.Add(startPosition);

			while (openList.Count > 0)
			{
				// Get the node with the lowest F score from the open list
				var currentPosition = openList[0];
				for (var i = 1; i < openList.Count; i++)
				{
					if (openList[i].F < currentPosition.F)
					{
						currentPosition = openList[i];
					}
				}

				openList.Remove(currentPosition);
				closedList.Add(currentPosition);

				if (currentPosition == goalPosition)
				{
					// Goal node reached, reconstruct the path and return it
					var path = new List<Node>();
					while (currentPosition != null)
					{
						path.Add(currentPosition);
						currentPosition = currentPosition.Parent;
					}
					path.Reverse();
					return path;
				}

				var neighbours = this.GetNeighbours(currentPosition);
				foreach (var neighbour in neighbours)
				{
					if (closedList.Contains(neighbour))
					{
						continue;
					}

					var tentativeG = currentPosition.G + 1; // Assuming all movement costs are 1

					if (!openList.Contains(neighbour) || tentativeG < neighbour.G)
					{
						neighbour.G = tentativeG;
						neighbour.H = this.CalculateHeuristic(neighbour, goalPosition);
						neighbour.Parent = currentPosition;

						if (!openList.Contains(neighbour))
						{
							openList.Add(neighbour);
						}
					}
				}
			}

			// If no path found, return an empty list
			return new List<Node>();
		}
	}
}
