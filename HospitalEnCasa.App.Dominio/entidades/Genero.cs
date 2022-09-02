using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace HospitalEnCasa.App.Dominio.entidades
{

    public static class EnumExtensionMethods  
    {  
        public static string GetEnumDescription(this Enum enumValue)  
        {  
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());  
  
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);  
  
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();  
        }  
    } 
    public enum GeneroEnum
    {
        [Description("Genero con el cual se registro el paciente el cual es masculino")]
        masculino,
        [Description("Genero con el cual se registro el paciente el cual es femenino")]
        femenino,
    }
    public class Genero
    {
        public Genero(GeneroEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription(); 
        }

        public Genero() { } //For EF

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Persona> LaPersona {get;set;}

        public static implicit operator Genero(GeneroEnum @enum) => new Genero(@enum);

        public static implicit operator GeneroEnum(Genero genero) => (GeneroEnum)genero.Id;
    }

}