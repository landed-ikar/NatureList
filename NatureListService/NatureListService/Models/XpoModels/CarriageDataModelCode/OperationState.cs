using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace NatureListService.Models.CarriageDataModel {

    public partial class OperationState {
        public OperationState(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
