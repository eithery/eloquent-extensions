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
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public Address Address { get; set; }

        public int Age { get; set; }

        public string PersonalManager { get; set; }

        public bool? IsFinraMember { get; set; }

        public ActivationMode ActivationMode { get; set; }

        internal string InternalName { get; set; }

        private string PrivateName { get; set; }

        public static int TotalCount { get; }

        private static string PrivateStaticProperty { get; set ; }

        private static string SetterOnlyProperty
        {
            set => field = null;
        }

        private static string Field => field;

        private static string field;

        internal string name;
    }


    [Browsable(true)]
    internal class Individual : Customer
    {
        [DisplayName("Customer last name")]
        public string LastName { get; set; }
    }
}
