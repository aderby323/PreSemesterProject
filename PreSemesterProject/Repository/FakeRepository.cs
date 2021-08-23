﻿using PreSemesterProject.Models;
using System;
using System.Collections.Generic;

namespace PreSemesterProject.Repository
{
    public class FakeRepository
    {
        public List<Volunteer> Volunteers;

        public FakeRepository()
        {
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
