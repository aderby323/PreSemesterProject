using PreSemesterProject.Models;
using System;
using System.Collections.Generic;

namespace PreSemesterProject.Repository
{
    public class FakeRepository
    {
        public List<Opportunity> Opportunities;
        public List<Volunteer> Volunteers;

        public FakeRepository()
        {
            Opportunities = new List<Opportunity>();
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 1",
                Description = "This is the first opportunity. There isn't much to do but that's ok! :)",
                Location = "Avenues",
                ModifiedOn = new DateTime(2021, 8, 2)
            });
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 2",
                Description = "This is the second opportunity. Just another plain ol opportunity",
                Location = "UNF",
                ModifiedOn = new DateTime(2021, 6, 9)
            });
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 3",
                Description = "This is the third opportunity. Yet another opportunity for a time of thrills and things and such.",
                Location = "Southside",
                ModifiedOn = new DateTime(2020, 1, 4)
            });

            
            Volunteers = new List<Volunteer>();
            Volunteers.Add(new Volunteer()
            {
                Username = "bross33",
                FirstName = "Bob",
                LastName = "Ross",


                // how can we add a list?
                // GET HELP FROM ALEX
                 PreferredCenters = "Avenues",

                SkillsAndInterests = "Painting",
                Availability = "Open",
                VolunteerApprovalStatus = ApprovalStatus.Pending

            });
            Volunteers.Add(new Volunteer()
            {
                Username = "ronmcdon65",
                FirstName = "Ronald",
                LastName = "McDonald",

                // how can we add a list?
                PreferredCenters = "UNF",

                SkillsAndInterests = "Cooking",
                Availability = "Mon - Fri 8:00am to 5:00pm",
                VolunteerApprovalStatus = ApprovalStatus.Approved

            });
            Volunteers.Add(new Volunteer()
            {
                Username = "wheresmahat78",
                FirstName = "Mahatma",
                LastName = "Gandhi",

                // how can we add a list?
                PreferredCenters = "Southside",

                SkillsAndInterests = "Counselling",
                Availability = "Open",
                VolunteerApprovalStatus = ApprovalStatus.Denied

            });
            
        }
    }
}
