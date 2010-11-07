using System;
using Mogade.Achievements;
using Mogade.Configuration;
using Mogade.Leaderboards;

namespace Mogade.WindowsPhone
{
   public interface IMogadeClient
   {

      /// <summary>
      /// Makes the underlying Mogade Driver directly availble
      /// </summary>
      IDriver Driver { get; }

      /// <summary>
      /// Updates the configuration if its changed
      /// </summary>
      /// <param name="callback">Will callback with true on success</param>
      void Update(Action<bool> callback);

      /// <summary>
      /// Returns the user's stored settings for this game
      /// </summary>            
      /// <returns>The user's settings</returns>
      /// <remarks>
      /// The achievements collection is a list of achievement ids the user has earned      
      /// </remarks>
      void GetUserSettings(string userName, Action<UserSettings> callback);


      /// <summary>
      /// Saves a score
      /// </summary>
      /// <param name="leaderboardId">The id of the leaderboard to save the score to</param>
      /// <param name="score">The required score to save</param>
      /// <returns>A rank object containing the daily, weekly, and overall rank of the supplied score for the given leaderboard</returns>
      /// <remarks>
      /// The username and points properties of the Score are required.
      /// Usernames should be 20 characters max
      /// 
      /// The data field is optional and limited to 25 characters. You can stuff meta information inside, such as "4|12:30", which
      /// might mean the user got to level 4 and played for 12 minutes and 30 seconds. You are responsible for encoding/decoding
      /// this information...we just take it in, store it, and pass it back out      
      /// </remarks>
      void SaveScore(string leaderboardId, Score score, Action<Ranks> callback);

      /// <summary>
      /// Gets a leaderboard page
      /// </summary>
      /// <param name="leaderboardId">The id of the leaderboard to get the scores from</param>
      /// <param name="scope">The scope to get the scores from (daily, weekly or overall)</param>
      /// <param name="page">The page to get (starting with 1)</param>
      /// <returns>A leaderboard object containing an array of scores</returns>
      /// <remarks>
      /// Each page is limited to 10 scores
      /// </remarks>
      void GetLeaderboard(string leaderboardId, LeaderboardScope scope, int page, Action<Leaderboard> callback);

      /// <summary>
      /// Grants the user the specified achievement
      /// </summary>
      /// <param name="achievementId">The id of the achievement being granted</param>
      /// <param name="userName">The user's username</param>      
      /// <returns>The number of points earned</returns>
      void GrantAchievement(string achievementId, string userName, Action<int> callback);

      /// <summary>
      /// Grants the user the specified achievement
      /// </summary>
      /// <param name="achievementId">The achievement being granted</param>
      /// <param name="userName">The user's username</param>
      /// <param name="uniqueIdentifier">A unique identifier for the user. Mobile devices should use the deviceId.</param>
      /// <returns>The number of points earned</returns>
      void GrantAchievement(Achievement achievement, string userName, Action<int> callback);

      /// <summary>
      /// Returns mogade's unique identifier for this device
      /// </summary>      
      string GetUniqueIdentifier();
   }
}