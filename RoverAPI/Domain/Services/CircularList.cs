using System.Collections.Generic;

namespace RoverAPI.Persistence.Services
{
    public class CircularList<T> : List<T>
    {
        public int CurrentIndex { get; set; }
        public T CurrentItem { get; private set; }

        public CircularList(List<T> list): base(list)
        {}

        public void NextItem()
        {
            CurrentIndex++;
            CurrentIndex %= Count;

            CurrentItem = this[CurrentIndex];
        }

        public void PreviousItem()
        {
            CurrentIndex--;
            if(CurrentIndex < 0)
            {
                CurrentIndex = Count - 1;
            }

            CurrentItem = this[CurrentIndex];
        }
    }
}
