namespace FinalMission.Models
{
    public interface IFinalRepository
    {
        IQueryable<Entertainer> Entertainers { get; }

        public void AddEnt(Entertainer entertainer);
        public void EditEnt(Entertainer entertainer);
        public void DeleteEnt(Entertainer entertainer);

        Entertainer GetEntertainerById(int id);
        Entertainer GetEntertainerById(Entertainer id);
    }
}
