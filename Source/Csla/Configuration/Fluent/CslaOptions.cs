﻿//-----------------------------------------------------------------------
// <copyright file="CslaConfiguration.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>Use this type to configure the settings for CSLA .NET</summary>
//-----------------------------------------------------------------------
using Csla.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Csla.Configuration
{
  /// <summary>
  /// Use this type to configure the settings for CSLA .NET.
  /// </summary>
  public class CslaOptions
  {
    /// <summary>
    /// Creates an instance of the type
    /// </summary>
    /// <param name="services">Services collection</param>
    public CslaOptions(IServiceCollection services)
    {
      Services = services;
      DataPortalOptions = new DataPortalOptions(this);
    }

    /// <summary>
    /// Gets a reference to the current services collection.
    /// </summary>
    public IServiceCollection Services { get; private set; }

    /// <summary>
    /// Gets or sets the type for the IContextManager to
    /// be used by ApplicationContext.
    /// </summary>
    public Type ContextManagerType { get; set; }

    ///// <summary>
    ///// Registers a specific ApplicationContext manager service,
    ///// overriding the default service registration.
    ///// </summary>
    ///// <typeparam name="T">IContextManager implementation type.</typeparam>
    ///// <returns></returns>
    //public CslaOptions RegisterContextManager<T>() 
    //  where T : IContextManager
    //{
    //  Services.AddScoped(typeof(IContextManager), typeof(T));
    //  return this;
    //}

    /// <summary>
    /// Sets a value indicating whether CSLA
    /// should fallback to using reflection instead of
    /// System.Linq.Expressions (true, default).
    /// </summary>
    /// <param name="value">Value</param>
    public CslaOptions UseReflectionFallback(bool value)
    {
      ApplicationContext.UseReflectionFallback = value;
      return this;
    }

    /// <summary>
    /// Sets a value representing the application version
    /// for use in server-side data portal routing.
    /// </summary>
    /// <param name="version">
    /// Application version used to create data portal
    /// routing tag (can not contain '-').
    /// </param>
    /// <remarks>
    /// If this value is set then you must use the
    /// .NET Core server-side Http data portal endpoint
    /// as a router so the request can be routed to
    /// another app server that is running the correct
    /// version of the application's assemblies.
    /// </remarks>
    public CslaOptions VersionRoutingTag(string version)
    {
      if (!string.IsNullOrWhiteSpace(version))
        if (version.Contains("-") || version.Contains("/"))
          throw new ArgumentException("VersionRoutingTag");
      ApplicationContext.VersionRoutingTag = version;
      return this;
    }

    /// <summary>
    /// Sets the factory type that creates PropertyInfo objects.
    /// </summary>
    public CslaOptions RegisterPropertyInfoFactory<T>() where T : IPropertyInfoFactory
    {
      Core.FieldManager.PropertyInfoFactory.FactoryType = typeof(T);
      return this;
    }

    /// <summary>
    /// Gets the SecurityOptions instance.
    /// </summary>
    internal SecurityOptions SecurityOptions { get; private set; } = new SecurityOptions();
    /// <summary>
    /// Gets the SerializationOptions instance.
    /// </summary>
    internal SerializationOptions SerializationOptions { get; private set; } = new SerializationOptions();
    /// <summary>
    /// Gets the DataPortalClientOptions instance.
    /// </summary>
    internal DataPortalOptions DataPortalOptions { get; private set; }
    /// <summary>
    /// Gets the DataOptions instance.
    /// </summary>
    internal DataOptions DataOptions { get; private set; } = new DataOptions();
    /// <summary>
    /// Gets the DataOptions instance.
    /// </summary>
    public BindingOptions BindingOptions { get; private set; } = new BindingOptions();
  }
}