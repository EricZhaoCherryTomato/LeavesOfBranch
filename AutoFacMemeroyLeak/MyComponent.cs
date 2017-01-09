using System;

namespace AutoFacMemeroyLeak
{
    public class MyComponent : IDisposable
    {
        public MyComponent()
        {
            
        }

        ~MyComponent()
        {
            
        }

        public void Dispose()
        {
        }
    }
}