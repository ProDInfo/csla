﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;

namespace Csla.Test.PropertyGetSet
{
  [Serializable]
  public class EditableGetSetTopBase<T> : BusinessBase<T> 
    where T: EditableGetSetTopBase<T>
  {
    private static int _dummy;

    public EditableGetSetTopBase()
    {
      _dummy = 0;
    }

    private static PropertyInfo<string> TopBaseProperty = RegisterProperty<string>(typeof(EditableGetSetTopBase<T>), new PropertyInfo<string>("TopBase", "TopBase"));
    public string TopBase
    {
      get { return GetProperty<string>(TopBaseProperty); }
      set { SetProperty<string>(TopBaseProperty, value); }
    }
  }
}
