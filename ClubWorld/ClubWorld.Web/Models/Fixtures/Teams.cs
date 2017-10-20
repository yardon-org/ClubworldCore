using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClubWorld.Models.DataAccess;
using ClubWorld.Models.Shared;

namespace ClubWorld.Models.Fixtures
{
    public class Teams
    {
        ClubWorldDbContext _db = new ClubWorldDbContext();
        Queue<Team> _queueMain = new Queue<Team>();
        Queue<Team> _queueCopy;
        Queue<Team> _queueHome;
        Stack<Team> _stackAway;

        List<Team> _league = new List<Team>();
        Team _fixed;
        string _leagueName;
        int _rotateCount;
        int _LeagueId;

        public Teams(int leagueId)
        {
            _LeagueId = leagueId;
            _leagueName = _Repository.GetLeagueName(leagueId);
            _league = _Repository.GetTeamsInLeague(leagueId);
            _rotateCount = _league.Count;

            AddToQueue();
        }
        public List<Team> CurrentLeague{
            get { return _league; }
        }
        public string LeagueName
        {
            get { return _leagueName; }
        }
        public int LeagueID
        {
            get { return _LeagueId; }
        }
        private void AddToQueue()
        {
            _queueCopy = new Queue<Team>();
            _queueMain = new Queue<Team>();
            _fixed = _league[0];

            for (int i = 1; i < _league.Count; i++)
            {
                _queueMain.Enqueue(_league[i]);
            }
            if (_queueMain.Count() %2 == 0)
            {
                _queueMain.Enqueue(new Team { Name = "Dummy", Id = 0 });
            }
            _queueCopy = new Queue<Team>(_queueMain);
        }
        public Team Home
        {
            get
            {
                if (_queueHome.Count() > 0)
                {
                    return _queueHome.Dequeue();
                }
                return null;
            }
        }

        public Team Away
        {
            get
            {
                if (_stackAway.Count() > 0)
                {
                    return _stackAway.Pop();
                }
                return null;
            }
        }
        public void PopulateRound()
        {
            _queueHome = new Queue<Team>();
            _stackAway = new Stack<Team>();

            _queueHome.Enqueue(_fixed);
            int homeCount = _queueMain.Count()/2;
            int roundCount = _queueMain.Count();

            for (int i = 0; i < roundCount; i++)
            {
                if (i < homeCount)
                {
                    _queueHome.Enqueue(_queueMain.Dequeue());
                }
                else
                {
                    _stackAway.Push(_queueMain.Dequeue());
                }
            }
        }
        public bool Rotate()
        {
            if (_rotateCount > 0)
            {
            Team first = _queueCopy.Dequeue();

            do 
            {
                _queueMain.Enqueue(_queueCopy.Dequeue());
            } while (_queueCopy.Count() > 0);

            _queueMain.Enqueue(first);

            _queueCopy = new Queue<Team>(_queueMain);

            _rotateCount -= 1;
            return true;
            }
            return false;
        }
    }
}