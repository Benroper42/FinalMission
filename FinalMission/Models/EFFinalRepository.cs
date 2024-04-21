namespace FinalMission.Models
{
    public class EFFinalRepository : IFinalRepository
    {
        private EntertainmentAgencyExampleContext _repo;

        public EFFinalRepository(EntertainmentAgencyExampleContext temp)
        {
            _repo = temp;
        }

        public IQueryable<Entertainer> Entertainers => _repo.Entertainers;

        public void AddEnt(Entertainer entertainer)
        {
            _repo.Entertainers.Add(entertainer);
            _repo.SaveChanges();
        }

        public void EditEnt(Entertainer entertainer)
        {
            _repo.Entertainers.Update(entertainer);
            _repo.SaveChanges();
        }

        public void DeleteEnt(Entertainer entertainer)
        {
            _repo.Entertainers.Remove(entertainer);
            _repo.SaveChanges();
        }

        public Entertainer GetEntertainerById(int id)
        {
            return _repo.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
        }

        public Entertainer GetEntertainerById(Entertainer id)
        {
            throw new NotImplementedException();
        }
    }
}
