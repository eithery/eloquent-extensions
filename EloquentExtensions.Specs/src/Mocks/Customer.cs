// Eithery: Eloquent Extensions
// Class Customer
// A dummy domain model class used for test purposes
//
using System.ComponentModel;

namespace EloquentExtensions
{
    [DisplayName("Dummy customer")]
    [Sample(DummyProperty="Sample1")]
    [Sample(DummyProperty="Sample2")]
    [TypeConverter(typeof(Customer))]
    internal class Customer
    {
        [Browsable(false)]
        public string Name { get; set; }

        internal string InternalName { get; set; }

        private string PrivateName { get; set; }
    }


    [Browsable(true)]
    internal class Individual : Customer
    {
        [DisplayName("Customer last name")]
        public string LastName { get; set; }
    }
}
