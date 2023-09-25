using WebServiceMemory.Models;

namespace WebServiceExamen
{
    public class PlayersScoreRepository
    {
        public PlayersScore Add(PlayersScore playersscore)
        {

            MemoryContext memoryContext = new MemoryContext();
            memoryContext.PlayersScores.Add(playersscore);
            memoryContext.SaveChanges();
            return playersscore;
        }

    }
}
