//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personel
    {
        public int id { get; set; }
        public int DepartmanId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<short> Maas { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public bool Evlimi { get; set; }
    
        public virtual Departman Departman { get; set; }
    }
}
