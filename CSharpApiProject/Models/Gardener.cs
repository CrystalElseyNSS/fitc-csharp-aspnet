using System;

namespace CSharpApiProject.Models
{
    // C# representation of the Gardener table
    public class Gardener
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PlotId { get; set; }
        public Plot Plot { get; set; }
    }
}