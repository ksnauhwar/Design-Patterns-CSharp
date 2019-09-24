using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace EventBroker.Mediator
{
    public class EventBroker : IObservable<PlayerEvent>
    {
        private readonly Subject<PlayerEvent> _subsciptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
          return  _subsciptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            _subsciptions.OnNext(pe);
        }
    }
}
