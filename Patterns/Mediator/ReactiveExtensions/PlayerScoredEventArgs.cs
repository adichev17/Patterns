using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Mediator.ReactiveExtensions
{
    public class PlayerScoredEventArgs : EventArgs
    {
        public string PlayerName;
        public int GoalsScoredSoFar;
        public PlayerScoredEventArgs (string playerName, int goalsScoredSoFar)
        {
            PlayerName = playerName;
            GoalsScoredSoFar = goalsScoredSoFar;
        }
    }
}
