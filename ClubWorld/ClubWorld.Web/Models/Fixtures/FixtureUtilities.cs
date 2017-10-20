using ClubWorld.Models.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClubWorld.Models.DataAccess;
using ClubWorld.Models.Shared;

namespace ClubWorld.Models.Fixtures
{
    public class FixtureUtilities
    {
        ClubWorldDbContext _db = new ClubWorldDbContext();
        Fixtures _fixtures = new Fixtures();

        public Fixtures Process(Teams teamID, DateTime StartDate, List<string> SessionsRequested, List<string> DaysRequested, Boolean AllSessionsForDay, int NoOfRepeats = 2)
        {
            _fixtures.LeagueId = teamID.LeagueID;
            _fixtures.LeagueName = teamID.LeagueName;

            for (int i = 1; i < NoOfRepeats; i++)
            {
                do
                {
                    teamID.PopulateRound();

                    Games games = new Games();
                    //Games reverseRound = new Games();
                    Team home = teamID.Home;

                    while (home != null)
                    {
                        Game currentGame = new Game(home, teamID.Away);
                        games.Round.Add(currentGame);

                        //reverseRound.Round.Add(new Game(currentGame.AwayTeam, currentGame.HomeTeam));
                        home = teamID.Home;
                    }
                    
                    _fixtures.Series.Add(games);
                    //_fixtures.Series.Add(reverseRound);
                } while (teamID.Rotate());
            }

            _fixtures.Reverse();
            AssignDates(StartDate, SessionsRequested, DaysRequested, AllSessionsForDay);
            return _fixtures;
        }
        
        public FixtureViewModel FixtureList(Fixtures fix)
        {
            FixtureViewModel fvm = new FixtureViewModel();
            foreach (Games series in fix.Series)
            {
                foreach (Game game in series.Round)
                {
                    if (game.AwayTeam.Id > 0 && game.HomeTeam.Id > 0)
                    {
                        fvm.FixtureList.Add(game);
                    }
                }
            }
            return fvm;
        }

        public void AssignDates(DateTime StartDate, List<String> SessionsRequested, List<string> DaysRequested, Boolean AllSessionsForDay)
        {
            IEnumerator<GetFreeRinks_Result> rinks = null;
            int? rinksRequired = _Repository.GetRinksPerGame(_fixtures.LeagueId);

            int p1 = ListToFlag(SessionsRequested);
            int p2 = ListToFlag(DaysRequested);
            int MaxRinksAvailable;
            List<GetFreeRinks_Result> r1;

            if (SessionsRequested.Count() > 1 & !AllSessionsForDay)
            {
                p1 = (int)Math.Pow(2,double.Parse(SessionsRequested[0])-1);
                r1 = _db.GetFreeRinks(StartDate, p1, p2, 0, rinksRequired).ToList();

                p1 = (int)Math.Pow(2, double.Parse(SessionsRequested[1]) - 1);
                var r2 = _db.GetFreeRinks(StartDate, p1, p2, 1, rinksRequired).ToList();
                rinks = r1.Union(r2).OrderBy(s => s.AvDate).GetEnumerator();

                MaxRinksAvailable = r1.Sum(sr => sr.SpareRinks ?? default(int)) + r2.Sum(sr => sr.SpareRinks ?? default(int));

            }
            else
            {
                r1 = _db.GetFreeRinks(StartDate, p1, p2, 2, rinksRequired).ToList();
                MaxRinksAvailable = r1.Sum(sr => sr.SpareRinks ?? default(int));
                rinks = r1.GetEnumerator();
            }



            if (MaxRinksAvailable < _fixtures.TotalGames())
            {
                return;
            }

            rinks.MoveNext();
            int rinksLeft = rinks.Current.SpareRinks ?? default(int);
            int rinksLeftFlag = rinks.Current.RinkFlag ?? default(int);

            foreach (Games round in _fixtures.Series)
            {
                foreach (Game game in round.Round)
                {
                    if (game.HomeTeam.Id * game.AwayTeam.Id > 0)    //  Zero equates to a bye
                    {
                        if (rinksLeft >= rinksRequired)
                        {

                            game.AssignedDate = rinks.Current.AvDate ?? DateTime.Now;

                            int rinksUsedFlag = 0;
                            int counter = 0;

                            foreach (int r in FindFreeRinks(rinksLeftFlag))
                            {
                                rinksUsedFlag |= r;
                                rinksLeftFlag |= r;
                                counter += 1;
                                if (counter == rinksRequired)
                                {
                                    rinksLeft -= counter;
                                    break;
                                }
                            }

                            using (ClubWorldDbContext saveContext = new ClubWorldDbContext())
                            {
                                saveContext.AddNewFixture(_fixtures.LeagueName, game.AssignedDate, 1, rinksUsedFlag, rinks.Current.SessionRef, _fixtures.LeagueId, game.HomeTeam.Id, game.AwayTeam.Id);
                            }

                            rinksUsedFlag = 0;
                        }
                        else
                        {
                            rinks.MoveNext();
                            rinksLeft = rinks.Current.SpareRinks ?? default(int);
                            rinksLeftFlag = rinks.Current.RinkFlag ?? default(int);
                        }

                    }
                }
                rinks.MoveNext();
                rinksLeft = rinks.Current.SpareRinks ?? default(int);
                rinksLeftFlag = rinks.Current.RinkFlag ?? default(int);
            }
        }
        private static IEnumerable<int> FindFreeRinks(int FlagPassed)
        {
            for (int i = 0; i < 7; i++)
            {
                int r = (int)Math.Pow(2, i);
                if ((FlagPassed & r) == 0)
                {
                    yield return (int)Math.Pow(2, i);
                }
            }
        }
        private int ListToFlag(List<string> FlagValues)
        {
            int flag = 0;
            foreach (string sVal in FlagValues)
            {
                double p1 = double.Parse(sVal)-1;

                flag |= (int)Math.Pow(2,p1);
            }
            return flag;
        }   
    }
}