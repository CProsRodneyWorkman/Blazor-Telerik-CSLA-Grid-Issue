using System;
using System.Linq;
using System.Threading.Tasks;
using Csla;

namespace BlazorTelerikCslaGridIssue.BusinessLibrary
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
    private void Fetch(int studioId, [Inject] IChildDataPortal<ArtistEdit> portal)
    {
      // Simulate fetch for studio
      using (LoadListMode)
      {
        Add(portal.FetchChild(1));
        Add(portal.FetchChild(2));
      }
    }
  }
}
