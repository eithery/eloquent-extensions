// (C) Eithery
// Class ListExtensionsSpecs
// Contains unit tests for ListExtensions class
//
using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(typeof(ListExtensions))]
    public class ListExtensionsSpecs
    {
        class AddRange_Enumerable
        {
            It adds_a_collection_to_a_list = () =>
            {
                IList<int> list = new List<int>();
                list.AddRange(new List<int>{ 10, 20, 30, 40 });
                list.ShouldContain(10, 20, 30, 40);
                list.Count.ShouldEqual(4);
            };

            It should_raise_an_exception_for_null_list = () =>
            {
                IList<int> list = null;
                var exception = Catch.Exception(() => list.AddRange(new List<int>()));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It should_not_add_items_from_empty_collection = () =>
            {
                IList<int> list = new List<int>();
                list.AddRange(new List<int>());
                list.ShouldBeEmpty();
            };

            It should_raise_an_exception_for_null_argument = () =>
            {
                IList<int> list = new List<int>();
                var exception = Catch.Exception(() => list.AddRange((IEnumerable<int>)null));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }


        class AddRange_Params
        {
            It adds_items_to_a_list = () =>
            {
                IList<int> list = new List<int>();
                list.AddRange(10, 20, 30, 40);
                list.ShouldContain(10, 20, 30, 40);
                list.Count.ShouldEqual(4);
            };

            It adds_one_item_to_a_list = () =>
            {
                IList<int> list = new List<int>();
                list.AddRange(10);
                list.ShouldContain(10);
                list.Count.ShouldEqual(1);
            };

            It adds_null_items_to_a_list = () =>
            {
                IList<string> list = new List<string>();
                list.AddRange(null, null, null);
                foreach (var item in list)
                    item.ShouldBeNull();
                list.Count.ShouldEqual(3);
            };

            It should_raise_an_exception_for_null_list = () =>
            {
                IList<int> list = null;
                var exception = Catch.Exception(() => list.AddRange(1, 2, 3, 4));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It should_raise_an_exception_for_null_argument = () =>
            {
                IList<int> list = new List<int>();
                var exception = Catch.Exception(() => list.AddRange(null));
                exception.ShouldBeOfExactType<ArgumentNullException>();

                IList<string> strList = new List<string>();
                exception = Catch.Exception(() => strList.AddRange(null));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It does_nothing_calling_without_arguments = () =>
            {
                IList<int> list = new List<int>();
                list.AddRange();
                list.ShouldBeEmpty();
            };
        }
    }
}
