﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Svbase.Core.Data.Entities;

namespace Svbase.Core.Models
{
    public class PersonListModel
    {
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        [Display(Name = "По батькові")]
        public string MiddleName { get; set; }
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

       
    }

    public class PersonViewModel  : PersonListModel
    {
        [Phone]
        [Display(Name = "Мобільний телефон 1")]
        public string FirstMobilePhone { get; set; }
        [Phone]
        [Display(Name = "Мобільний телефон 2")]
        public string SecondMobilePhone { get; set; }
        [Phone]
        [Display(Name = "Домашній номер телефону")]
        public string HomePhone { get; set; }
        [EmailAddress]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата народження")]
        public DateTime? DateBirth { get; set; }
        [Display(Name = "Посада")]
        public string Position { get; set; }
        [Display(Name = "Партійний тип")]
        public string PartionType { get; set; }
        [Display(Name = "Стать")]
        public bool Gender { get; set; }
        [Display(Name = "Квартира")]
        public int FlatId { get; set; }
        [Display(Name = "Місце роботи")]
        public Work Work { get; set; }
        public IList<CheckboxItemModel> Beneficiaries { get; set; }

        public PersonViewModel()
        {
        }

        public PersonViewModel(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;
            DateBirth = person.BirthdayDate;
            Gender = person.Gender;
            Position = person.Position;
            FirstMobilePhone = person.MobileTelephoneFirst;
            SecondMobilePhone = person.MobileTelephoneSecond;
            HomePhone = person.StationaryPhone;
            Email = person.Email;
            PartionType = person.PartionType;
        }
        public Person Update(Person person)
        {
            person.Id = Id;
            person.FirstName = FirstName;
            person.MiddleName = MiddleName;
            person.LastName = LastName;
            person.BirthdayDate = DateBirth;
            person.Gender = Gender;
            person.Position = Position;
            person.MobileTelephoneFirst = FirstMobilePhone;
            person.MobileTelephoneSecond = SecondMobilePhone;
            person.StationaryPhone = HomePhone;
            person.Email = Email;
            person.PartionType = PartionType;

            return person;
        }

        public void SetFields(Person entity)
        {
            FirstName = entity.FirstName;
            MiddleName = entity.MiddleName;
            LastName = entity.LastName;
            DateBirth = entity.BirthdayDate;
            Email = entity.Email;
            Gender = entity.Gender;
            Position = entity.Position;
            PartionType = entity.PartionType;
            FirstMobilePhone = entity.MobileTelephoneFirst;
            SecondMobilePhone = entity.MobileTelephoneSecond;
            HomePhone = entity.StationaryPhone;

        }
        //public int BeneficiaryId { get; set; }
        //public int DistrictId { get; set; }
        //public int FlatId { get; set; }
    }

    public class PersonSelectionModel : PersonViewModel
    {
        [Required]
        public BaseViewModel City { get; set; }
        public BaseViewModel Street { get; set; }
        public BaseViewModel Apartment { get; set; }
        public BaseViewModel Flat { get; set; }
    }
}
