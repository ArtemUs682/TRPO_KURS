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
    
    public partial class Requests
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public System.DateTime Date { get; set; }
        public int RequestType_Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> Worker_Id { get; set; }
        public int Status_Id { get; set; }
        public int User_Id { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual RequestTypes RequestTypes { get; set; }
        public virtual Statuses Statuses { get; set; }
        public virtual Users Users { get; set; }
        public virtual Workers Workers { get; set; }
    }
}
