using WebServiceMemory.Models;

namespace WebServiceExamen
{
    public class CoordinateRepository
    {
        public Coordinate Add(Coordinate coordinate)
        {
            
            MemoryContext memoryContext = new MemoryContext();
            memoryContext.Coordinates.Add(coordinate);
            memoryContext.SaveChanges();
            return coordinate;
        }

    }
}

