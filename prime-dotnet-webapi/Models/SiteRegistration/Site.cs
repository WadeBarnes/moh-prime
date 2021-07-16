using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DelegateDecompiler;
using Newtonsoft.Json;

namespace Prime.Models
{
    [Table("Site")]
    public abstract class Site : BaseAuditable
    {

    }
}
