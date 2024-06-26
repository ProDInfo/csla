﻿//-----------------------------------------------------------------------
// <copyright file="BadGetSet.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>no summary</summary>
//-----------------------------------------------------------------------

namespace Csla.Test.PropertyGetSet
{
#if TESTING
  [System.Diagnostics.DebuggerNonUserCode]
#endif
  [Serializable]
  public class BadGetSet : BusinessBase<BadGetSet>
  {
    // the registering class is intentionally incorrect for this test
    private static PropertyInfo<int> IdProperty = RegisterProperty<int>(typeof(EditableGetSet), new PropertyInfo<int>("Id"));
    public int Id
    {
      get { return GetProperty<int>(IdProperty); }
      set { SetProperty<int>(IdProperty, value); }
    }

    public static BadGetSet GetObject(IDataPortal<BadGetSet> dataPortal)
    {
      return dataPortal.Fetch();
    }

    [Fetch]
    private void Fetch()
    {
    }
  }

#if TESTING
  [System.Diagnostics.DebuggerNonUserCode]
#endif
  [Serializable]
  public class BadGetSetTwo : BusinessBase<BadGetSetTwo>
  {
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    public int Id
    {
      get { return GetProperty<int>(IdProperty); }
      set { SetProperty<int>(IdProperty, value); }
    }

    // the registering class is intentionally incorrect for this test
    public static readonly PropertyInfo<int> IdTwoProperty = RegisterProperty<int>(c => c.Id);
    public int IdTwo
    {
      get { return GetProperty<int>(IdTwoProperty); }
      set { SetProperty<int>(IdTwoProperty, value); }
    }

    public static BadGetSetTwo GetObject(IDataPortal<BadGetSetTwo> dataPortal)
    {
      return dataPortal.Fetch();
    }

    [Fetch]
    private void Fetch()
    {
    }
  }
}