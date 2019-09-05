// Eithery: Eloquent Extensions
// Class SampleAttribute
// A dummy sample attribute for test purposes
//
using System;

namespace EloquentExtensions
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple=true)]
    internal class SampleAttribute : Attribute
    {
        public string DummyProperty { get; set; }
    }
}
