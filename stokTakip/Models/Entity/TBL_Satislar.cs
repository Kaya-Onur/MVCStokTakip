//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace stokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Satislar
    {
        public int id { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> personel { get; set; }
        public Nullable<int> musteri { get; set; }
        public Nullable<decimal> fiyat { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    
        public virtual TBL_Musteri TBL_Musteri { get; set; }
        public virtual TBL_Personel TBL_Personel { get; set; }
        public virtual TBL_Urunler TBL_Urunler { get; set; }
    }
}