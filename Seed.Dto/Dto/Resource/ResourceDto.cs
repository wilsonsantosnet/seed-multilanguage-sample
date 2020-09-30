using System.ComponentModel.DataAnnotations;
using Common.Domain.Base;
using System;

namespace Seed.Dto
{
	public class ResourceDto  : DtoBase
	{
	
        

        public virtual int ResourceId {get; set;}

        [Required(ErrorMessage="Resource - Campo Group é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Resource - Quantidade de caracteres maior que o permitido para o campo Group")]
        public virtual string Group {get; set;}

        [Required(ErrorMessage="Resource - Campo Culture é Obrigatório")]
        [MaxLength(6, ErrorMessage = "Resource - Quantidade de caracteres maior que o permitido para o campo Culture")]
        public virtual string Culture {get; set;}

        [Required(ErrorMessage="Resource - Campo key é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Resource - Quantidade de caracteres maior que o permitido para o campo key")]
        public virtual string key {get; set;}

        [Required(ErrorMessage="Resource - Campo value é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Resource - Quantidade de caracteres maior que o permitido para o campo value")]
        public virtual string value {get; set;}


		
	}
}
