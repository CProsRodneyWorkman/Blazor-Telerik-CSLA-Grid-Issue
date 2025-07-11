using Art_Studio_FakeData;
using Csla;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    [Serializable]
    public class ArtistList : BusinessListBase<ArtistList, ArtistEdit>
    {
        public async Task<ArtistEdit> AssignAsync(int artistId)
        {
            var portal = ApplicationContext.GetRequiredService<IDataPortal<ArtistEdit>>();
            var artistEdit = await portal.FetchAsync(artistId);
            this.Add(artistEdit);
            return artistEdit;
        }

        public void Remove(int artistId)
        {
            var item = this.FirstOrDefault(a => a.ArtistId == artistId);
            if (item != null)
                Remove(item);
        }

        public bool Contains(int artistId)
        {
            return this.Any(a => a.ArtistId == artistId);
        }

        public bool ContainsDeleted(int artistId)
        {
            return DeletedList.Any(a => a.ArtistId == artistId);
        }

        [FetchChild]
        private void Fetch([Inject] IChildDataPortal<ArtistEdit> portal, int studioId)
        {
            // Simulate fetch for studio
            using (LoadListMode)
            {
                // Generate a random number between 3 and 10 for the number of artists
                int desiredArtistCount = new Random().Next(3, 11);

                var faker = new ArtistFaker();
                var artists = faker.GenerateArtists(desiredArtistCount);
                foreach (var artist in artists)
                {
                    Add(portal.FetchChild(artist.ArtistId));
                }
            }
        }
    }
}
