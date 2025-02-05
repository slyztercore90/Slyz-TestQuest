﻿using System;
using System.Globalization;
using Yggdrasil.Geometry;
using Yggdrasil.Util;

namespace Melia.Shared.World
{
	public struct Position
	{
		/// <summary>
		/// X coordinate (left/right).
		/// </summary>
		public float X;

		/// <summary>
		/// Y coordinate (up/down).
		/// </summary>
		public float Y;

		/// <summary>
		/// Z coordinate (depth).
		/// </summary>
		public float Z;

		/// <summary>
		/// Returns new position with X, Y, and Z being 0.
		/// </summary>
		public static Position Zero => new Position(0, 0, 0);

		public static Position operator +(Position a) => a;
		public static Position operator -(Position a) => new Position(-a.X, -a.Y, -a.Z);
		public static Position operator +(Position a, Position b)
			=> new Position(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		public static Position operator -(Position a, Position b)
			=> new Position(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

		/// <summary>
		/// Creates new position from coordinates.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public Position(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		/// <summary>
		/// Creates new position from position.
		/// </summary>
		/// <param name="pos"></param>
		public Position(Position pos)
		{
			this.X = pos.X;
			this.Y = pos.Y;
			this.Z = pos.Z;
		}

		/// <summary>
		/// Returns a new position floored
		/// </summary>
		/// <returns></returns>
		public Position Floor => new Position((int)X, (int)Y, (int)Z);

		/// <summary>
		/// Returns distance between this and another position in 2D space (X,Z).
		/// </summary>
		/// <param name="otherPos"></param>
		/// <returns></returns>
		public double Get2DDistance(Position otherPos)
		{
			return Math.Sqrt(Math.Pow(X - otherPos.X, 2) + Math.Pow(Z - otherPos.Z, 2));
		}

		/// <summary>
		/// Returns distance between this and another position in 3D space.
		/// </summary>
		/// <param name="otherPos"></param>
		/// <returns></returns>
		public double Get3DDistance(Position otherPos)
		{
			return Math.Sqrt(Math.Pow(X - otherPos.X, 2) + Math.Pow(Y - otherPos.Y, 2) + Math.Pow(Z - otherPos.Z, 2));
		}

		/// <summary>
		/// Returns true if other position is within given range in 2D space.
		/// </summary>
		/// <param name="otherPos"></param>
		/// <returns></returns>
		public bool InRange2D(Position otherPos, float range)
		{
			return (Math.Pow(X - otherPos.X, 2) + Math.Pow(Z - otherPos.Z, 2) <= Math.Pow(range, 2));
		}

		/// <summary>
		/// Returns true if other position is within given range in 3D space.
		/// </summary>
		/// <param name="otherPos"></param>
		/// <returns></returns>
		public bool InRange3D(Position otherPos, float range)
		{
			return (Math.Pow(X - otherPos.X, 2) + Math.Pow(Y - otherPos.Y, 2) + Math.Pow(Z - otherPos.Z, 2) <= Math.Pow(range, 2));
		}

		/// <summary>
		/// Returns true if the position is within in the 2D polygon
		/// defined by the given points.
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public bool InPolygon2D(Position[] points)
		{
			var result = false;
			var x = this.X;
			var z = this.Z;

			for (int i = 0, j = points.Length - 1; i < points.Length; j = i++)
			{
				if (((points[i].Z > z) != (points[j].Z > z)) && (x < (points[j].X - points[i].X) * (z - points[i].Z) / (points[j].Z - points[i].Z) + points[i].X))
					result = !result;
			}

			return result;
		}

		/// <summary>
		/// Returns random position around this position,
		/// not nearer than min, and not further than max.
		/// </summary>
		/// <param name="distanceMax"></param>
		/// <param name="distanceMin"></param>
		/// <returns></returns>
		public Position GetRandomInRange2D(int distanceMin, int distanceMax)
		{
			var rnd = RandomProvider.Get();
			return this.GetRandom(rnd.Next(distanceMin, distanceMax + 1), rnd);
		}

		/// <summary>
		/// Returns random position around this position,
		/// not nearer than min, and not further than max.
		/// </summary>
		/// <param name="distanceMax"></param>
		/// <param name="rnd"></param>
		/// <param name="distanceMin"></param>
		/// <returns></returns>
		public Position GetRandomInRange2D(int distanceMin, int distanceMax, Random rnd)
		{
			return this.GetRandom(rnd.Next(distanceMin, distanceMax + 1), rnd);
		}

		/// <summary>
		/// Returns random position in radius around this position.
		/// </summary>
		/// <param name="radius"></param>
		/// <param name="rnd"></param>
		/// <returns></returns>
		public Position GetRandomInRange2D(int radius, Random rnd)
		{
			return this.GetRandom(rnd.Next(radius + 1), rnd);
		}

		/// <summary>
		/// Returns random position in radius around this position.
		/// </summary>
		/// <param name="distance"></param>
		/// <param name="rnd"></param>
		/// <returns></returns>
		private Position GetRandom(int distance, Random rnd)
		{
			var angle = rnd.NextDouble() * Math.PI * 2;
			var x = this.X + distance * Math.Cos(angle);
			var z = this.Z + distance * Math.Sin(angle);

			return new Position((int)x, this.Y, (int)z);
		}

		/// <summary>
		/// Returns position on the line between this position and the
		/// given one.
		/// </summary>
		/// <remarks>
		/// When you knock someone back, he gets pushed in the opposite
		/// direction. The other position would be the enemy, the distance
		/// the amount how far to push them away. A negative distance will
		/// return a position between you two.
		/// </remarks>
		public Position GetRelative(Position other, float distance)
		{
			if (this == other)
				return this;

			var deltaX = (double)other.X - this.X;
			var deltaY = (double)other.Y - this.Y;
			var deltaZ = (double)other.Z - this.Z;

			var deltaXYZ = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2));

			var newX = other.X + (distance / deltaXYZ) * (deltaX);
			var newY = other.Y + (distance / deltaXYZ) * (deltaY);
			var newZ = other.Z + (distance / deltaXYZ) * (deltaZ);

			return new Position((float)newX, (float)newY, (float)newZ);
		}

		/// <summary>
		/// Returns position in direction and distance.
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="distance"></param>
		/// <returns></returns>
		public Position GetRelative(Direction direction, float distance)
		{
			var deltaX = direction.Cos;
			var deltaZ = direction.Sin;

			var deltaXZ = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaZ, 2));

			var newX = this.X + (distance / deltaXZ) * (deltaX);
			var newZ = this.Z + (distance / deltaXZ) * (deltaZ);

			return new Position((float)newX, this.Y, (float)newZ);
		}

		/// <summary>
		/// Returns direction the other position is in as radian.
		/// </summary>
		/// <param name="otherPos"></param>
		/// <returns></returns>
		public Direction GetDirection(Position otherPos)
		{
			var radianAngle = Math.Atan2(otherPos.Z - Z, otherPos.X - X);

			var cos = Math.Cos(radianAngle);
			var sin = Math.Sin(radianAngle);

			return new Direction((float)cos, (float)sin);
		}

		/// <summary>
		/// Implicitly converts the position to a vector.
		/// </summary>
		/// <param name="pos"></param>
		public static implicit operator Vector2(Position pos)
		{
			return new Vector2((int)pos.X, (int)pos.Z);
		}

		/// <summary>
		/// Implicitly converts the position to a vector.
		/// </summary>
		/// <param name="pos"></param>
		public static implicit operator Vector2F(Position pos)
		{
			return new Vector2F(pos.X, pos.Z);
		}

		/// <summary>
		/// Returns true if both positions represent the same position.
		/// </summary>
		/// <param name="pos1"></param>
		/// <param name="pos2"></param>
		/// <returns></returns>
		public static bool operator ==(Position pos1, Position pos2)
		{
			return (pos1.X == pos2.X && pos1.Y == pos2.Y && pos1.Z == pos2.Z);
		}

		/// <summary>
		/// Returns true if positions aren't representing the same position.
		/// </summary>
		/// <param name="pos1"></param>
		/// <param name="pos2"></param>
		/// <returns></returns>
		public static bool operator !=(Position pos1, Position pos2)
		{
			return !(pos1 == pos2);
		}

		/// <summary>
		/// Returns hash code for this position, calculated out of the coorindates.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
		}

		/// <summary>
		/// Returns true if the given object is the same instance.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			return obj is Position position && this == position;
		}

		/// <summary>
		/// Returns string representation of position.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}", X, Y, Z);
		}
	}
}
