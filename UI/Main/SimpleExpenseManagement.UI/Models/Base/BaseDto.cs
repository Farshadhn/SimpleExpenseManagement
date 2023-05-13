using SimpleExpenseManagement.UI.Models.Events;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.UI.Component.Attributes;
using System;

namespace SimpleExpenseManagement.UI.Models.Base;

public class BaseDto<TEntity> : IEntity<TEntity> 
{
    [Hidden]
    [HiddenDto]
    [key]
    public TEntity Id { get; set; }

    [Hidden]
    [HiddenDto]
    public DateTime LastEditedDateTime { get; set; }

    [Hidden]
    [HiddenDto]
    public Guid? LastEditedUserId { get; set; }

    [Hidden]
    [HiddenDto]
    public User LastEditedUser { get; set; }
}
public class BaseDto : BaseDto<Guid>, IEntity<Guid>
{
}
