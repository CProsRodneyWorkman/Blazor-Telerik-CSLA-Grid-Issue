using Art_Studio_DataModel;
using Bogus;

namespace Art_Studio_FakeData
{
    public class ArtistFaker
    {
        private readonly Faker<Artist> _faker;

        public ArtistFaker()
        {
            _faker = new Faker<Artist>()
                .RuleFor(a => a.ArtistId, f => f.IndexFaker + 1)
                .RuleFor(a => a.FullName, f => f.Name.FullName())
                .RuleFor(a => a.ContactEmail, f => f.Internet.Email())
                .RuleFor(a => a.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(a => a.MembershipStatus, f => f.PickRandom(new[] { "Active", "Inactive", "Pending" }))
                .RuleFor(a => a.MembershipType, f => f.PickRandom(new[] { "Full-time", "Part-time", "Guest" }))
                .RuleFor(a => a.JoinDate, f => f.Date.Past(5))
                .RuleFor(a => a.EmergencyContactName, f => f.Name.FullName())
                .RuleFor(a => a.EmergencyContactPhone, f => f.Phone.PhoneNumber())
                .RuleFor(a => a.PreferredMediums, f => f.PickRandom(new[] { "Painting", "Sculpture", "Photography", "Drawing", "Mixed Media" }))
                .RuleFor(a => a.Notes, f => f.Lorem.Sentence());
        }

        public List<Artist> GenerateArtists(int count)
        {
            return _faker.Generate(count);
        }
    }
}
