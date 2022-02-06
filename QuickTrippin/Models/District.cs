namespace QuickTrippin.Models
{
    public class District
    {
        public District(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ListName => $" {Id,5} - {Name}"; //the 5 is what's called the `alignment` element of the interpolated string
    }
}
