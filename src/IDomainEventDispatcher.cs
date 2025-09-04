﻿namespace Silverness.SharedKernel;

public interface IDomainEventDispatcher
{
  Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents);
}
