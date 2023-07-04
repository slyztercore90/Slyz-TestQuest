using System;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors;
using Yggdrasil.Logging;

namespace Melia.Zone.Tracks
{
	public class Track
	{
		public string Id { get; set; }
		public TrackStatus Status { get; set; }
		public DateTime StartTime { get; set; }
		/// <summary>
		/// Returns the associated dialog.
		/// </summary>
		public Dialog Dialog { get; set; }
		/// <summary>
		/// Returns the track's current frame.
		/// </summary>
		public int Frame { get; set; }
		/// <summary>
		/// Returns the associated entities with the track.
		/// </summary>
		public Actor[] Actors { get; set; }

		/// <summary>
		/// Creates new quest.
		/// </summary>
		/// <param name="trackId"></param>
		public Track(string trackId)
		{
			this.Id = trackId;
		}

		/// <summary>
		/// Creates quest from given id.
		/// </summary>
		/// <param name="trackId"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">
		/// Thrown if no quest with the given id could be found.
		/// </exception>
		public static Track Create(string trackId)
		{
			if (!TrackScripts.TryGet(trackId, out var trackScript))
			{
				Log.Warning($"Track.Create: Track '{trackId}' not found.");
				throw new ArgumentException($"Track '{trackId}' not found.");
			}

			var result = new Track(trackId);
			return result;
		}
	}

	public enum TrackStatus
	{
		NotStarted,
		Started,
		Ended,
	}
}
