using Smads.SweepDimension.Game.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smads.SweepDimension.Game.Components
{
    public class GameRules : IGameRules
    {
        IScoringStrategy _scoringStrategy;
        IGameOverStrategy _winStrategy;
        IGameOverStrategy _loseStrategy;


        public GameRules(IGameOverStrategy winStrategy, IGameOverStrategy loseStrategy, IScoringStrategy scoringStrategy)
        {
            _scoringStrategy = scoringStrategy;
            _winStrategy = winStrategy;
            _loseStrategy = loseStrategy;
        }

        /// <summary>
        /// Based on the passed in state calculate the current score
        /// </summary>
        /// <param name="state">Current Game State</param>
        /// <returns>Score</returns>
        public double CalculateScore(IGameState state)
        {
            return _scoringStrategy.CalculateScore(state);
        }

        /// <summary>
        /// Check if the game lost criteria has been met.
        /// </summary>
        /// <param name="state">Current Game State</param>
        /// <returns>Game has been lost</returns>
        public bool LoseConditionMet(IGameState state)
        {
            return _loseStrategy.IsCriteriaMet(state);
        }

        /// <summary>
        /// Check if the game win criteria has been met.
        /// </summary>
        /// <param name="state">Current Game State</param>
        /// <returns>Game has been won</returns>
        public bool WinConditionMet(IGameState state)
        {
            return _winStrategy.IsCriteriaMet(state);
        }
    }
}
