//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace NatureListService.Models.CarriageDataModel {

    public partial class Invoice : XPObject {
        string fNumber;
        public string Number {
            get { return fNumber; }
            set { SetPropertyValue<string>(nameof(Number), ref fNumber, value); }
        }
        [Association(@"CarriageReferencesInvoice")]
        public XPCollection<Carriage> Carriages { get { return GetCollection<Carriage>(nameof(Carriages)); } }
    }

}
