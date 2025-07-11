using System;
using System.ComponentModel.DataAnnotations;
using Csla;
using Csla.Rules;

namespace BlazorTelerikCslaGridIssue.BusinessLibrary
{
  [Serializable]
  public class ArtStudioEdit : BusinessBase<ArtStudioEdit>
  {
    public static readonly PropertyInfo<int> StudioIdProperty = RegisterProperty<int>(nameof(StudioId));
    public int StudioId
    {
      get { return GetProperty(StudioIdProperty); }
      set { SetProperty(StudioIdProperty, value); }
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    [Required]
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }

    public static readonly PropertyInfo<string> LocationProperty = RegisterProperty<string>(nameof(Location));
    [Required]
    public string Location
    {
      get { return GetProperty(LocationProperty); }
      set { SetProperty(LocationProperty, value); }
    }

    public static readonly PropertyInfo<int> CapacityProperty = RegisterProperty<int>(nameof(Capacity));
    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1")]
    public int Capacity
    {
      get { return GetProperty(CapacityProperty); }
      set { SetProperty(CapacityProperty, value); }
    }

    public static readonly PropertyInfo<string> EquipmentProperty = RegisterProperty<string>(nameof(Equipment));
    public string Equipment
    {
      get { return GetProperty(EquipmentProperty); }
      set { SetProperty(EquipmentProperty, value); }
    }

    public static readonly PropertyInfo<ArtistList> ArtistListProperty = RegisterProperty<ArtistList>(nameof(ArtistList));
    public ArtistList ArtistList
    {
      get => GetProperty(ArtistListProperty);
      set => SetProperty(ArtistListProperty, value);
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [ObjectAuthorizationRules]
    public static void AddObjectAuthorizationRules()
    {
      // Add authorization rules as needed
    }

    protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
      // Add more business rules as needed
    }

    [Fetch]
    private void Fetch(int studioId, [Inject] IChildDataPortal<ArtistList> artistListPortal)
    {
      // Simulate fetching from a data source
      StudioId = studioId;
      Name = "Sample Studio";
      Location = "Room 101";
      Capacity = 10;
      Equipment = "Kilns, Easels, Pottery Wheels";
      ArtistList = artistListPortal.FetchChild(studioId);
      BusinessRules.CheckRules();
    }

    [Update]
    private void Update()
    {
      // Simulate updating to a data source
      // Implement actual persistence logic here
    }
  }
}
