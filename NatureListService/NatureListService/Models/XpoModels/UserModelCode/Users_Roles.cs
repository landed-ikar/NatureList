using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace NatureListService.Models.Database {

    public partial class Users_Roles {
        public Users_Roles(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
