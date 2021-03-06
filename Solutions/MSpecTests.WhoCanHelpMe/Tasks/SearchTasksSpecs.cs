﻿namespace MSpecTests.WhoCanHelpMe.Tasks
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using global::WhoCanHelpMe.Domain;
    using global::WhoCanHelpMe.Domain.Contracts.Repositories;
    using global::WhoCanHelpMe.Domain.Contracts.Tasks;
    using global::WhoCanHelpMe.Domain.Specifications;
    using global::WhoCanHelpMe.Tasks;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Rhino.Mocks;

    #endregion

    public abstract class specification_for_search_tasks : Specification<ISearchTasks, SearchTasks>
    {
        protected static IAssertionRepository the_assertion_repository;
        protected static ITagRepository the_tag_repository;

        Establish context = () =>
        {
            the_assertion_repository = DependencyOf<IAssertionRepository>();
            the_tag_repository = DependencyOf<ITagRepository>();
        };
    }

    public class when_the_search_tasks_are_asked_to_search_by_tag_name_and_there_are_matching_assertions : specification_for_search_tasks
    {
        static IList<Assertion> result;
        static string the_tag_name;
        static Tag the_tag;
        static IQueryable<Assertion> matching_tags;

        Establish context = () =>
            {
                the_tag_name = "tag name";

                the_tag = new Tag {
                                      Name = the_tag_name,
                                      Views = 1
                                  };
                
                the_tag.SetNonPublicProperty(
                    t => t.Id,
                    5);

                matching_tags = new List<Assertion>
                    {
                        new Assertion { Profile = new Profile { LastName = "X" } },
                        new Assertion { Profile = new Profile { LastName = "A" } },
                        new Assertion { Profile = new Profile { LastName = "M" } }
                    }.AsQueryable();

                the_tag_repository.StubFindOne().Return(the_tag);
                the_assertion_repository.StubFindAll().Return(matching_tags);
            };

        Because of = () => result = subject.ByTag(the_tag_name);

        It should_ask_the_tag_repository_for_the_tag_with_the_specified_name = () => the_tag_repository.AssertFindOneWasCalledWithSpecification<TagByNameSpecification, Tag>(t => t.Name == the_tag_name);

        It should_update_the_view_count_on_the_tag = () => 
        { 
            the_tag.Views.ShouldEqual(2);
            the_tag_repository.AssertWasCalled(t => t.Save(the_tag));
        };

        It should_ask_the_assertion_repository_for_the_matching_assertions = () => the_assertion_repository.AssertFindAllWasCalledWithSpecification<AssertionByTagIdSpecification, Assertion>(s => s.TagId == the_tag.Id);

        It should_return_the_list_of_matching_assertions = () => result.ShouldContainOnly(matching_tags);

        It should_sort_the_matching_assertions_by_profile_last_name = () =>
            {
                for (int index = 1; index < result.Count; index++)
                {
                    result[index - 1].Profile.LastName.ShouldBeLessThan(result[index].Profile.LastName);
                }
            };
    }

    public class when_the_search_tasks_are_asked_to_search_by_tag_name_and_there_are_no_matching_assertions : specification_for_search_tasks
    {
        static IList<Assertion> result;
        static string the_tag_name;
        static Tag the_tag;
        static IQueryable<Assertion> matching_tags;

        Establish context = () =>
        {
            the_tag_name = "tag name";

            the_tag = new Tag
            {
                Name = the_tag_name,
                Views = 1
            };

            the_tag.SetNonPublicProperty(t => t.Id, 5);

            matching_tags = new List<Assertion>().AsQueryable();

            the_tag_repository.StubFindOne().Return(the_tag);
            the_assertion_repository.StubFindAll().Return(matching_tags);
        };

        Because of = () => result = subject.ByTag(the_tag_name);

        It should_ask_the_tag_repository_for_the_tag_with_the_specified_name = () => the_tag_repository.AssertFindOneWasCalledWithSpecification<TagByNameSpecification, Tag>(t => t.Name == the_tag_name);

        It should_update_the_view_count_on_the_tag = () =>
        {
            the_tag.Views.ShouldEqual(2);
            the_tag_repository.AssertWasCalled(t => t.Save(the_tag));
        };

        It should_ask_the_assertion_repository_for_the_matching_assertions = () => the_assertion_repository.AssertFindAllWasCalledWithSpecification<AssertionByTagIdSpecification, Assertion>(s => s.TagId == the_tag.Id);

        It should_return_an_empty_list = () => result.ShouldBeEmpty();
    }

    public class when_the_search_tasks_are_asked_to_search_by_tag_name_and_there_is_no_matching_tag : specification_for_search_tasks
    {
        static IList<Assertion> result;
        static string the_tag_name;

        Establish context = () =>
        {
            the_tag_name = "tag name";

            the_tag_repository.StubFindOne().Return(null);
        };

        Because of = () => result = subject.ByTag(the_tag_name);

        It should_ask_the_tag_repository_for_the_tag_with_the_specified_name = () => the_tag_repository.AssertFindOneWasCalledWithSpecification<TagByNameSpecification, Tag>(t => t.Name == the_tag_name);

        It should_not_ask_the_assertion_repository_for_matching_assertions = () => the_assertion_repository.AssertFindAllWasNotCalledWithSpecification<AssertionByTagIdSpecification, Assertion>();
        
        It should_return_an_empty_list = () => result.ShouldBeEmpty();
    }
}
