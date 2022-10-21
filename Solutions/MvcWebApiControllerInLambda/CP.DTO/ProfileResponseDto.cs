using System;
using System.Collections.Generic;
using System.Globalization;

namespace CP.DTO
{
    public class ProfileResponseDto
    {
        public List<Person> Persons { get; set; }
        public string ProfileName { get; set; }
        public string Type { get; set; }
    }
       
    public class Person
    {
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Images Images { get; set; }
        public string ProfileName { get; set; }
    }
    public class Phone
    {
        public string Ext { get; set; }
        public string Label { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class Images
    {
        public string CdnHost { get; set; }
        public List<ImageList> ImageList { get; set; }
    }
    public class ImageList
    {
        public string ImageKey { get; set; }
        public string ImageName { get; set; }
        public List<ImageOptions> Images { get; set; }
    }
    public class ImageOptions
    {
        public string ProcessType { get; set; }
        public string ImageUrl { get; set; }
    }   
}
