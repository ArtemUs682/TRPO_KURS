//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bills
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Client_Id { get; set; }
        public int Resource_Id { get; set; }
        public bool Status { get; set; }
        public double Payment { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Resources Resources { get; set; }
    }
}
