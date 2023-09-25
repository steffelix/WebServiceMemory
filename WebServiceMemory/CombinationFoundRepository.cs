using WebServiceMemory.Models;

namespace WebServiceExamen
{
    public class CombinationFoundRepository
    {
        public CombinationFound Add(CombinationFound combination)
        {

            MemoryContext memoryContext = new MemoryContext();
            memoryContext.CombinationFounds.Add(combination);
            memoryContext.SaveChanges();
            return combination;
        }

    }
}
