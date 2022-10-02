

using AutoMapper.Execution;
using System;

namespace Tapar.Core.Common.Dtos.Place
{
    public class PlaceAddDto
    {
        public string tablo { get; set; }
        public string description { get; set; }
        public string modir { get; set; }
        public string gValue { get; set; }
        public List<int> filters { get; set; }
        public Address address { get; set; }
        public RelationWays relationWays { get; set; }
        //workingTimeId: number
        //workingDays: WorkingDays[]
        //businessPics: File[]
        //modirPic: File
        //visitCartPics: File[]
        //tags: string[]
    }
    public class Address
    {
        public int ostan { get; set; }
        public int shahrestan { get; set; }
        public string restAddress { get; set; }
    }
   public class RelationWays
    {
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string mob1 { get; set; }
        public string mob2 { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string telegram { get; set; }
        public string whatsapp { get; set; }
    }
   public class WorkingDays
    {
        id: number
        am: boolean
        pm: boolean
    }
}
