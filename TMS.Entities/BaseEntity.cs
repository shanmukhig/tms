/*============================================================
** 
** Class:  BaseEntity
**
** <OWNER>Shanmukhi Goli</OWNER> 
**
** Purpose: 
** 
===========================================================*/

using System;
using TMS.Entities.Enum;

namespace TMS.Entities
{
  public class BaseEntity
  {
    public string Id { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public long? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Status Status { get; set; }
  }
}