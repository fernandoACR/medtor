using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ControlMedicoApi
{
    public class InitialMedicoConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("idConfiguracionMedico", IsRequired = false, IsKey = false)]
        public int IdConfiguracionMedico
        {
            get { return (int)base["idConfiguracionMedico"]; }
        }

        [ConfigurationProperty("idMedico", IsRequired = false)]
        public int IdMedico
        {
            get { return (int)base["idMedico"]; }
        }

        [ConfigurationProperty("descripcion", IsRequired = false)]
        public string Descripcion
        {
            get { return (string)base["descripcion"]; }
        }

        [ConfigurationProperty("tipoConfiguracion", IsRequired = false)]
        public string TipoConfiguracion
        {
            get { return (string)base["tipoConfiguracion"]; }
        }
        [ConfigurationProperty("valor", IsRequired = false)]
        public string Valor
        {
            get { return (string)base["valor"]; }
        }
        [ConfigurationProperty("activo", IsRequired = false)]
        public int Activo
        {
            get { return (int)base["activo"]; }
        }
        [ConfigurationProperty("nombre", IsRequired = false)]
        public string Nombre
        {
            get { return (string)base["nombre"]; }
        }
    }

    [ConfigurationCollection(typeof(InitialMedicoConfigurationElement))]
    public class InitialMedicoConfigurationElementCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "initialMedicoConfiguration";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName,
              StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new InitialMedicoConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((InitialMedicoConfigurationElement)(element)).IdConfiguracionMedico;
        }

        public InitialMedicoConfigurationElement this[int idx]
        {
            get { return (InitialMedicoConfigurationElement)BaseGet(idx); }
        }
    }

    public class DefaultConfigMedico : ConfigurationSection
    {
        [ConfigurationProperty("initialMedicoConfigurations")]
        public InitialMedicoConfigurationElementCollection InitialMedicoConfigurations
        {
            get { return ((InitialMedicoConfigurationElementCollection)(base["initialMedicoConfigurations"])); }
            set { base["initialMedicoConfigurations"] = value; }
        }
    }    
}