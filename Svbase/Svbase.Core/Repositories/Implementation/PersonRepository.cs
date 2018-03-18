﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Svbase.Core.Data;
using Svbase.Core.Data.Entities;
using Svbase.Core.Models;
using Svbase.Core.Repositories.Abstract;
using Svbase.Core.Repositories.Interfaces;

namespace Svbase.Core.Repositories.Implementation
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context)
            : base(context) { }

        public IEnumerable<PersonSelectionModel> GetPersons()
        {
            var persons = DbSet
                .Select(x => new PersonSelectionModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Position = x.Position,
                    Gender = x.Gender,
                    Email = x.Email,
                    FirthtMobilePhone = x.MobileTelephoneFirst,
                    SecondMobilePhone = x.MobileTelephoneSecond,
                    HomePhone = x.StationaryPhone,
                    PartionType = x.PartionType,
                    DateBirth = x.BirthdayDate,
                    Beneficiaries = x.Beneficiaries.Select(b => new CheckboxItemModel
                    {
                        Id = b.Id,
                        Name = b.Name
                    }).ToList(),
                    City = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Apartment.Street.City.Id,
                        Name = f.Apartment.Street.City.Name,
                    }).FirstOrDefault(),
                    Street = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Apartment.Street.Id,
                        Name = f.Apartment.Street.Name,
                    }).FirstOrDefault(),
                    Apartment = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Apartment.Id,
                        Name = f.Apartment.Name,
                    }).FirstOrDefault(),
                    Flat = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Id,
                        Name = f.Number,
                    }).FirstOrDefault(),
                });
            return persons.ToList();
        }

        public PersonViewModel GetPersonById(int id)
        {
            var person = DbSet.Select(x => new PersonViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                //MiddleName = x.MiddleName,
                LastName = x.LastName,
                //Position = x.Position,
                //Gender = x.Gender,
                //Email = x.Email,
                //FirthtMobilePhone = x.MobileTelephoneFirst,
                //SecondMobilePhone = x.MobileTelephoneSecond,
                //HomePhone = x.HomePhone,
                //PartionType = x.PartionType,
                //DateBirth = x.BirthdayDate
                //Streets = x.Streets.Select(s => new StreetCreateModel
                //{
                //    Id = s.Id,
                //    Name = s.Name,
                //    CanDelete = !s.Apartments.Any()
                //})
            })
                .FirstOrDefault(x => x.Id == id);
            return person;
        }

        public IEnumerable<PersonSelectionModel> GetPersonsByIds(IEnumerable<int> ids)
        {
            if (ids == null) return new List<PersonSelectionModel>();
            var persons = DbSet
                .Where(x => ids.ToList().Contains(x.Id))
                .Select(x => new PersonSelectionModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    DateBirth = x.BirthdayDate,
                    Gender = x.Gender,
                    Position = x.Position,
                    FirthtMobilePhone = x.MobileTelephoneFirst,
                    SecondMobilePhone = x.MobileTelephoneSecond,
                    HomePhone = x.StationaryPhone,
                    Email = x.Email,
                    PartionType = x.PartionType,
                    Beneficiaries = x.Beneficiaries.Select(b => new CheckboxItemModel
                    {
                        Id = b.Id,
                        Name = b.Name
                    }).ToList(),
                    City = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Apartment.Street.City.Id,
                        Name = f.Apartment.Street.City.Name,
                    }).FirstOrDefault(),
                    Street = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Apartment.Street.Id,
                        Name = f.Apartment.Street.Name,
                    }).FirstOrDefault(),
                    Apartment = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Apartment.Id,
                        Name = f.Apartment.Name,
                    }).FirstOrDefault(),
                    Flat = x.Flats.Select(f => new BaseViewModel
                    {
                        Id = f.Id,
                        Name = f.Number,
                    }).FirstOrDefault(),

                })
                .ToList();
            return persons;
        }
    }
}
