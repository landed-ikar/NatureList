using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace NatureListService.Models.Database {

    public partial class User: IUser {
        public User(Session session) : base(session) { }

        IEnumerable<IRole> IUser.Roles { get { return this.Roles; } }

        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
