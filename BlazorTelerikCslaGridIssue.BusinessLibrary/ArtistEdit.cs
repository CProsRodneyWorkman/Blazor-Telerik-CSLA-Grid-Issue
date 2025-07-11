using System;
using System.ComponentModel.DataAnnotations;
using Csla;
using Csla.Rules;
using Art_Studio_FakeData;
using Art_Studio_DataModel;

namespace BusinessLibrary
{
  [Serializable]
  public class ArtistEdit : BusinessBase<ArtistEdit>
  {
    public static readonly PropertyInfo<int> ArtistIdProperty = RegisterProperty<int>(nameof(ArtistId));
    public int ArtistId
    {
      get => GetProperty(ArtistIdProperty);
      set => SetProperty(ArtistIdProperty, value);
    }

    public static readonly PropertyInfo<string> FullNameProperty = RegisterProperty<string>(nameof(FullName));
    [Required]
    public string FullName
    {
      get => GetProperty(FullNameProperty);
      set => SetProperty(FullNameProperty, value);
    }

    public static readonly PropertyInfo<string> ContactEmailProperty = RegisterProperty<string>(nameof(ContactEmail));
    [Required, EmailAddress]
    public string ContactEmail
    {
      get => GetProperty(ContactEmailProperty);
      set => SetProperty(ContactEmailProperty, value);
    }

    public static readonly PropertyInfo<string> PhoneNumberProperty = RegisterProperty<string>(nameof(PhoneNumber));
    public string PhoneNumber
    {
      get => GetProperty(PhoneNumberProperty);
      set => SetProperty(PhoneNumberProperty, value);
    }

    public static readonly PropertyInfo<string> MembershipStatusProperty = RegisterProperty<string>(nameof(MembershipStatus));
    public string MembershipStatus
    {
      get => GetProperty(MembershipStatusProperty);
      set => SetProperty(MembershipStatusProperty, value);
    }

    public static readonly PropertyInfo<string> MembershipTypeProperty = RegisterProperty<string>(nameof(MembershipType));
    public string MembershipType
    {
      get => GetProperty(MembershipTypeProperty);
      set => SetProperty(MembershipTypeProperty, value);
    }

    public static readonly PropertyInfo<DateTime> JoinDateProperty = RegisterProperty<DateTime>(nameof(JoinDate));
    public DateTime JoinDate
    {
      get => GetProperty(JoinDateProperty);
      set => SetProperty(JoinDateProperty, value);
    }

    public static readonly PropertyInfo<string> EmergencyContactNameProperty = RegisterProperty<string>(nameof(EmergencyContactName));
    public string EmergencyContactName
    {
      get => GetProperty(EmergencyContactNameProperty);
      set => SetProperty(EmergencyContactNameProperty, value);
    }

    public static readonly PropertyInfo<string> EmergencyContactPhoneProperty = RegisterProperty<string>(nameof(EmergencyContactPhone));
    public string EmergencyContactPhone
    {
      get => GetProperty(EmergencyContactPhoneProperty);
      set => SetProperty(EmergencyContactPhoneProperty, value);
    }

    public static readonly PropertyInfo<string> PreferredMediumsProperty = RegisterProperty<string>(nameof(PreferredMediums));
    public string PreferredMediums
    {
      get => GetProperty(PreferredMediumsProperty);
      set => SetProperty(PreferredMediumsProperty, value);
    }

    public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(nameof(Notes));
    public string Notes
    {
      get => GetProperty(NotesProperty);
      set => SetProperty(NotesProperty, value);
    }

    protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
      // Add custom business rules if needed
    }

    [CreateChild]
    private void Create()
    {
      // Default values
      JoinDate = DateTime.Today;
    }

    [FetchChild]
    private void Fetch(int artistId)
    {
      // Use ArtistFaker to generate a fake artist
      var faker = new ArtistFaker();
      var artist = faker.GenerateArtists(1).First();
      ArtistId = artist.ArtistId;
      FullName = artist.FullName;
      ContactEmail = artist.ContactEmail;
      PhoneNumber = artist.PhoneNumber;
      MembershipStatus = artist.MembershipStatus;
      MembershipType = artist.MembershipType;
      JoinDate = artist.JoinDate;
      EmergencyContactName = artist.EmergencyContactName;
      EmergencyContactPhone = artist.EmergencyContactPhone;
      PreferredMediums = artist.PreferredMediums;
      Notes = artist.Notes;
    }

    [InsertChild]
    private void Insert()
    {
      // Simulate insert
    }

    [UpdateChild]
    private void Update()
    {
      // Simulate update
    }

    [DeleteSelfChild]
    private void DeleteSelf()
    {
      // Simulate delete
    }
  }
}
