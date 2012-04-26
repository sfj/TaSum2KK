﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("tempdbModel", "FK__menu__page_type__32E0915F", "skabelon", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(tempdbModel.skabelon), "menu", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(tempdbModel.menu), true)]
[assembly: EdmRelationshipAttribute("tempdbModel", "FK__menu__parent__33D4B598", "menu", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(tempdbModel.menu), "menu1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(tempdbModel.menu), true)]

#endregion

namespace tempdbModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class menuEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new menuEntities object using the connection string found in the 'menuEntities' section of the application configuration file.
        /// </summary>
        public menuEntities() : base("name=menuEntities", "menuEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new menuEntities object.
        /// </summary>
        public menuEntities(string connectionString) : base(connectionString, "menuEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new menuEntities object.
        /// </summary>
        public menuEntities(EntityConnection connection) : base(connection, "menuEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<menu> menus
        {
            get
            {
                if ((_menus == null))
                {
                    _menus = base.CreateObjectSet<menu>("menus");
                }
                return _menus;
            }
        }
        private ObjectSet<menu> _menus;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<skabelon> skabelons
        {
            get
            {
                if ((_skabelons == null))
                {
                    _skabelons = base.CreateObjectSet<skabelon>("skabelons");
                }
                return _skabelons;
            }
        }
        private ObjectSet<skabelon> _skabelons;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the menus EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTomenus(menu menu)
        {
            base.AddObject("menus", menu);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the skabelons EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToskabelons(skabelon skabelon)
        {
            base.AddObject("skabelons", skabelon);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="tempdbModel", Name="menu")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class menu : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new menu object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        public static menu Createmenu(global::System.Int32 id)
        {
            menu menu = new menu();
            menu.id = id;
            return menu;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String text_dk
        {
            get
            {
                return _text_dk;
            }
            set
            {
                Ontext_dkChanging(value);
                ReportPropertyChanging("text_dk");
                _text_dk = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("text_dk");
                Ontext_dkChanged();
            }
        }
        private global::System.String _text_dk;
        partial void Ontext_dkChanging(global::System.String value);
        partial void Ontext_dkChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String text_en
        {
            get
            {
                return _text_en;
            }
            set
            {
                Ontext_enChanging(value);
                ReportPropertyChanging("text_en");
                _text_en = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("text_en");
                Ontext_enChanged();
            }
        }
        private global::System.String _text_en;
        partial void Ontext_enChanging(global::System.String value);
        partial void Ontext_enChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> page_type
        {
            get
            {
                return _page_type;
            }
            set
            {
                Onpage_typeChanging(value);
                ReportPropertyChanging("page_type");
                _page_type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("page_type");
                Onpage_typeChanged();
            }
        }
        private Nullable<global::System.Int32> _page_type;
        partial void Onpage_typeChanging(Nullable<global::System.Int32> value);
        partial void Onpage_typeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> level
        {
            get
            {
                return _level;
            }
            set
            {
                OnlevelChanging(value);
                ReportPropertyChanging("level");
                _level = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("level");
                OnlevelChanged();
            }
        }
        private Nullable<global::System.Int32> _level;
        partial void OnlevelChanging(Nullable<global::System.Int32> value);
        partial void OnlevelChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> sort
        {
            get
            {
                return _sort;
            }
            set
            {
                OnsortChanging(value);
                ReportPropertyChanging("sort");
                _sort = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("sort");
                OnsortChanged();
            }
        }
        private Nullable<global::System.Int32> _sort;
        partial void OnsortChanging(Nullable<global::System.Int32> value);
        partial void OnsortChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> parent
        {
            get
            {
                return _parent;
            }
            set
            {
                OnparentChanging(value);
                ReportPropertyChanging("parent");
                _parent = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("parent");
                OnparentChanged();
            }
        }
        private Nullable<global::System.Int32> _parent;
        partial void OnparentChanging(Nullable<global::System.Int32> value);
        partial void OnparentChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("tempdbModel", "FK__menu__page_type__32E0915F", "skabelon")]
        public skabelon skabelon
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<skabelon>("tempdbModel.FK__menu__page_type__32E0915F", "skabelon").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<skabelon>("tempdbModel.FK__menu__page_type__32E0915F", "skabelon").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<skabelon> skabelonReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<skabelon>("tempdbModel.FK__menu__page_type__32E0915F", "skabelon");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<skabelon>("tempdbModel.FK__menu__page_type__32E0915F", "skabelon", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("tempdbModel", "FK__menu__parent__33D4B598", "menu1")]
        public EntityCollection<menu> menu1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<menu>("tempdbModel.FK__menu__parent__33D4B598", "menu1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<menu>("tempdbModel.FK__menu__parent__33D4B598", "menu1", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("tempdbModel", "FK__menu__parent__33D4B598", "menu")]
        public menu menu2
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<menu>("tempdbModel.FK__menu__parent__33D4B598", "menu").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<menu>("tempdbModel.FK__menu__parent__33D4B598", "menu").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<menu> menu2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<menu>("tempdbModel.FK__menu__parent__33D4B598", "menu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<menu>("tempdbModel.FK__menu__parent__33D4B598", "menu", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="tempdbModel", Name="skabelon")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class skabelon : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new skabelon object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="filename">Initial value of the filename property.</param>
        public static skabelon Createskabelon(global::System.Int32 id, global::System.String filename)
        {
            skabelon skabelon = new skabelon();
            skabelon.id = id;
            skabelon.filename = filename;
            return skabelon;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String filename
        {
            get
            {
                return _filename;
            }
            set
            {
                OnfilenameChanging(value);
                ReportPropertyChanging("filename");
                _filename = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("filename");
                OnfilenameChanged();
            }
        }
        private global::System.String _filename;
        partial void OnfilenameChanging(global::System.String value);
        partial void OnfilenameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("tempdbModel", "FK__menu__page_type__32E0915F", "menu")]
        public EntityCollection<menu> menus
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<menu>("tempdbModel.FK__menu__page_type__32E0915F", "menu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<menu>("tempdbModel.FK__menu__page_type__32E0915F", "menu", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
