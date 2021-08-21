using PreSemesterProject.Models;
using System;
using System.Collections.Generic;

namespace PreSemesterProject.Repository
{
    public class FakeRepository
    {
        public List<Opportunity> Opportunities;
        public List<Volunteer> Volunteers;
        public List<User> Users;

        public FakeRepository()
        {
            Users = new List<User>();
            Users.Add(new User()
            {
                Username = "aderby",
                Password = "test",
                Roles = { "Admin" }
            });
            Opportunities = new List<Opportunity>();
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 1",
                Description = "This is the first opportunity. There isn't much to do but that's ok! :)",
                Location = PreferredCenter.Avenues,
                Date = new DateTime(2021, 8, 2)
            });
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 2",
                Description = "This is the second opportunity. Just another plain ol opportunity",
                Location = PreferredCenter.UNF,
                Date = new DateTime(2021, 6, 9)
            });

            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 3",
                Description = "This is the third opportunity. Yet another opportunity for a time of thrills and things and such.",
                Location = PreferredCenter.Southside,
                Date = new DateTime(2020, 1, 4)
            });
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 4",
                Description = "Kanye, please drop Donda.",
                Location = PreferredCenter.UNF,
                Date = new DateTime(2021, 8, 27)
            });
            Opportunities.Add(new Opportunity()
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Opportunity 5",
                Description = "Another test opportunity sheeeeeeesh",
                Location = PreferredCenter.Baymeadows,
                Date = new DateTime(2021, 6, 9)
            });

            Volunteers = new List<Volunteer>();
            Volunteers.Add(new Volunteer()
            {
                VolunteerID = Guid.NewGuid().ToString(),
                Username = "bross33",
                FirstName = "Bob",
                LastName = "Ross",
                Password = "abc123",
                // PreferredCenters = "Avenues",
                PreferredCenters = PreferredCenter.Avenues,
                SkillsAndInterests = "Painting",
                Availability = "Tue - Thu 12:00pm to 3:00pm",
                Address = "123 Easy St",
                HomePhone = "N/A",
                WorkPhone = "N/A",
                CellPhone = "904-789-8521",
                EmailAddress = "bross33@gmail.com",
                EducationalBackground = "High school",
                CurrentLicenses = "N/A",
                EmergencyContactName = "Billy Ross",
                EmergencyPhone = "753-896-9841",
                EmergencyEmailAddress = "theotherross45@gmail.com",
                DriversLicenseOnFile = true,
                SSCardOnFile = true,
                VolunteerApprovalStatus = ApprovalStatus.Pending,
                Inactive = false
            });
            Volunteers.Add(new Volunteer()
            {
                VolunteerID = Guid.NewGuid().ToString(),
                Username = "ronmcdon65",
                FirstName = "Ronald",
                LastName = "McDonald",
                Password = "mcdoubletrouble56",
                // PreferredCenters = "UNF",
                PreferredCenters = PreferredCenter.UNF,
                SkillsAndInterests = "Cooking",
                Availability = "Mon - Fri 8:00am to 5:00pm",
                Address = "456 Hamburgler Way",
                HomePhone = "N/A",
                WorkPhone = "N/A",
                CellPhone = "904-583-4561",
                EmailAddress = "ronmcdon65@gmail.com",
                EducationalBackground = "High school",
                CurrentLicenses = "Food Handler's License",
                EmergencyContactName = "Big Bird",
                EmergencyPhone = "985-621-4598",
                EmergencyEmailAddress = "sesamebird@gmail.com",
                DriversLicenseOnFile = false,
                SSCardOnFile = true,
                VolunteerApprovalStatus = ApprovalStatus.Approved,
                Inactive = true

            });
            Volunteers.Add(new Volunteer()
            {
                VolunteerID = Guid.NewGuid().ToString(),
                Username = "wheresmahat78",
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Password = "handygandy09",
                // PreferredCenters = "Southside",
                PreferredCenters = PreferredCenter.Southside,
                SkillsAndInterests = "Counselling",
                Availability = "Fri 7:00pm - 9:00pm",
                Address = "951 Watermelon Dr",
                HomePhone = "N/A",
                WorkPhone = "N/A",
                CellPhone = "904-852-9512",
                EmailAddress = "lotuspeace@gmail.com",
                EducationalBackground = "Law School",
                CurrentLicenses = "N/A",
                EmergencyContactName = "Frodo Baggins",
                EmergencyPhone = "963-851-7561",
                EmergencyEmailAddress = "betterthanbilbo78@gmail.com",
                DriversLicenseOnFile = true,
                SSCardOnFile = false,
                VolunteerApprovalStatus = ApprovalStatus.Denied,
                Inactive = false
            });
            
        }
    }
}
