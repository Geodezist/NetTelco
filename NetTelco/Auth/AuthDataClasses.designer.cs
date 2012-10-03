﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.269
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetTelco.Auth
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SecurityDB")]
	public partial class AuthDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    #endregion
		
		public AuthDataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SecurityDB"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AuthDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AuthDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AuthDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AuthDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _FIRST_NAME;
		
		private string _LAST_NAME;
		
		private string _MIDDLE_NAME;
		
		private string _LOGIN;
		
		private string _PASSWORD;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnFIRST_NAMEChanging(string value);
    partial void OnFIRST_NAMEChanged();
    partial void OnLAST_NAMEChanging(string value);
    partial void OnLAST_NAMEChanged();
    partial void OnMIDDLE_NAMEChanging(string value);
    partial void OnMIDDLE_NAMEChanged();
    partial void OnLOGINChanging(string value);
    partial void OnLOGINChanged();
    partial void OnPASSWORDChanging(string value);
    partial void OnPASSWORDChanged();
    #endregion
		
		public Users()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FIRST_NAME", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string FIRST_NAME
		{
			get
			{
				return this._FIRST_NAME;
			}
			set
			{
				if ((this._FIRST_NAME != value))
				{
					this.OnFIRST_NAMEChanging(value);
					this.SendPropertyChanging();
					this._FIRST_NAME = value;
					this.SendPropertyChanged("FIRST_NAME");
					this.OnFIRST_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LAST_NAME", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string LAST_NAME
		{
			get
			{
				return this._LAST_NAME;
			}
			set
			{
				if ((this._LAST_NAME != value))
				{
					this.OnLAST_NAMEChanging(value);
					this.SendPropertyChanging();
					this._LAST_NAME = value;
					this.SendPropertyChanged("LAST_NAME");
					this.OnLAST_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MIDDLE_NAME", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string MIDDLE_NAME
		{
			get
			{
				return this._MIDDLE_NAME;
			}
			set
			{
				if ((this._MIDDLE_NAME != value))
				{
					this.OnMIDDLE_NAMEChanging(value);
					this.SendPropertyChanging();
					this._MIDDLE_NAME = value;
					this.SendPropertyChanged("MIDDLE_NAME");
					this.OnMIDDLE_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LOGIN", DbType="VarChar(32) NOT NULL", CanBeNull=false)]
		public string LOGIN
		{
			get
			{
				return this._LOGIN;
			}
			set
			{
				if ((this._LOGIN != value))
				{
					this.OnLOGINChanging(value);
					this.SendPropertyChanging();
					this._LOGIN = value;
					this.SendPropertyChanged("LOGIN");
					this.OnLOGINChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="VarChar(32) NOT NULL", CanBeNull=false)]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this.OnPASSWORDChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD = value;
					this.SendPropertyChanged("PASSWORD");
					this.OnPASSWORDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
